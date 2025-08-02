using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Kullanici
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Kullanıcı Kodu alanı zorunludur.")]
        [StringLength(50)]
        public string Kod { get; set; }

        [StringLength(100)]
        public string Sifre { get; set; }

        [StringLength(100)]
        public string Salt { get; set; }

        // İlişkiler
        public int? PersonelId { get; set; }
        public virtual Personel? Personel { get; set; }

        public int? RolId { get; set; }
        public Rol? Rol { get; set; }

        public bool? IsSifreDegisti { get; set; }

        public DateTime CreationTime { get; set; } = DateTime.Now;

        public int? CreatedByUser { get; set; }

        [StringLength(100)]
        public string? CreatedByComputer { get; set; }

        public DateTime? UpdatedTime { get; set; }

        public int? UpdatedByUser { get; set; }

        [StringLength(100)]
        public string? UpdatedByComputer { get; set; }
    }
}
