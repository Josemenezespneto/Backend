using System;
using Backend.Models;

namespace Backend.Services
{
    public interface IUserService
    {
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> GetById(int id);
        Task<UserModel> GetByEmail(string email);
        Task<UserModel> CreateUser(CreateUserDto user);
        Task<UserModel> UpdateUser(UpdateUserDto user, int id);
        Task<bool> DeleteUser(int id);
    }
}

