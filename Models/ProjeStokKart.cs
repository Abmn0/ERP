using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ProjeStokKart
    {
        [Key]
        public int Id { get; set; }

        public int? ProjeId { get; set; }
        public virtual Proje? Proje { get; set; }

        public int? StokKartId { get; set; }
        public virtual StokKart? StokKart { get; set; }

        public decimal? Miktar { get; set; }
    }
}
