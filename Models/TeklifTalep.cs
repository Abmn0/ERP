using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class TeklifTalep
    {
        [Key]
        public int Id { get; set; }

        public DateTime? TeklifTalepTarihi { get; set; }

        public int? SatisSorumlusuId { get; set; }
        public int? FirmaId { get; set; }

        [StringLength(255)]
        public string? TeklifKonusu { get; set; }

        public int? MarkaId { get; set; }
        public int? AltGrupId { get; set; }
        public int? KategoriId { get; set; }

        public int? ReferansKaynakId { get; set; }

        public bool? IsTeklifSave { get; set; }

        public int? MaliyetSorumluId { get; set; }
        public DateTime? MaliyetSorumluAtamaTarihi { get; set; }

        public bool? IsMaliyetTamamlandi { get; set; }
        public bool? IsMaliyetOnaylandi { get; set; }

        public double? TeklifFiyati { get; set; }
        public int? TeklifFiyatDovizId { get; set; }

        public int? FinansalTakvimId { get; set; }

        public DateTime? TeklifTarihi { get; set; }

        [StringLength(50)]
        public string? TeklifNo { get; set; }

        [StringLength(50)]
        public string? TeslimBilgileri { get; set; }

        public int? TeklifSuresi { get; set; }

        [StringLength(50)]
        public string? TeslimSuresi { get; set; }

        public bool? IsMaliyetTalep { get; set; }

        // Navigation
        public virtual ICollection<TeklifTalepBelge>? Belgeler { get; set; }
        public virtual ICollection<TeklifTalepSurec>? Surecler { get; set; }
    }
}
