using Domain.Entitties;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers;
[ApiController]
[Route("[controller]")]
public class ArtistController : ControllerBase
{
    private readonly ArtistServices _artistServices;

    public ArtistController(ArtistServices artistServices)
    {
        _artistServices = artistServices;
    }

    [HttpGet("GetArtists")]
    public async Task<List<GetJoinedArtists>> GetArtists()
    {
        return await _artistServices.GetArtists();
    }
    
    [HttpPost("InsertArtist")]
    public async Task<int> InsertArtist(ArtistDto artistDto)
    {
        return await _artistServices.InsertArtist(artistDto);
    }
    
    [HttpPut("UpdateArtist")]
    public async Task<int> UpdateArtist(ArtistDto artistDto, int id)
    {
        return await _artistServices.UpdateArtist(artistDto,id);
    }
    
    [HttpGet("GetArtistById")]
    public async Task<ArtistDto> GetArtistById(int id)
    {
        return await _artistServices.GetArtistById(id);
    }
    
    [HttpDelete("DeleteArtist")]
    public async Task<int> DeleteArtist(int id)
    {
        return await _artistServices.DeleteArtist(id);
    }
}