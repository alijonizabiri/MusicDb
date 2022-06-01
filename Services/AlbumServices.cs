using AutoMapper;
using Domain.Entitties;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Services;

public class AlbumServices : IAlbumServices
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public AlbumServices(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<List<GetJoinedAlbums>> GetAlbums()
    {
        // var get = await _context.Albums.ToListAsync();
        var joined = (
            from alb in _context.Albums
            join art in _context.Artists on alb.ArtistId equals art.ArtistId
            join tr in _context.Tracks on alb.ALbumId equals tr.AlbumId
            select new GetJoinedAlbums
            {
                ArtistId = alb.ArtistId,
                ArtistName = art.ArtistName,
                ALbumId = alb.ALbumId,
                Title = alb.Title,
                TrackId = tr.TrackId,
                TrackName = tr.TrackName
            }
            ).ToList();
        return joined;
    }

    public async Task<int> InsertAlbum(AlbumDto albumDto)
    {
        var album = _mapper.Map<Album>(albumDto);
        await _context.Albums.AddAsync(album);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> UpdateAlbum(AlbumDto albumDto, int id)
    {
        var find = await _context.Albums.FindAsync(id);
        find.Title = albumDto.Title;
        find.ArtistId = albumDto.ArtistId;
        return await _context.SaveChangesAsync();
    }

    public async Task<AlbumDto> GetAlbumById(int id)
    {
        var find = await _context.Albums.FindAsync(id);
        return _mapper.Map<AlbumDto>(find);
      
    }

    public async Task<int> DeleteAlbum(int id)
    {
        var find = await _context.Albums.FindAsync(id);
        _context.Albums.Remove(find);
        return await _context.SaveChangesAsync();
    }
}