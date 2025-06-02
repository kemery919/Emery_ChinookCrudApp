using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emery_ChinookCrudApp.Models.Entities;

public class Invoice {

  [Key]
  public int InvoiceId { get; set; }

  [ForeignKey("Customer")]
  public int CustomerId { get; set; }

  public Customer? Customer { get; set; } 

  public DateTime InvoiceDate { get; set; }

  public string? BillingAddress { get; set; }

  public string? BillingCity { get; set; }

  public string? BillingState { get; set; }

  public string? BillingCountry { get; set; }

  public string? BillingPostalCode { get; set; }

  public decimal Total { get; set; }

}