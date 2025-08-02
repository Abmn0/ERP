using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class MarkaAltGrupKategori
    {
        [Key]
        public int Id { get; set; }

        public int? MarkaAltGrupId { get; set; }

        [ForeignKey("MarkaAltGrupId")]
        public virtual MarkaAltGrup? MarkaAltGrup { get; set; }

        [StringLength(45)]
        public string? Ad { get; set; }

        [StringLength(45)]
        public string? Kod { get; set; }
    }
}
