﻿namespace ClassLibraryModels.DTOs.Auth
{
    public class UserGoogleDTO
    {
        public string TokenId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}