using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities;

public class Department
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
}