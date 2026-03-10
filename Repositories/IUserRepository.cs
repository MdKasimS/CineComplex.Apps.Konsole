using CineComplex.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineComplex.Repositories
{
    /// <summary>
    /// Repository interface for User entity operations.
    /// Matches project style: supports EFCore now and can be swapped for other implementations.
    /// </summary>
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByUsernameAsync(string username);
        Task<User> GetUserWithProfileAsync(int id);

        Task<User> AddAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteAsync(User user);
        Task<bool> ExistsAsync(int id);
        Task<int> GetCountAsync();

        // Authentication / lookup helpers
        Task<User> GetByEmailOrUsernameAsync(string login);
    }
}