using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Marka
    {
        [Key]
        public int Id { get; set; }

        [StringLength(45)]
        public string? Ad { get; set; }

        [StringLength(45)]
        public string? Kod { get; set; }

        // İlişkiler
        public virtual ICollection<MarkaAltGrup>? MarkaAltGruplar { get; set; }
    }
}
