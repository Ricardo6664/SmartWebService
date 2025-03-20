using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartWebService.Domain;
public class User
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
<<<<<<< HEAD
    [MaxLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
    public string Surname { get; set; }
    
    [Required]
    [MaxLength(100, ErrorMessage = "Email address cannot be longer than 100 characters.")]
=======
    [StringLength(50)]
    public string Name { get; set; }
    
    [Required]
    [StringLength(50)]
    public string Surname { get; set; }
    
    [Required]
    [StringLength(100)]
>>>>>>> origin/main
    public string Email { get; set; }
    
    [Required]
    [PasswordPropertyText]
    public string Password { get; set; }
}