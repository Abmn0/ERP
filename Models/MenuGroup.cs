using System.ComponentModel.DataAnnotations;

public class MenuGroup
{
    public int Id { get; set; }

    [StringLength(50)]
    public string? Ad { get; set; }

    [StringLength(100)]
    public string? Aciklama { get; set; }

    public int? SiraNo { get; set; }

    public DateTime? CreateDate { get; set; }
    public string? CreatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }
    public string? UpdatedBy { get; set; }
}
