using MediatR;
using Microsoft.OpenApi.Models;
using PropertyManagementSystem.Application.Core;
using PropertyManagementSystem.Application.Guests;
using PropertyManagementSystem.Application.Stays;

namespace PropertyManagementSystem.Extentions;

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