using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Rol
    {
        [Key]
        public int Id { get; set; }

        [StringLength(45)]
        public string? Ad { get; set; }

        [StringLength(45)]
        public string? Kod { get; set; }

        // Geriye doğru ilişki: Bu rolün kullanıcıları
        public ICollection<Kullanici>? Kullanicilar { get; set; }
    }
}
