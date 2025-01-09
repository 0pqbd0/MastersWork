using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities;

public class Student
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string SecondName { get; set; }
    
    [MaxLength(100)]
    public string? MiddleName { get; set; }
    
    [Required]
    [EmailAddress]
    [MaxLength(200)]
    public string StEmail { get; set; }
    
    [MaxLength(200)]
    public string? TelegramLink { get; set; }
}
