using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class MalzemeAltGrup2
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(MalzemeAltGrup))]
        public int? MalzemeAltGrupId { get; set; }
        public MalzemeAltGrup? MalzemeAltGrup { get; set; }

        [StringLength(50)]
        public string? Kod { get; set; }

        [StringLength(50)]
        public string? Ad { get; set; }

        public bool IsUretim { get; set; }
        public bool PdfVar { get; set; }
        public bool DxfVar { get; set; }
        public bool StepVar { get; set; }

        public ICollection<StokKart>? StokKartlar { get; set; }
    }
}
