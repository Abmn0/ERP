using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class TeklifMaliyetDetay
    {
        [Key]
        public int Id { get; set; }

        public int TeklifId { get; set; }

        public int? MaliyetUnsuru { get; set; }
        public int? MaliyetTespitKanali { get; set; }

        public int? OngorulenMaliyet { get; set; }

        public int? DovizCinsiId { get; set; }

        public string? Belge { get; set; }

        // Navigation
        [ForeignKey("TeklifId")]
        public virtual Teklif? Teklif { get; set; }
    }
}
