using ClassLibraryModels.DTOs.Auth;

namespace ClassLibraryClient.Interfaces
{
    public interface IAuthGoogleService
    {
        public Task<UserGoogleDTO> AuthenticateAsync();
        public Task<UserGoogleDTO> GetCurrentUserAsync();
        public Task LogOut();
    }
}
