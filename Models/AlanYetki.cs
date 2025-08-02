using System.ComponentModel.DataAnnotations;

public class AlanYetki
{
    public int Id { get; set; }
    public int AlanId { get; set; }
    public int KullaniciId { get; set; }
    public bool Yetki { get; set; }
    public bool GormeYetki { get; set; }
    public bool DuzenlemeYetki { get; set; }
}


