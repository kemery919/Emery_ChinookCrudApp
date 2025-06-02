using Emery_ChinookCrudApp.Data;
using Emery_ChinookCrudApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Emery_ChinookCrudApp.Interfaces;

namespace Emery_ChinookCrudApp.Services;

public class CrudService : ICrudService { 
    public Task<Customer> AddCustomerAsync(string firstName, string lastName, string email, int supportRepId)
    {
        throw new NotImplementedException();
    }

    public Task<int> AdjustTrackPricesByGenreAsync(int genreId, decimal percentIncrease)
    {
        throw new NotImplementedException();
    }

    public Task<Album> CreateAlbumForArtistAsync(int artistId, string title)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteCustomersByCountryAsync(string country)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteCustomersWithNoInvoicesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteEmptyPlaylistsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeletePlaylistAsync(int playlistId)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteTracksNotPurchasedAsync()
    {
        throw new NotImplementedException();
    }

    public Task<int> RenameAlbumsContainingKeywordAsync(string keyword, string appendText)
    {
        throw new NotImplementedException();
    }

    public Task<int> RenameComposerAsync(string oldName, string newName)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateTrackPriceAsync(int trackId, decimal newPrice)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateTracksByComposerAsync(string composer, decimal newPrice)
    {
        throw new NotImplementedException();
    }
}