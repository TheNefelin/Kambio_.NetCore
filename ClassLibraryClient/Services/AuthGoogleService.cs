using ClassLibraryClient.Interfaces;
using ClassLibraryModels.DTOs.Auth;

namespace ClassLibraryClient.Services
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
