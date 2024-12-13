using ClassLibraryModels.DTOs;

namespace ClassLibraryClient.Interfaces
{
    public interface IGoogleAuthService
    {
        public Task<UserGoogleDTO> AuthenticateAsync();
        public Task<UserGoogleDTO> GetCurrentUserAsync();
        public Task LogOut();
    }
}
