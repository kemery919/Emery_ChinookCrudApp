using Emery_ChinookCrudApp.Data;
using Emery_ChinookCrudApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Emery_ChinookCrudApp.Interfaces;

namespace Emery_ChinookCrudApp.Services;

public class CrudService : ICrudService { 

    private readonly ApplicationDbContext _context;

    public CrudService(ApplicationDbContext context) {
        _context = context;
    }
    
    public async Task<Customer> AddCustomerAsync(string firstName, string lastName, string email, int supportRepId){

       Customer addCust = new Customer {
           FirstName = firstName,
           LastName = lastName,
           Email = email,
           SupportRepId = supportRepId
       };
      
      _context.Customer.Add(addCust);

      await _context.SaveChangesAsync();

      return addCust;
    }

    public async Task<bool> UpdateTrackPriceAsync(int trackId, decimal newPrice){
        
        bool result = false;

        var track = await _context.Track.FindAsync(trackId);

        if(track != null){
          track.UnitPrice = newPrice;
          await _context.SaveChangesAsync();
          result = true;
        }

        return result;
    }

    public async Task<bool> DeletePlaylistAsync(int playlistId){
        
        bool result = false;

        var playlist = await _context.Playlist.FindAsync(playlistId);

        if (playlist != null) {
            _context.Playlist.Remove(playlist);
            await _context.SaveChangesAsync();
            result = true;
        }

        return result;
    }

    public async Task<Album> CreateAlbumForArtistAsync(int artistId, string title){
  
      Album addAlbum = new Album {
        ArtistId = artistId,
        Title = title
      };

      _context.Album.Add(addAlbum);

      await _context.SaveChangesAsync();

      return addAlbum;

    }

    public async Task<int> UpdateTracksByComposerAsync(string composer, decimal newPrice){
        
      int count = 0;

      var compTracks = await _context.Track
        .Where(t => t.Composer == composer)
        .ToListAsync();

      foreach(var track in compTracks){
        track.UnitPrice = newPrice;

        count ++;
      }

      await _context.SaveChangesAsync();

      return count;
    }

    public async Task<int> DeleteCustomersByCountryAsync(string country){
        
        int count = 0;

        var deletedCustomers = await _context.Customer
          .Where(c => c.Country == country)
          .ToListAsync();
        
        foreach(var customer in deletedCustomers){
          _context.Customer.Remove(customer);

          count ++;
        }

        await _context.SaveChangesAsync();

        return count;
    }

    public async Task<int> AdjustTrackPricesByGenreAsync(int genreId, decimal percentIncrease){
        
      int count = 0;

      var adjustTracksPercent = await _context.Track
        .Where(t => t.GenreId == genreId)
        .ToListAsync();
      
      foreach(var track in adjustTracksPercent){
        track.UnitPrice = track.UnitPrice * (1 + (percentIncrease / 100));

        count ++;
      }

      await _context.SaveChangesAsync();

      return count;
    }

    public async Task<int> DeleteEmptyPlaylistsAsync(){
      int count = 0;

      var emptyPlaylist = await _context.Playlist
        .Where(p => p.Tracks.Count == 0)
        .ToListAsync();

      foreach(var playlist in emptyPlaylist){
        _context.Playlist.Remove(playlist);

        count ++;
      }

      await _context.SaveChangesAsync();

      return count;
    }

    public async Task<int> RenameComposerAsync(string oldName, string newName){
      int count = 0;

      var composerTracks = await _context.Track
        .Where(t => t.Composer == oldName)
        .ToListAsync();
      
      foreach(var track in composerTracks){
        track.Composer = newName;

        count ++;
      }

      await _context.SaveChangesAsync();

      return count;
    }

    public async Task<int> DeleteCustomersWithNoInvoicesAsync(){
      int count = 0;

      var customersWithInvoices = await _context.Invoice
        .Select(inv => inv.CustomerId)
        .ToListAsync();

      var missingCustomers = await _context.Customer
        .Where(customer => !customersWithInvoices.Contains(customer.CustomerId))
        .ToListAsync();

      foreach(var customer in missingCustomers){
        _context.Customer.Remove(customer);

        count ++;
      }

      await _context.SaveChangesAsync();

      return count;
    }

    public async Task<int> RenameAlbumsContainingKeywordAsync(string keyword, string appendText){
      int count = 0;

      var albumKeyword = await _context.Album
        .Where(a => a.Title.Contains(keyword))
        .ToListAsync();
      
      foreach(var album in albumKeyword){
        album.Title += appendText;
        
        count ++;
      }

      await _context.SaveChangesAsync();

      return count;
    }

    public async Task<int> DeleteTracksNotPurchasedAsync(){
      int count = 0;

      // var notPurchedTracks = await _context.Track
      //   .Where(track => !_context.InvoiceLine.Any(invLine => invLine.TrackId == track.TrackId))
      //   .ToListAsync();

      var purchasedTrackIds = await _context.InvoiceLine
        .Select(invLine => invLine.TrackId)
        .Distinct()
        .ToListAsync();
      
      var notPurchasedTracks = await _context.Track
        .Where(track => !purchasedTrackIds.Contains(track.TrackId))
        .ToListAsync();
      
      foreach(var track in notPurchasedTracks){
        _context.Track.Remove(track);

        count ++;
      }

      await _context.SaveChangesAsync();

      return count;
    }
}