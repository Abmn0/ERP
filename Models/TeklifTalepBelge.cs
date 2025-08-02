using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class TeklifTalepBelge
    {
        [Key]
        public int Id { get; set; }

        public int TeklifTalepId { get; set; }

        [StringLength(255)]
        public string? BelgeAd { get; set; }

        [StringLength(255)]
        public string? DosyaAd { get; set; }

        [StringLength(255)]
        public string? DosyaUzanti { get; set; }

        public string? DosyaVeri { get; set; }

        public double? DosyaBoyut { get; set; }

        // Navigation
        [ForeignKey("TeklifTalepId")]
        public virtual TeklifTalep? TeklifTalep { get; set; }
    }
}
