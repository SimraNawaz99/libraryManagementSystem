using System;
using System.ComponentModel.DataAnnotations;

public class Admin
{
    [Key]
    public int AdminId { get; set; }

    [Required]
    public string FullName { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    public DateTime CreatedAt { get; set; }
}
