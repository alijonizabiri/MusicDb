using Domain.Entitties;
using Domain.Model;

namespace Services;

public interface IAlbumServices
{
    public Task<List<GetJoinedAlbums>> GetAlbums();
    public Task<int> InsertAlbum(AlbumDto albumDto);
    public Task<int> UpdateAlbum(AlbumDto albumDto, int id);
    public Task<AlbumDto> GetAlbumById(int id);
    public Task<int> DeleteAlbum(int id);
}