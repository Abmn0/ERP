using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class PersonelResim
    {
        [Key]
        public int PersonelResimId { get; set; }

        public int PersonelId { get; set; }

        [ForeignKey(nameof(PersonelId))]
        public Personel Personel { get; set; }

        public byte[]? ResimData { get; set; }

        [StringLength(45)]
        public string? ImageFormat { get; set; }
    }
}
