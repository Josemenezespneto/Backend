using Backend.Models;
using Backend.Repositories.Interfaces;
using Backend.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<UserModel>> GetAllUsers()
    {
        return await _userRepository.GetAll();
    }

    public async Task<UserModel> GetById(int id)
    {
        var user = await _userRepository.GetById(id);

        if (user == null)
            throw new KeyNotFoundException($"Usuário com Id {id} não encontrado");

        return user;
    }

    public async Task<UserModel> CreateUser(UserModel user)
    {
        var existingUser = await _userRepository.GetByEmail(user.Email);

        if (existingUser != null)
            throw new Exception("Já existe um usuário com esse email");

        return await _userRepository.Add(user);
    }

    public async Task<UserModel> UpdateUser(UserModel user, int id)
    {
        var existingUser = await _userRepository.GetById(id);

        if (existingUser == null)
            throw new KeyNotFoundException($"Usuário com Id {id} não encontrado");

        if (existingUser.Email != user.Email)
        {
            var emailExists = await _userRepository.GetByEmail(user.Email);

            if (emailExists != null)
                throw new Exception("Email já está em uso");
        }

        existingUser.Name = user.Name;
        existingUser.Email = user.Email;

        return await _userRepository.Update(existingUser);
    }

    public async Task<bool> DeleteUser(int id)
    {
        var user = await _userRepository.GetById(id);

        if (user == null)
            throw new KeyNotFoundException($"Usuário com Id {id} não encontrado");

        return await _userRepository.Delete(user);
    }
}