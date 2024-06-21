using System.ComponentModel.DataAnnotations;

namespace GameStore.Frontend.Models;

public class UserDetails
{
    [Required, StringLength(50)]
    [EmailAddress]
    public string? Email { get; set; }

    [Required, StringLength(50)]
     [DataType(DataType.Password)]
    public string? Password { get; set; }
    
    public string TwoFactorCode { get; set; } = "string";
    public string TwoFactorRecoveryCode { get; set; } = "string";
    
}

