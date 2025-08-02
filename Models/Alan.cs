using System.ComponentModel.DataAnnotations;

public class Alan
{
    public int Id { get; set; }
    public int MenuId { get; set; }
    [StringLength(50)]
    public string? AlanAd { get; set; }
}
