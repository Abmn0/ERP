using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ProjeSurecTanim
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Ad { get; set; }

        [StringLength(250)]
        public string? Aciklama { get; set; }
    }
}
