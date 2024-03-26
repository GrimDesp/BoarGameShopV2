namespace BoardGameShop.Api.Entities
{
    public class Creator : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;
    }
}
