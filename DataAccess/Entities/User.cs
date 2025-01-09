using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

public class User
{
    [Key]
    public int Id { get; set; }
    
    [MaxLength(50)]
    public string Username { get; set; }
    
    [MaxLength(255)]
    public string PasswordHash { get; set; }
    
    [ForeignKey("Role")]
    public int RoleId { get; set; }
    public Role Role { get; set; }
}