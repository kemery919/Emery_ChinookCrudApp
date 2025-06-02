using Emery_ChinookCrudApp.Data;
using Emery_ChinookCrudApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Emery_ChinookCrudApp.Services;

public class VerifyService {
    private readonly ApplicationDbContext _context;

    public VerifyService(ApplicationDbContext context) {
        _context = context;
    }

    public async Task<List<Track>> GetTracksByComposerAsync(string composer) {
        return await _context
            .Track.Where(t => t.Composer == composer)
            .ToListAsync();
    }

    public async Task<List<Album>> GetAlbumsWithTitleContainingAsync(string subString) {
        return await _context.Album
            .Where(a => a.Title.Contains(subString))
            .ToListAsync();
    }

    public async Task<Track?> GetTrackByIdAsync(int trackId) {
        return await _context.Track.FindAsync(trackId);
    }

}