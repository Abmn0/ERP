using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class MalzemeGrup
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(StokGrup))]
        public int? StokGrupId { get; set; }
        public StokGrup? StokGrup { get; set; }

        [StringLength(50)]
        public string? Kod { get; set; }

        [StringLength(50)]
        public string? Ad { get; set; }

        public bool PdfVar { get; set; }
        public bool DxfVar { get; set; }
        public bool StepVar { get; set; }

        public ICollection<MalzemeAltGrup>? MalzemeAltGruplar { get; set; }
        public ICollection<StokKart>? StokKartlar { get; set; }
    }
}
