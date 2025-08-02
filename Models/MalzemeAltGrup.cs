using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class MalzemeAltGrup
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(MalzemeGrup))]
        public int? MalzemeGrupId { get; set; }
        public MalzemeGrup? MalzemeGrup { get; set; }

        [StringLength(50)]
        public string? Kod { get; set; }

        [StringLength(50)]
        public string? Ad { get; set; }

        public bool PdfVar { get; set; }
        public bool DxfVar { get; set; }
        public bool StepVar { get; set; }

        public ICollection<MalzemeAltGrup2>? MalzemeAltGrup2ler { get; set; }
        public ICollection<StokKart>? StokKartlar { get; set; }
    }
}
