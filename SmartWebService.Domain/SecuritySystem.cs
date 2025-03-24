using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartWebService.Domain;

public class SecuritySystem
{
    [Key]
    public int ID { get; set; }
    
    [ForeignKey("User")]
    public int UserID { get; set; }
    
    public virtual User User { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string NameSystem { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Description {get; set;}
    
    [Required]
    public int Camera { get; set; }
}