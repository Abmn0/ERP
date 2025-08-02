using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class SatinalmaSiparisBaslik
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string? SiparisNo { get; set; }

        public int? ProjeId { get; set; }
        public int? ParcaGrupId { get; set; }

        public DateTime? SiparisTarihi { get; set; }
        public DateTime? TeslimTarihi { get; set; }

        public int? FirmaId { get; set; }
        public int? OdemeVadeId { get; set; }

        [StringLength(150)]
        public string? Aciklama { get; set; }

        public double? Tutar { get; set; }
        public int? DovizCinsiId { get; set; }

        public DateTime? CreationTime { get; set; }
        public int? CreatedByUser { get; set; }
        [StringLength(50)] public string? CreatedByComputer { get; set; }

        public DateTime? UpdatedTime { get; set; }
        public int? UpdatedByUser { get; set; }
        [StringLength(50)] public string? UpdatedByComputer { get; set; }

        // Navigation property
        public virtual ICollection<SatinalmaSiparisDetay>? Detaylar { get; set; }
    }
}
