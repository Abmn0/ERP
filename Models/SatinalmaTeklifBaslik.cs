using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class SatinalmaTeklifBaslik
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string? TeklifNo { get; set; }

        public int? ProjeId { get; set; }
        public int? ParcaGrupId { get; set; }

        public DateTime? TeklifTalepTarihi { get; set; }
        public int? TerminSuresi { get; set; }
        public DateTime? TeklifTarihi { get; set; }

        public int? FirmaId { get; set; }
        public int? OdemeVadeId { get; set; }

        [StringLength(150)]
        public string? Aciklama { get; set; }

        public double? Tutar { get; set; }
        public int? DovizCinsiId { get; set; }

        public int? TeklifGecerlilikSuresi { get; set; }
        public int? TeklifTalepSurecId { get; set; }

        public DateTime? CreationTime { get; set; }
        public int? CreatedByUser { get; set; }
        [StringLength(50)]
        public string? CreatedByComputer { get; set; }

        public DateTime? UpdatedTime { get; set; }
        public int? UpdatedByUser { get; set; }
        [StringLength(50)]
        public string? UpdatedByComputer { get; set; }

        // Navigation
        public virtual ICollection<SatinalmaTeklifDetay>? Detaylar { get; set; }
    }
}
