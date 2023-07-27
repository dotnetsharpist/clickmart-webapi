using ClickMart.Domain.Entities.Users;

namespace ClickMart.Service.Interfaces.Auth;

public interface ITokenService
{
    public string GenerateToken(User user);
}
