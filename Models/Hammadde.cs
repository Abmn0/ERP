using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Hammadde
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string? Kod { get; set; }

        [StringLength(50)]
        public string? Ad { get; set; }

        public ICollection<StokKart>? StokKartlar { get; set; }
    }
}
