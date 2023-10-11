using Infra.Email;
using Infra.Data;
using Application;
using Infra.Data.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDataBaseInMemoryService();
builder.Services.AddEmailService();
builder.Services.AddApplicationService();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

DataInit(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


void DataInit(IApplicationBuilder app)
{
    using (var serviceScope = app.ApplicationServices.CreateScope())
    {
        var context = serviceScope.ServiceProvider.GetService<InMemoryContext>();
        if (context != null)
        {
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new Domain.Entities.User(id: Guid.NewGuid(), email: "marcelo@hotmail.com", name: "Marcelo Almeida"),
                    new Domain.Entities.User(id: Guid.NewGuid(), email: "heitor@hotmail.com", name: "Heitor Gomes"),
                    new Domain.Entities.User(id: Guid.NewGuid(), email: "diego@hotmail.com", name: "Diego Rodrigues"));

                context.SaveChanges();
            }
        }
    }
}