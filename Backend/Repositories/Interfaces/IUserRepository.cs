using System;
using Backend.Models;

namespace Backend.Repositories.Interfaces
{
	public interface IUserRepository
	{
		Task<List<UserModel>> GetAllUsers();

		Task<UserModel> GetById(int id);

		Task<UserModel> AddUser(UserModel user);

		Task<UserModel> Update(UserModel user, int id);

		Task<bool> Delete(int id);

	}
}

