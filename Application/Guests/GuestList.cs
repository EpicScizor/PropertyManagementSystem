using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.Guests;

public class GuestList
{
    public class Query : IRequest<List<Guest>> {}

    public class GuestListHandler : IRequestHandler<Query, List<Guest>>
    {
        private readonly DataContext _context;
        public GuestListHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Guest>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _context.Guests.ToListAsync(cancellationToken);
        }
    }
}