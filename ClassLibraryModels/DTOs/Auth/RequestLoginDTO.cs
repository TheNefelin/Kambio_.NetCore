using System.ComponentModel.DataAnnotations;

namespace ClassLibraryModels.DTOs.Auth
{
    public class RequestLoginDTO
    {
        [EmailAddress]
        [MaxLength(100)]
        public required string Email { get; set; }
    }
}
