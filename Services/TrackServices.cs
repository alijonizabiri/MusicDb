using AutoMapper;
using Domain.Entitties;
using Domain.Model;
using Persistence.Data;

namespace Services;

public class TrackServices : ITrackServices
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public TrackServices(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<GetJoinedTracks>> GetTracks()
    {
        var joined = (
            from alb in _context.Albums
            join art in _context.Artists on alb.ArtistId equals art.ArtistId
            join tr in _context.Tracks on alb.ALbumId equals tr.AlbumId
            select new GetJoinedTracks
            {
                TrackId = tr.TrackId,
                TrackName = tr.TrackName,
                ArtistId = alb.ArtistId,
                ArtistName = art.ArtistName,
                ALbumId = alb.ALbumId,
                Title = alb.Title
            }
        ).ToList();
        return joined;
    }

    public async Task<int> InsertTrack(TrackDto trackDto)
    {
        var album = _mapper.Map<Track>(trackDto);
        await _context.Tracks.AddAsync(album);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> UpdateTrack(TrackDto trackDto, int id)
    {
        var find = await _context.Tracks.FindAsync(id);
        find.TrackName = trackDto.TrackName;
        find.AlbumId = trackDto.AlbumId;
        return await _context.SaveChangesAsync();
    }

    public async Task<TrackDto> GetTrackById(int id)
    {
        var find = await _context.Tracks.FindAsync(id);
        return _mapper.Map<TrackDto>(find);
    }

    public async Task<int> DeleteTrack(int id)
    { 
        var find = await _context.Tracks.FindAsync(id);
        _context.Tracks.Remove(find);
        return await _context.SaveChangesAsync();
    }
}