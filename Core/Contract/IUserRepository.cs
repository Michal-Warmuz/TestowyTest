using Domain;

namespace Contract.Repository
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(long id);

        Task<IReadOnlyList<User>> GetAllAsync();

        Task<User> AddAsync(User entity);

        Task UpdateAsync(User entity);

        Task DeleteAsync(User entity);

    }
}
