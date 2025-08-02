using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class TeklifSurecTanim
    {
        [Key]
        public int TeklifSurecTanimId { get; set; }

        [StringLength(255)]
        public string? TeklifSurecTanimAdi { get; set; }

        public int? VarsayilanSorumluPozisyon { get; set; }
        public int? Sure { get; set; }

        // Navigation
        public virtual ICollection<TeklifSurec>? Surecler { get; set; }
    }
}
