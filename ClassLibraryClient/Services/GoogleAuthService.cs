using ClassLibraryClient.Interfaces;
using ClassLibraryModels.DTOs;

namespace ClassLibraryClient.Services
{
    public class GoogleAuthService : IGoogleAuthService
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
