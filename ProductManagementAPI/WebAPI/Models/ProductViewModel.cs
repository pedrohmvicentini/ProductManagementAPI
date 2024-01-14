namespace WebAPI.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; } = string.Empty;

        public DateTime BestBeforeAt { get; set; }

        public DateTime ManufacturingDate { get; set; }

        public bool Active { get; set; } = true;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public int SponsorId { get; set; }

        public string UserId { get; set; }
    }
}
