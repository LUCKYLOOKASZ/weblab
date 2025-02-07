﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication3.Models;

public class ContactModel
{
    [HiddenInput]
    public int Id { get; set; } 
    
    [Required]
    [MaxLength(length: 20, ErrorMessage = "imie nie może być większe niż 20 znaków")]
    [MinLength(length: 2, ErrorMessage = "imie musi mieć conajmniej 2 znaki")]
    [Display(Name = "Imię")]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(length: 20, ErrorMessage = "imie nie może być większe niż 20 znaków")]
    [MinLength(length: 2, ErrorMessage = "imie musi mieć conajmniej 2 znaki")]
    [Display(Name = "Nazwisko")]
    public string LastName { get; set; }
    [EmailAddress]
    [Display(Name = "Adres E-mail")]
    public string Email { get; set; }
    [Phone]
    [RegularExpression("\\d{3} \\d{3} \\d{3}" ,ErrorMessage = "wpisz numer wg wzoru xxx xxx xxx")]
    [Display(Name = "Telefon")]
    public string PhoneNumber { get; set; }
    [DataType(DataType.Date)]
    [Display(Name = "Data urodzenia")]
    public DateOnly BirthDate { get; set; }
    
    [Display(Name = "Kategoria")]
    public Category Category { get; set; }

    [HiddenInput] public int OrganizationId { get; set; }
    public OrganizationEntity? organization { get; set; }
    [ValidateNever]
    public List<SelectListItem> Organizations { get; set; }
    
}