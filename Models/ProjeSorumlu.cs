using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ProjeSorumlu
    {
        [Key]
        public int Id { get; set; }

        public int? ProjeId { get; set; }
        public virtual Proje? Proje { get; set; }

        public int? PersonelId { get; set; }
        public virtual Personel? Personel { get; set; }

        [StringLength(100)]
        public string? Gorev { get; set; }
    }
}
