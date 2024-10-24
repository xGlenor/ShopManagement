﻿using System.ComponentModel.DataAnnotations;

namespace ShopManagementService.Application.Common.Dtos;

public class LoginUserDto
{
    [Required, EmailAddress] 
    public string? Email { get; set; } = string.Empty;
    
    [Required]
    public string? Password { get; set; } = string.Empty;
    
}