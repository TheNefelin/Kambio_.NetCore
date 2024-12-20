using ClassLibraryModels.DTOs.Auth;
using ClassLibraryServer.Interfaces;

namespace ClassLibraryServer.Services
{
    public class AuthGoogleService : IAuthGoogleService
    {
        public Task<UserGoogleDTO> AuthenticateAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserGoogleDTO> GetCurrentUserAsync()
        {
            throw new NotImplementedException();
        }

        public Task LogOut()
        {
            throw new NotImplementedException();
        }
    }
}
