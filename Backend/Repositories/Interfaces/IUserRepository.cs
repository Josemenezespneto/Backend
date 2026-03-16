using System;
using Backend.Models;

namespace Backend.Repositories.Interfaces
{
	public interface IUserRepository
	{
		Task<List<User>> GetAllUsers();

		Task<User> GetById(int id);

		Task<User> AddUser(User user);

		Task<User> Update(User user, int id);

		Task<bool> Delete(int id);

	}
}

