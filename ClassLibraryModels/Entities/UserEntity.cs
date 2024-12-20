namespace ClassLibraryModels.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? AuthHash { get; set; }
        public string? AuthSalt { get; set; }
        public string? GoogleToken { get; set; }
        public string? AppleToken { get; set; }
        public string? SqlToken { get; set; }
        public int RoleId { get; set; }
        public RoleEntity Role { get; set; }
    }
}
