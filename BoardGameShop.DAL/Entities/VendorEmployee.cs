namespace BoardGameShop.DAL.Entities
{
    public class VendorEmployee
    {
        [Required]
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User UserNavigation { get; set; }
        [Required]
        public int VendorId { get; set; }
        [ForeignKey(nameof(VendorId))]
        public Vendor VendorNavigation { get; set; }
    }
}
