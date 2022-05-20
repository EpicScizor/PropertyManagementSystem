using Application.Guests;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.Stays;

public class StayList
{
    public class Query : IRequest<List<Stay>> {}

    public class StayListHandler : IRequestHandler<Query, List<Stay>>
    {
        private readonly DataContext _context;

        public StayListHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Stay>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _context.Stays.ToListAsync();
        }
    }
}