using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class SatinalmaTalepBaslik
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string? SatinalmaTalepNo { get; set; }

        public int? ProjeId { get; set; }

        public int? MalzemeGrupId { get; set; }

        public DateTime? TalepTarihi { get; set; }

        public DateTime? TeslimTarihi { get; set; }
        public int? FirmaId { get; set; }

        [StringLength(150)]
        public string? Aciklama { get; set; }

        public int? TalepEdenKullaniciId { get; set; }
        public virtual Kullanici? TalepEdenKullanici { get; set; }

        public int? OnayKullaniciId { get; set; }
        public virtual Kullanici? OnayKullanici { get; set; }

        public bool? OnayDurum { get; set; }

        public DateTime? OnayTarihi { get; set; }

        public DateTime? CreationTime { get; set; }
        public int? CreatedByUser { get; set; }
        [StringLength(50)]
        public string? CreatedByComputer { get; set; }

        public DateTime? UpdatedTime { get; set; }
        public int? UpdatedByUser { get; set; }
        [StringLength(50)]
        public string? UpdatedByComputer { get; set; }

        // Navigation
        public virtual ICollection<SatinalmaTalepDetay>? Detaylar { get; set; }
        public virtual Firma? Firma { get; set; }


    }
}
