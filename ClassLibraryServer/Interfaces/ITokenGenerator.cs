using ClassLibraryModels.DTOs.Auth;

namespace ClassLibraryServer.Interfaces
{
    public interface ITokenGenerator
    {
        public TokenDTO GenerateJwtToken(LogedinDTO logedin, JwtConfigDTO jwtConfig);
    }
}
