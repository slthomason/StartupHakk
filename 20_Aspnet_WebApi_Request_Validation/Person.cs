using System.ComponentModel.DataAnnotations;

public class Person
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    [MinLength(4)]
    public string? Name { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    public String? Address1 { get; set; }
    
    public String? Address2 { get; set; }
    
    [Required]
    [VatValidator]
    public int? VAT { get; set; }
}  