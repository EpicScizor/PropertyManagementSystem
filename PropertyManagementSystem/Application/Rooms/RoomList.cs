using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PropertyManagementSystem.Domain;
using PropertyManagementSystem.Persistance;

namespace PropertyManagementSystem.Application.Rooms
{
    public class RoomList
    {
        public class Query : IRequest<List<Room>> {}

        public class RoomListHandler : IRequestHandler<Query, List<Room>>
        {
            private readonly DataContext _context;

            public async Task<List<Room>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Rooms.ToListAsync();
            }
        }
    }
}