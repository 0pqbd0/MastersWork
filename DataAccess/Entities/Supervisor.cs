using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

public class Supervisor
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
    public string StEmail { get; set; }
    
    [ForeignKey("Department")]
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
}