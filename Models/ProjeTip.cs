using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ProjeTip
    {
        [Key]
        public int ProjeTipId { get; set; }

        [StringLength(50)]
        public string ProjeTipAd { get; set; }

        // Navigation property (isteğe bağlı)
        public virtual ICollection<Proje>? Projeler { get; set; }
    }
}
 