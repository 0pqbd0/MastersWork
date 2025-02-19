using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities;

public class Role
{
    [Key]
    public int Id { get; set; }
    
    [MaxLength(50)]
    public string Name { get; set; }

}