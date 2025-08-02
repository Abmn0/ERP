using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class SatisSiparis
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string SiparisNo { get; set; }

        public DateTime? SiparisTarihi { get; set; }

        public DateTime? TeslimTarihi { get; set; }

        public double? SiparisTutari { get; set; }

        public double? OngoruMaliyeti { get; set; }

        public double? Kdv { get; set; }

    }
}
