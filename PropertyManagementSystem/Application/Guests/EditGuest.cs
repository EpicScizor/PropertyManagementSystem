using AutoMapper;
using MediatR;
using PropertyManagementSystem.Domain;
using PropertyManagementSystem.Persistance;

namespace PropertyManagementSystem.Application.Guests;

public class EditGuest
{
    public class Command : IRequest
    {
        public Guest Guest { get; set; }
    }

    public class EditHandler : IRequestHandler<Command>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public EditHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var guest = await _context.Guests.FindAsync(request.Guest.GuestId);

            _mapper.Map(request.Guest, guest);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}