using ClassLibraryModels.DTOs;
using ClassLibraryServer.Interfaces;

namespace ClassLibraryServer.Services
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
