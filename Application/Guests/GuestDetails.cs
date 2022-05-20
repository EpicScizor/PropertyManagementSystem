using Domain;
using MediatR;
using Persistance;

namespace Application.Guests;

public class Details
{ 
    public class Query : IRequest<Guest>
    {
        public int Id { get; set; }
        
    }

    public class GuestDetailsHandler : IRequestHandler<Query, Guest>
    {
        private readonly DataContext _context;
        public GuestDetailsHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Guest> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _context.Guests.FindAsync(request.Id);
        }
    }

}