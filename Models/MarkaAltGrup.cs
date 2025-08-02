using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class MarkaAltGrup
    {
        [Key]
        public int Id { get; set; }

        public int? MarkaId { get; set; }

        [ForeignKey("MarkaId")]
        public virtual Marka? Marka { get; set; }

        [StringLength(45)]
        public string? Ad { get; set; }

        [StringLength(45)]
        public string? Kod { get; set; }

        // İlişkiler
        public virtual ICollection<MarkaAltGrupKategori>? MarkaAltGrupKategoriler { get; set; }
    }
}
