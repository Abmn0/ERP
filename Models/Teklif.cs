using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Teklif
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string? No { get; set; }

        public DateTime? Tarih { get; set; }

        public int? SatisSorumluId { get; set; }
        public int? FirmaId { get; set; }

        [StringLength(255)]
        public string? Konusu { get; set; }

        public int? MarkaId { get; set; }
        public int? AltGrupId { get; set; }

        public int? OngoruMaliyeti { get; set; }
        public int? OngoruMaliyetDovizCinsi { get; set; }

        public double? TeklifTutari { get; set; }
        public int? TeklifTutariDovizCinsi { get; set; }

        // Navigation
        public virtual ICollection<TeklifMaliyetDetay>? MaliyetDetaylari { get; set; }
        public virtual ICollection<TeklifSurec>? Surecler { get; set; }
    }
}
