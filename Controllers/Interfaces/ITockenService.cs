// Interface for the Token  
using API.Entities;

namespace API.Services;

public interface ITokenService
{
    string CreateToken(appUser user);
}