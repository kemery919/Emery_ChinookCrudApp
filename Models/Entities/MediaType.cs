using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emery_ChinookCrudApp.Models.Entities;

public class MediaType {

  [Key]
  public int MediaTypeId { get; set; }

  public string? Name { get; set; } 

}