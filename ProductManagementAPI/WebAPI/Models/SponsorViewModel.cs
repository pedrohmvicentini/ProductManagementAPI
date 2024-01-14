namespace WebAPI.Models
{
    public class SponsorViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; } = string.Empty;

        public string Document { get; set; } = string.Empty;

        public bool Active { get; set; } = true;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public string UserId { get; set; }
    }
}
