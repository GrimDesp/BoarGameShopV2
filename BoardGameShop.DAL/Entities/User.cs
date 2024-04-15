namespace BoardGameShop.DAL.Entities
{
    public class User : BaseEntity
    {
        public Role UserRole { get; set; } = Role.User;
        [StringLength(50)]
        [Required]
        public string Username { get; set; } = string.Empty;
        [StringLength(50)]
        public string Email { get; set; } = string.Empty;
        [StringLength(50)]
        public string? FirstName { get; set; }
        [StringLength(50)]
        public string? SecondName { get; set; }
        [StringLength(50)]
        public string? LastName { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
        [StringLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
