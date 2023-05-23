﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OurInstagram.Models.Login;

public class SignupInput
{
    [Required]
    [EmailAddress]
    [DisplayName("Email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    [DisplayName("Password")]
    public string Password { get; set; }
    
    [Required(ErrorMessage = "*")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    [NotMapped]
    [DisplayName("Confirm Password")]
    public string ConfirmPassword { get; set; }
}