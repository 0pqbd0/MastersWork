using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities;

public class Consultant
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }
    
    [MaxLength(100)]
    public string? MiddleName { get; set; }
    
    [Required]
    [EmailAddress]
    [MaxLength(200)]
    public string Email { get; set; }
    
    [MaxLength(100)]
    public string? Department { get; set; }
    
    [MaxLength(100)]
    public string? CompanyName { get; set; } 
}