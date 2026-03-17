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
        var userFound = await _userRepository.GetByEmail(user.Email);

        if (userFound != null)
            throw new Exception("Já existe um usuário com esse email");

        return await _userRepository.Add(user);
    }

    public async Task<UserModel> UpdateUser(UserModel user, int id)
    {
        var userFound = await _userRepository.GetById(id);

        if (userFound == null)
            throw new KeyNotFoundException($"Usuário com Id {id} não encontrado");

        if (userFound.Email != user.Email)
        {
            var emailExists = await _userRepository.GetByEmail(user.Email);

            if (emailExists != null)
                throw new Exception("Email já está em uso");
        }

        userFound.Name = user.Name;
        userFound.Email = user.Email;

        return await _userRepository.Update(userFound);
    }

    public async Task<bool> DeleteUser(int id)
    {
        var userFound = await _userRepository.GetById(id);

        if (userFound == null)
            throw new KeyNotFoundException($"Usuário com Id {id} não encontrado");

        return await _userRepository.Delete(userFound);
    }
}