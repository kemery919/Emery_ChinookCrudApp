using Emery_ChinookCrudApp.Models.Entities;

namespace Emery_ChinookCrudApp.Interfaces;

public interface ICrudService {
    // ----------------------------
    // BASIC CRUD METHODS
    // ----------------------------

    /// <summary>
    /// Adds a new customer to the database with the specified contact information and support rep.
    /// Returns the created Customer object.
    /// </summary>
    Task<Customer> AddCustomerAsync(string firstName, string lastName, string email, int supportRepId);

    /// <summary>
    /// Updates the unit price of a specific track identified by its ID.
    /// Returns true if the update was successful, or false if the track wasn't found.
    /// </summary>
    Task<bool> UpdateTrackPriceAsync(int trackId, decimal newPrice);

    /// <summary>
    /// Deletes a playlist by its ID.
    /// Returns true if the deletion was successful, or false if the playlist wasn't found.
    /// </summary>
    Task<bool> DeletePlaylistAsync(int playlistId);

    /// <summary>
    /// Creates a new album for a given artist.
    /// Returns the newly created Album object.
    /// </summary>
    Task<Album> CreateAlbumForArtistAsync(int artistId, string title);

    // ----------------------------
    // INTRICATE CRUD METHODS
    // ----------------------------

    /// <summary>
    /// Updates the unit price of all tracks by the specified composer.
    /// Returns the number of tracks that were updated.
    /// </summary>
    Task<int> UpdateTracksByComposerAsync(string composer, decimal newPrice);

    /// <summary>
    /// Deletes all customers from the specified country.
    /// Returns the number of customers that were deleted.
    /// </summary>
    Task<int> DeleteCustomersByCountryAsync(string country);

    /// <summary>
    /// Increases the unit price of all tracks in a specific genre by a given percentage.
    /// Returns the number of tracks that were updated.
    /// </summary>
    Task<int> AdjustTrackPricesByGenreAsync(int genreId, decimal percentIncrease);

    /// <summary>
    /// Deletes all playlists that contain no tracks.
    /// Returns the number of playlists that were deleted.
    /// </summary>
    Task<int> DeleteEmptyPlaylistsAsync();

    /// <summary>
    /// Updates the composer name for all tracks that match the specified old composer name.
    /// Returns the number of tracks that were updated.
    /// </summary>
    Task<int> RenameComposerAsync(string oldName, string newName);

    /// <summary>
    /// Deletes all customers who have no invoices in the database.
    /// Returns the number of customers that were deleted.
    /// </summary>
    Task<int> DeleteCustomersWithNoInvoicesAsync();

    /// <summary>
    /// Appends a specified string to the title of all albums whose titles contain a given keyword.
    /// Returns the number of albums that were updated.
    /// </summary>
    Task<int> RenameAlbumsContainingKeywordAsync(string keyword, string appendText);

    /// <summary>
    /// Deletes all tracks that have never been purchased (i.e., do not appear in any invoice line).
    /// Returns the number of tracks that were deleted.
    /// </summary>
    Task<int> DeleteTracksNotPurchasedAsync();
}