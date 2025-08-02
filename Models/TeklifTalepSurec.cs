using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class TeklifTalepSurec
    {
        [Key]
        public int TeklifTalepSurecId { get; set; }

        public int TeklifTalepSurecTanimId { get; set; }

        public int TeklifTalepId { get; set; }

        public DateTime? BaslamaZamani { get; set; }

        public int? Sure { get; set; }

        public DateTime? BitisZamani { get; set; }

        public int? SorumluKullaniciId { get; set; }

        // Navigation
        [ForeignKey("TeklifTalepId")]
        public virtual TeklifTalep? TeklifTalep { get; set; }

        [ForeignKey("TeklifTalepSurecTanimId")]
        public virtual TeklifTalepSurecTanim? SurecTanim { get; set; }
    }
}
