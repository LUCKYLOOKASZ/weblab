using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Entities;

[Table("customer")]
public partial class Customer
{
    [Key]
    public int customer_id { get; set; }

    public string? first_name { get; set; }

    public string? last_name { get; set; }

    [EmailAddress]
    public string? email { get; set; }

    [InverseProperty("customer")]
    public virtual ICollection<CustOrder> cust_orders { get; set; } = new List<CustOrder>();

    [InverseProperty("customer")]
    public virtual ICollection<CustomerAddress> customer_addresses { get; set; } = new List<CustomerAddress>();
    
    [NotMapped]
    public int OrderCount => cust_orders.Count;

    [NotMapped]
    public string Country => customer_addresses.FirstOrDefault()?.Address?.Country?.CountryName ?? "Unknown";

}