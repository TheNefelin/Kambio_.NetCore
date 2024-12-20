namespace ClassLibraryModels.DTOs.Auth
{
    public class LogedinDTO
    {
        public required Guid Id { get; set; }
        public required string Email { get; set; }
        public required string Role { get; set; }
    }
}
