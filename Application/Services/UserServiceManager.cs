using Domain.Entities;
using Domain.Ports;

namespace Application.Services
{
    public class UserServiceManager : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailAdapter;

        public UserServiceManager(IUserRepository userRepository, IEmailService emailAdapter)
        {
            _userRepository = userRepository;
            _emailAdapter = emailAdapter;
        }

        public async Task<User> AddNewUserAsync(User user)
        {
            await _userRepository.Insert(user);
            _emailAdapter.SendEmail("guilherme@hotmail.com", "teste@email.com", "Teste de email", "Usuário inserido");
            return user;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            var userUpdated = await _userRepository.Update(user);

            _emailAdapter.SendEmail("guilherme@hotmail.com", "teste@email.com", "Teste de email", "Usuário Atualizado");
            return userUpdated;
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            if(await _userRepository.Delete(id))
            {
                _emailAdapter.SendEmail("guilherme@hotmail.com", "teste@email.com", "Teste de email", "Usuário Deletado");
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAll();
        }
    }
}
