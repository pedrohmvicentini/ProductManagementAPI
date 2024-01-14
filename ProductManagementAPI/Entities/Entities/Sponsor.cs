using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    [Table("TB_SPONSOR")]
    public class Sponsor : Notifies
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Description")]
        public string Description { get; set; } = string.Empty;

        [Column("Document")]
        public string Document { get; set; } = string.Empty;

        [Column("Active")]
        public bool Active { get; set; } = true;

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [Column("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }

        [Column("DeletedAt")]
        public DateTime DeletedAt { get; set; }


        [ForeignKey("ApplicationUser")]
        [Column(Order = 1)]
        public string UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
