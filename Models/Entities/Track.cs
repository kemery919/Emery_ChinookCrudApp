using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emery_ChinookCrudApp.Models.Entities;

public class Track {

  [Key]
  public int TrackId { get; set; }

  [Required]
  public required string Name { get; set; }

  [ForeignKey("Album")]
  public int AlbumId { get; set; }

  public virtual Album? Album { get; set; }

  [ForeignKey("MediaType")]
  public int MediaTypeId { get; set; }

  public virtual MediaType? MediaType { get; set; }

  [ForeignKey("Genre")]
  public int GenreId { get; set; }

  public virtual Genre? Genre { get; set; }

  public string? Composer { get; set; }

  public int Milliseconds { get; set; }

  public int Bytes { get; set; }

  public decimal UnitPrice { get; set; }

  public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();

}