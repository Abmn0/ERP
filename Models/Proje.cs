using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Proje
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        public string? Kod { get; set; }

        [StringLength(150)]
        public string? Ad { get; set; }

        public int? ProjeTipId { get; set; }
        public int? MarkaId { get; set; }
        public int? ProjeNo { get; set; }
        public int? AltGrupId { get; set; }
        public int? KategoriId { get; set; }

        [StringLength(500)]
        public string? Aciklama { get; set; }
        public string? FilePaths { get; set; }

        public int? SatisSiparisId { get; set; }

        // Navigation Properties
        [ForeignKey("ProjeTipId")]
        public ProjeTip? ProjeTip { get; set; }

        [ForeignKey("MarkaId")]
        public Marka? Marka { get; set; }

        [ForeignKey("AltGrupId")]
        public MarkaAltGrup? AltGrup { get; set; }

        [ForeignKey("KategoriId")]
        public MarkaAltGrupKategori? Kategori { get; set; }

        [ForeignKey("SatisSiparisId")]
        public SatisSiparis? SatisSiparis { get; set; }

        // Logo ve ProjeNo için tablo varsa burada eklenebilir
        // public Logo? Logo { get; set; }
        // public ProjeNo? ProjeNo { get; set; }
    }
}
