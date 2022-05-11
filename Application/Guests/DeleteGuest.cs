using MediatR;
using Persistance;

namespace Application.Guests;

public class DeleteGuest
{
    public class Command : IRequest
    {
        public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Command>
    {
        private readonly DataContext _context;

        public Handler(DataContext context)
        {
            _context = context;
            
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var guest = await _context.Guests.FindAsync(request.Id);

            _context.Remove(guest);

            await _context.SaveChangesAsync();
            
            return Unit.Value;
        }
    }
}