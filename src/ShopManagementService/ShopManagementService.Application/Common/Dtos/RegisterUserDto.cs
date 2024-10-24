﻿using System.ComponentModel.DataAnnotations;

namespace ShopManagementService.Application.Common.Dtos;

public class RegisterUserDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required, EmailAddress]
    public string? Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
    [Required, Compare("Password")]
    public string ConfirmPassword { get; set; } = string.Empty;
}