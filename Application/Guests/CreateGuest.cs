using Domain;
using MediatR;
using Persistance;

namespace Application.Guests;

public class CreateGuest
{
    public class Command : IRequest
    {
        public Guest Guest { get; set; }
    }

    public class CreateHandler : IRequestHandler<Command>
    {
        private readonly DataContext _context;

        public CreateHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            _context.Guests.Add(request.Guest);

            _context.SaveChangesAsync();
            
            return Unit.Value;
        }
    }
}