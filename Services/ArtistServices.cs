using AutoMapper;
using Domain.Entitties;
using Domain.Model;
using Persistence.Data;

namespace Services;

public class ArtistServices : IArtistServices
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ArtistServices(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public async Task<List<GetJoinedArtists>> GetArtists()
    {
        var joined = (
            from alb in _context.Albums
            join art in _context.Artists on alb.ArtistId equals art.ArtistId
            join tr in _context.Tracks on alb.ALbumId equals tr.AlbumId
            select new GetJoinedArtists
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

    public async Task<int> InsertArtist(ArtistDto artistDto)
    {
        var album = _mapper.Map<Artist>(artistDto);
        await _context.Artists.AddAsync(album);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> UpdateArtist(ArtistDto artistDto, int id)
    {
        var find = await _context.Artists.FindAsync(id);
        find.ArtistName = artistDto.ArtistName;
        return await _context.SaveChangesAsync();
    }

    public async Task<ArtistDto> GetArtistById(int id)
    {
        var find = await _context.Artists.FindAsync(id);
        return _mapper.Map<ArtistDto>(find);
    }

    public async Task<int> DeleteArtist(int id)
    {
        var find = await _context.Artists.FindAsync(id);
        _context.Artists.Remove(find);
        return await _context.SaveChangesAsync();
    }
}