using System.Configuration;
using Application.Core;
using Application.Guests;
using Application.Stays;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Persistance;

namespace API.Extentions;

public static class GuestAppServiceExtentions
{
    public static IServiceCollection AddGuestAppServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIv5", Version = "v1" });
        });
        services.AddCors(opt =>
        {
            opt.AddPolicy("CorsPolicy", policy =>
            {
                policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
            });
        });
        services.AddMediatR(typeof(GuestList.GuestListHandler).Assembly);
        services.AddMediatR(typeof(StayList.StayListHandler).Assembly);
        services.AddAutoMapper(typeof(MappingProfiles).Assembly);

        return services;
    }
}