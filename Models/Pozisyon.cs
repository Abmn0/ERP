using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Pozisyon
    {
        [Key]
        public int Id { get; set; }

        [StringLength(45)]
        public string? Ad { get; set; }

        [StringLength(45)]
        public string? Kod { get; set; }

        // Geriye doğru ilişki tanımlanacaksa:
        public ICollection<Personel>? Personeller { get; set; }
    }
}
