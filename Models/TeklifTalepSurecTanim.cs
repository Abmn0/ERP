using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class TeklifTalepSurecTanim
    {
        [Key]
        public int TeklifTalepSurecTanimId { get; set; }

        [StringLength(255)]
        public string? Aciklama { get; set; }

        public int? VarsayilanSorumluPozisyon { get; set; }

        public int? Sure { get; set; }

        public int? Ekran { get; set; }

        // Navigation
        public virtual ICollection<TeklifTalepSurec>? Surecler { get; set; }
    }
}
