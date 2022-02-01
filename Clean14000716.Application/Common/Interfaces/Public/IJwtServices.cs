using Clean14000716.Domain.Entities.Identity;

namespace Clean14000716.Application.Common.Interfaces.Public
{
    public interface IJwtServices
    {
        string GenerateToken(User user);
    }
}