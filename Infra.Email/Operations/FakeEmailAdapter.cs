using Domain.Ports;
using Microsoft.Extensions.Logging;

namespace Infra.Email.Operations
{
    internal class FakeEmailAdapter : IEmailService
    {
        private readonly ILogger<FakeEmailAdapter> _logger;

        public FakeEmailAdapter(ILogger<FakeEmailAdapter> logger)
        {
            _logger = logger;
        }

        public void SendEmail(string from, string to, string subject, string message)
        {
            _logger.LogInformation($"Enviando e-mail: \n De: {from}\n Para:{to}\n Assunto:{subject}\n Mensagem: {message}");
        }
    }
}
