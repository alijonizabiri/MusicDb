using AutoMapper;
using Domain.Entitties;
using Domain.Model;

namespace Services;

public class ProfileService : Profile
{
    public ProfileService()
    {
        CreateMap<AlbumDto, Album>();
        CreateMap<ArtistDto, Artist>();
        CreateMap<TrackDto, Track>();
    }
}