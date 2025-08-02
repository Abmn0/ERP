using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Sehir
    {
        [Key]
        public int Id { get; set; }

        public int? Kod { get; set; }

        [StringLength(100)]
        public string? Ad { get; set; }

        public int? UlkeId { get; set; }
        public Ulke? Ulke { get; set; }

        // Geriye doğru ilişkiler (İsteğe bağlı)
        public ICollection<Firma>? Firmalar { get; set; }
    }
}
