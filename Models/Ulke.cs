using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Ulke
    {
        [Key]
        public int Id { get; set; }

        [StringLength(150)]
        public string? Kod { get; set; }

        [StringLength(150)]
        public string? Ad { get; set; }

        // Geriye doğru ilişkiler (isteğe bağlı)
        public ICollection<Sehir>? Sehirler { get; set; }
        public ICollection<Firma>? Firmalar { get; set; }
    }
}
