using AutoMapper;
using Domain;
using MediatR;
using Persistance;

namespace Application.Guests;

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
            var guest = await _context.Guests.FindAsync(request.Guest.Id);

            _mapper.Map(request.Guest, guest);

            await _context.SaveChangesAsync();
            
            return Unit.Value;
        }
    }
}