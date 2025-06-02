using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emery_ChinookCrudApp.Models.Entities;

public class InvoiceLine {

  [Key]
  public int InvoiceLineId { get; set; }

  [ForeignKey("Invoice")]
  public int InvoiceId { get; set; }

  public Invoice? Invoice { get; set; }

  [ForeignKey("Track")]
  public int TrackId { get; set; }

  public Track? Track { get; set; }

  public decimal UnitPrice { get; set; }

  public int Quantity { get; set; }

}