using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartWebService.Domain;
public class User
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
    public string Surname { get; set; }
    
    [Required]
    [MaxLength(100, ErrorMessage = "Email address cannot be longer than 100 characters.")]
    public string Email { get; set; }
    
    [Required]
    [PasswordPropertyText]
    public string Password { get; set; }
}