using Domain.Entitties;
using Domain.Model;

namespace Services;

public interface ITrackServices
{
    public Task<List<GetJoinedTracks>> GetTracks();
    public Task<int> InsertTrack(TrackDto trackDto);
    public Task<int> UpdateTrack(TrackDto trackDto, int id);
    public Task<TrackDto> GetTrackById(int id);
    public Task<int> DeleteTrack(int id);
}