using ClassLibraryModels.DTOs.Auth;
using ClassLibraryModels.DTOs;

namespace ClassLibraryServer.Interfaces
{
    public interface IAuthService
    {
        public Task<ResponseApiDTO<TokenDTO>> LoginAsync(RequestLoginDTO loginDTO, JwtConfigDTO jwtConfigDTO, CancellationToken cancellationToken);
    }
}
