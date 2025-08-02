using System.ComponentModel.DataAnnotations;

public class Menu
{
    public int Id { get; set; }
    public int? SiraNo { get; set; }
    [StringLength(50)]
    public string? Ad { get; set; }
    [StringLength(100)]
    public string? FormAd { get; set; }
    [StringLength(100)]
    public string? Model { get; set; }
    [StringLength(50)]
    public string? Icon { get; set; }
    public int? MenuGroupId { get; set; }
    public MenuGroup? MenuGroup { get; set; }
    public DateTime? CreateDate { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string? UpdatedBy { get; set; }
}
