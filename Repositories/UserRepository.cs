using CineComplex.Classes.Base;
using CineComplex.Classes.SQL;
using CineComplex.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineComplex.Repositories
{
    /// <summary>
    /// EFCore-backed repository for `User` entity.
    /// Implements singleton pattern consistent with the project.
    /// </summary>
    public class UserRepository : ABaseSingleton<UserRepository>, IUserRepository
    {
        public UserRepository() { }

        private CineComplexDb Context => SQLInteraction.Db;

        public async Task<List<User>> GetAllAsync()
        {
            try
            {
                return await Context.Users.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving users: {ex.Message}");
                throw;
            }
        }

        public async Task<User> GetByIdAsync(int id)
        {
            try
            {
                if (id <= 0) throw new ArgumentException("User ID must be greater than 0.");
                return await Context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving user by id {id}: {ex.Message}");
                throw;
            }
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email cannot be empty.");
                return await Context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving user by email '{email}': {ex.Message}");
                throw;
            }
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username)) throw new ArgumentException("Username cannot be empty.");
                return await Context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Username == username);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving user by username '{username}': {ex.Message}");
                throw;
            }
        }

        public async Task<User> GetUserWithProfileAsync(int id)
        {
            try
            {
                if (id <= 0) throw new ArgumentException("User ID must be greater than 0.");
                return await Context.Users.AsNoTracking().Include(u => u.UserProfile).FirstOrDefaultAsync(u => u.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving user with profile (ID {id}): {ex.Message}");
                throw;
            }
        }

        public async Task<User> AddAsync(User user)
        {
            try
            {
                if (user == null) throw new ArgumentNullException(nameof(user));
                if (string.IsNullOrWhiteSpace(user.Username)) throw new ArgumentException("Username is required.");
                if (string.IsNullOrWhiteSpace(user.Email)) throw new ArgumentException("Email is required.");

                Context.Users.Add(user);
                await Context.SaveChangesAsync();

                return user;
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Database error while adding user: {dbEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding user: {ex.Message}");
                throw;
            }
        }

        public async Task<User> UpdateAsync(User user)
        {
            try
            {
                if (user == null) throw new ArgumentNullException(nameof(user));
                if (user.Id <= 0) throw new ArgumentException("User ID must be valid.");

                var existing = await Context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
                if (existing == null) throw new KeyNotFoundException($"User with ID {user.Id} not found.");

                Context.Entry(existing).CurrentValues.SetValues(user);
                await Context.SaveChangesAsync();

                return existing;
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Database error while updating user: {dbEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating user: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                if (id <= 0) throw new ArgumentException("User ID must be greater than 0.");

                var user = await Context.Users.FirstOrDefaultAsync(u => u.Id == id);
                if (user == null) return false;

                Context.Users.Remove(user);
                await Context.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Database error while deleting user: {dbEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting user with ID {id}: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> DeleteAsync(User user)
        {
            try
            {
                if (user == null) throw new ArgumentNullException(nameof(user));

                var toDelete = await Context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
                if (toDelete == null) return false;

                Context.Users.Remove(toDelete);
                await Context.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Database error while deleting user: {dbEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting user: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            try
            {
                if (id <= 0) throw new ArgumentException("User ID must be greater than 0.");
                return await Context.Users.AnyAsync(u => u.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking if user exists: {ex.Message}");
                throw;
            }
        }

        public async Task<int> GetCountAsync()
        {
            try
            {
                return await Context.Users.CountAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving user count: {ex.Message}");
                throw;
            }
        }

        public async Task<User> GetByEmailOrUsernameAsync(string login)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(login)) throw new ArgumentException("Login cannot be empty.");

                return await Context.Users.AsNoTracking()
                    .FirstOrDefaultAsync(u => u.Email == login || u.Username == login);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving user by login '{login}': {ex.Message}");
                throw;
            }
        }
    }
}