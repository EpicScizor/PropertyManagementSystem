using AutoMapper;
using Domain;

namespace Application.Core;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Guest, Guest>();
        CreateMap<Stay, Stay>();
        CreateMap<Room, Room>();
    }
}