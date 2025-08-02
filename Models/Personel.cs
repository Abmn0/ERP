using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Personel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(45)]
        public string? Kod { get; set; }

        [StringLength(45)]
        public string? PersonelAd { get; set; }

        [StringLength(45)]
        public string? PersonelSoyad { get; set; }

        [StringLength(45)]
        public string? Telefon { get; set; }

        [StringLength(45)]
        public string? Mail { get; set; }

        public int? PozisyonId { get; set; }
        public Pozisyon? Pozisyon { get; set; }

        public int? FirmaId { get; set; }
        public Firma? Firma { get; set; }

        public int? PersonelResimId { get; set; }
        public PersonelResim? PersonelResim { get; set; }

        [StringLength(91)]
        public string? Ad { get; set; }

        public int? YoneticiPersonelId { get; set; }

        // Kendi kendine ilişki
        public Personel? Yonetici { get; set; }

        public ICollection<Personel>? BagliPersoneller { get; set; }
    }
}
