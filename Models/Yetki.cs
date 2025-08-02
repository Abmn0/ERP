using Models;

public class Yetki
{
    public int Id { get; set; }
    public int RolId { get; set; }
    public int MenuId { get; set; }
    public int? EkranId { get; set; }
    public int? AlanId { get; set; }
    public bool DuzenlemeYetki { get; set; }
    public bool GormeYetki { get; set; }

    public DateTime? CreateDate { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string? UpdatedBy { get; set; }

    // ✅ Navigation Properties
    public Rol Rol { get; set; }
    public Menu Menu { get; set; }
    public Ekran? Ekran { get; set; }
    public Alan? Alan { get; set; }

}
