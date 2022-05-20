using AutoMapper;
using Domain;
using MediatR;
using Persistance;

namespace Application.Stays;

public class EditStay
{
    public class Command : IRequest
    {
        public Stay Stay { get; set; }
    }

    public class StayEditHandler : IRequestHandler<Command>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public StayEditHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(Command request, CancellationToken token)
        {
            var stay = await _context.Stays.FindAsync(request.Stay.StayId);

            _mapper.Map(request.Stay, stay);

            await _context.SaveChangesAsync();
            
            return Unit.Value;
        }
    }
}