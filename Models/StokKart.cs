using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class StokKart
    {
        [Key]
        public int Id { get; set; }

        [StringLength(150)]
        public string? Kod { get; set; }

        [StringLength(150)]
        public string? ParcaKod { get; set; }

        [StringLength(500)]
        public string? Ad { get; set; }

        [StringLength(200)]
        public string? ParcaAdi { get; set; }

        [StringLength(50)]
        public string? Boyut { get; set; }

        [StringLength(150)]
        public string? Malzeme { get; set; }

        [StringLength(255)]
        public string? Aciklama { get; set; }

        public double? Agirlik { get; set; }
        public double? Boy { get; set; }
        public double? En { get; set; }
        public double? Yukseklik { get; set; }
        public double? Uzunluk { get; set; }
        public double? Cap { get; set; }
        public double? EtKalınligi { get; set; }

        // Foreign Key - Navigation Properties
        public int? StokGrupId { get; set; }
        [ForeignKey(nameof(StokGrupId))]
        public StokGrup? StokGrup { get; set; }

        public int? StokTipId { get; set; }
        [ForeignKey(nameof(StokTipId))]
        public StokTip? StokTip { get; set; }

        public int? MalzemeGrupId { get; set; }
        [ForeignKey(nameof(MalzemeGrupId))]
        public MalzemeGrup? MalzemeGrup { get; set; }

        public int? MalzemeAltGrupId { get; set; }
        [ForeignKey(nameof(MalzemeAltGrupId))]
        public MalzemeAltGrup? MalzemeAltGrup { get; set; }

        public int? MalzemeAltGrup2Id { get; set; }
        [ForeignKey(nameof(MalzemeAltGrup2Id))]
        public MalzemeAltGrup2? MalzemeAltGrup2 { get; set; }

        public int? OlcuBirimId { get; set; }
        [ForeignKey(nameof(OlcuBirimId))]
        public OlcuBirim? OlcuBirim { get; set; }

        public int? MalzemeStandartId { get; set; }
        [ForeignKey(nameof(MalzemeStandartId))]
        public MalzemeStandart? MalzemeStandart { get; set; }

        public int? HammaddeId { get; set; }
        [ForeignKey(nameof(HammaddeId))]
        public Hammadde? Hammadde { get; set; }

        public bool IsFromExcel { get; set; }

        public DateTime CreationTime { get; set; } = DateTime.Now;
        public int? CreatedByUser { get; set; }

        [StringLength(50)]
        public string? CreatedByComputer { get; set; }

        public DateTime? UpdatedTime { get; set; }
        public int? UpdatedByUser { get; set; }

        [StringLength(50)]
        public string? UpdatedByComputer { get; set; }
    }
}
