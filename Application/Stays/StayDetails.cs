using Domain;
using MediatR;
using Persistance;

namespace Application.Stays;

public class StayDetails
{
    public class Query : IRequest<Stay>
    {
        public Guid Id { get; set; }
    }

    public class StayDetailsHandler : IRequestHandler<Query, Stay>
    {
        private readonly DataContext _context;

        public StayDetailsHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Stay> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _context.Stays.FindAsync(request.Id);
        }
    }
}