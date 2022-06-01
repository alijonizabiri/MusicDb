using Domain.Entitties;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers;
[ApiController]
[Route("[controller]")]
public class AlbumController : ControllerBase
{
    private readonly AlbumServices _albumServices;

    public AlbumController(AlbumServices albumServices)
    {
        _albumServices = albumServices;
    }

    [HttpGet("GetAlbums")]
    public async Task<List<GetJoinedAlbums>> GetAlbums()
    {
        return await _albumServices.GetAlbums();
    }
    
    [HttpPost("InsertAlbum")]
    public async Task<int> InsertAlbum(AlbumDto albumDto)
    {
        return await _albumServices.InsertAlbum(albumDto);
    }
    
    [HttpPut("UpdateAlbum")]
    public async Task<int> UpdateAlbum(AlbumDto albumDto, int id)
    {
        return await _albumServices.UpdateAlbum(albumDto,id);
    }
    
    [HttpGet("GetAlbumById")]
    public async Task<AlbumDto> GetAlbumById(int id)
    {
        return await _albumServices.GetAlbumById(id);
    }
    
    [HttpDelete("DeleteAlbum")]
    public async Task<int> DeleteAlbum(int id)
    {
        return await _albumServices.DeleteAlbum(id);
    }
}