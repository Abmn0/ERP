using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class SatinalmaSiparisDetay
    {
        [Key]
        public int Id { get; set; }

        public int SatinalmaSiparisBaslikId { get; set; }

        public int? StokKartId { get; set; }

        public int? Miktar { get; set; }
        public double? BirimFiyat { get; set; }
        public int? DovizCinsiId { get; set; }

        public double? Kdv { get; set; }

        [StringLength(150)]
        public string? Aciklama { get; set; }

        public DateTime? CreationTime { get; set; }
        public int? CreatedByUser { get; set; }
        [StringLength(50)] public string? CreatedByComputer { get; set; }

        public DateTime? UpdatedTime { get; set; }
        public int? UpdatedByUser { get; set; }
        [StringLength(50)] public string? UpdatedByComputer { get; set; }

        public int? OlcuBirimi { get; set; }

        // Navigation
        [ForeignKey(nameof(SatinalmaSiparisBaslikId))]
        public virtual SatinalmaSiparisBaslik? Baslik { get; set; }

    }
}
