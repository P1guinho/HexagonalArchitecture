using Domain.Entities;

namespace Domain.Ports
{
    public interface IUserRepository
    {

        Task<IEnumerable<User>> GetAll();

        Task<User> Insert(User user);

        Task<User> Update(User user);

        Task<bool> Delete(Guid id);
    }
}
