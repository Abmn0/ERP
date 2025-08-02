using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class SatinalmaTalepDetay
    {
        [Key]
        public int Id { get; set; }

        public int SatinalmaTalepBaslikId { get; set; }

        public int? StokKartId { get; set; }

        public int? Miktar { get; set; }

        [StringLength(150)]
        public string? Aciklama { get; set; }

        public int? OnayKullaniciId { get; set; }

        public bool? OnayDurum { get; set; }

        public DateTime? OnayTarihi { get; set; }

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
        [ForeignKey("SatinalmaTalepBaslikId")]
        public virtual SatinalmaTalepBaslik? Baslik { get; set; }
        [ForeignKey("StokKartId")]
        public virtual StokKart? StokKart { get; set; }

    }
}
