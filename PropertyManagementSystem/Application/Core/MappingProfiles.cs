using AutoMapper;
using PropertyManagementSystem.Domain;

namespace PropertyManagementSystem.Application.Core;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Guest, Guest>();
        CreateMap<Stay, Stay>();
        CreateMap<Room, Room>();
    }
}