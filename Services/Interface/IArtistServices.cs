using Domain.Entitties;
using Domain.Model;

namespace Services;

public interface IArtistServices
{
    public Task<List<GetJoinedArtists>> GetArtists();
    public Task<int> InsertArtist(ArtistDto artistDto);
    public Task<int> UpdateArtist(ArtistDto artistDto, int id);
    public Task<ArtistDto> GetArtistById(int id);
    public Task<int> DeleteArtist(int id);
}