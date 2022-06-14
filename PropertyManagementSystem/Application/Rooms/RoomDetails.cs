using System;
using System.Collections.Generic;
using System.Linq;
using PropertyManagementSystem.Domain;
using MediatR;
using PropertyManagementSystem.Persistance;

namespace PropertyManagementSystem.Application.Rooms
{
    public class RoomDetails
    {
        public class Query : IRequest<Room>
        {
            public int Id { get; set; }
        }

        public class RoomsDetailsHandler : IRequestHandler<Query, Room>
        {
            private readonly DataContext _context;

            public RoomsDetailsHandler(DataContext context)
            {
                _context = context;
            }

            public async Task<Room> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Rooms.FindAsync(request.Id);  
            }
        }
    }
}