using System;
using Backend.Models;

namespace Backend.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAll();
        Task<UserModel> GetById(int id);
        Task<UserModel> GetByEmail(string email);
        Task<UserModel> Add(UserModel user);
        Task<UserModel> Update(UserModel user);
        Task<bool> Delete(UserModel user);
    }
}

