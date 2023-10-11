using Domain.Entities;
using Domain.Ports;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly InMemoryContext _context;

        public UserRepository(InMemoryContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(Guid id)
        {
            var user = await _context.Users.Where(g => g.Id == id).FirstOrDefaultAsync();

            if (user is null)
                throw new Exception("Usuario não encontrado");

            _context.Remove(user);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User> Insert(User user)
        {
           if(user is null)
                throw new ArgumentNullException(nameof(user));
           _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Update(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
