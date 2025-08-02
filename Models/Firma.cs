using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Firma
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string? Kod { get; set; }

        [StringLength(150)]
        public string? Ad { get; set; }

        [StringLength(255)]
        public string? Adres { get; set; }

        public int? SehirId { get; set; }
        public  Sehir? Sehir { get; set; }

        public int? UlkeId { get; set; }
        public  Ulke? Ulke { get; set; }

        [StringLength(100)]
        public string? VergiDairesi { get; set; }

        public int? LogoFirmaId { get; set; }

        [StringLength(50)]
        public string? LogoCariKod { get; set; }

        [StringLength(45)]
        public string? VergiNo { get; set; }

        [StringLength(45)]
        public string? Telefon { get; set; }

        [StringLength(45)]
        public string? Faks { get; set; }

        [StringLength(45)]
        public string? Mail { get; set; }

        [StringLength(45)]
        public string? PostaKodu { get; set; }

        // Geriye doğru ilişki: Bir firmanın birden fazla personeli olabilir
        public ICollection<Personel>? Personeller { get; set; }
    }
}
