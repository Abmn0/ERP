using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class SatinalmaTeklifDetay
    {
        [Key]
        public int Id { get; set; }

        public int SatinalmaTeklifBaslikId { get; set; }
        public int? SatinalmaTalepDetayId { get; set; }

        public int? StokKartId { get; set; }

        public int? Miktar { get; set; }
        public double? BirimFiyat { get; set; }
        public int? DovizCinsiId { get; set; }

        [StringLength(150)]
        public string? Aciklama { get; set; }

        public double? Kdv { get; set; }

        public DateTime? CreationTime { get; set; }
        public int? CreatedByUser { get; set; }
        [StringLength(50)]
        public string? CreatedByComputer { get; set; }

        public DateTime? UpdatedTime { get; set; }
        public int? UpdatedByUser { get; set; }
        [StringLength(150)]
        public string? UpdatedByComputer { get; set; }

        public int? OlcuBirimi { get; set; }

        // Navigation
        [ForeignKey("SatinalmaTeklifBaslikId")]
        public virtual SatinalmaTeklifBaslik? Baslik { get; set; }
    }
}
