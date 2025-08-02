public class Ekran
{
    public int Id { get; set; }
    public string Ad { get; set; } = string.Empty; // ← Ekran adı
    public int? SiraNo { get; set; }
    public int MenuId { get; set; }
    public int? AltMenuId { get; set; }

    public DateTime? CreateDate { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string? UpdatedBy { get; set; }
}
