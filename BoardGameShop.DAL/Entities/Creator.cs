namespace BoardGameShop.DAL.Entities
{
    public class Creator : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;
    }
}
