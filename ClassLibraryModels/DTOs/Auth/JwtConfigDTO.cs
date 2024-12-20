﻿namespace ClassLibraryModels.DTOs.Auth
{
    public class JwtConfigDTO
    {
        public required string Key { get; set; }
        public required string Issuer { get; set; }
        public required string Audience { get; set; }
        public required int ExpireMin { get; set; }
    }
}
