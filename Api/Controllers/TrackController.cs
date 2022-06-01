using Domain.Entitties;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers;
[ApiController]
[Route("[controller]")]
public class TrackController : ControllerBase
{
    private readonly TrackServices _trackServices;

    public TrackController(TrackServices trackServices)
    {
        _trackServices = trackServices;
    }
    
    [HttpGet("GetTracks")]
    public async Task<List<GetJoinedTracks>> GetTracks()
    {
        return await _trackServices.GetTracks();
    }
    
    [HttpPost("InsertTrack")]
    public async Task<int> InsertTrack(TrackDto trackDto)
    {
        return await _trackServices.InsertTrack(trackDto);
    }
    
    [HttpPut("UpdateTrack")]
    public async Task<int> UpdateTrack(TrackDto trackDto, int id)
    {
        return await _trackServices.UpdateTrack(trackDto,id);
    }
    
    [HttpGet("GetTrackById")]
    public async Task<TrackDto> GetTrackById(int id)
    {
        return await _trackServices.GetTrackById(id);
    }
    
    [HttpDelete("DeleteTrack")]
    public async Task<int> DeleteTrack(int id)
    {
        return await _trackServices.DeleteTrack(id);
    }
}