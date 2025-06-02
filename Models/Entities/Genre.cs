using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emery_ChinookCrudApp.Models.Entities;

public class Genre {

  [Key]
  public int GenreId { get; set; }

  public string? Name { get; set; } 

  public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();

}