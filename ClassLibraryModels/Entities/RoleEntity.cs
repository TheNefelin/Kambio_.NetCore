﻿namespace ClassLibraryModels.Entities
{
    public class RoleEntity
    {
        public int Id { get; set; }
        public string Role { get; set; } = string.Empty;
        public List<UserEntity> Users { get; set; }
    }
}
