using System;
using Backend.Data;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _dbContext;

		public UserRepository(DatabaseContext databaseContext)
		{
            _dbContext = databaseContext;
		}

        public async Task<List<User>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task<User> AddUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<User> Update(User user, int id)
        {
            User userId = await GetById(id);

            if(userId == null)
            {
                throw new Exception($"Usuário para o Id: {id} não foi encontrado");
            }

            userId.Name = user.Name;
            userId.Email = user.Email;

            _dbContext.Users.Update(userId);
            await _dbContext.SaveChangesAsync();

            return userId;
        }

        public async Task<bool> Delete(int id)
        {
            User userId = await GetById(id);

            if (userId == null)
            {
                throw new Exception($"Usuário para o Id: {id} não foi encontrado");
            }

            _dbContext.Users.Remove(userId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}

