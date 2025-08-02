using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class TeklifSurec
    {
        [Key]
        public int TeklifSurecId { get; set; }

        public int TeklifSurecTanimId { get; set; }
        public int TeklifId { get; set; }

        public DateTime? BaslamaZamani { get; set; }
        public int? Sure { get; set; }

        public DateTime? BitisZamani { get; set; }

        public int? SorumluKullaniciId { get; set; }

        // Navigation
        [ForeignKey("TeklifId")]
        public virtual Teklif? Teklif { get; set; }

        [ForeignKey("TeklifSurecTanimId")]
        public virtual TeklifSurecTanim? SurecTanim { get; set; }
    }
}
