using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ProjeTakvim
    {
        [Key]
        public int ProjeTakvimId { get; set; }

        public int? ProjeId { get; set; }
        public virtual Proje? Proje { get; set; }

        public int? ProjeSurecId { get; set; }
        public virtual ProjeSurecTanim? ProjeSurec { get; set; }

        public DateTime? PlanlananBaslangicTarihi { get; set; }

        public DateTime? PlanlananBitisTarihi { get; set; }

        public DateTime? GerceklesenBaslangicTarihi { get; set; }

        public DateTime? GerceklesenBitisTarihi { get; set; }
    }
}
