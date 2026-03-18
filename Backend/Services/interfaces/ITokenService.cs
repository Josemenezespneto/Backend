using Backend.Models;

public interface ITokenService
{
    string GenerateToken(UserModel user);
}