using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartWebService.Domain;
public class User
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public string Name { get; set; }
    
    [Required]
    [StringLength(50)]
    public string Surname { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Email { get; set; }
    
    [Required]
    [PasswordPropertyText]
    public string Password { get; set; }
}