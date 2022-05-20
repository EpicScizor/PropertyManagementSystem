using Domain;
using MediatR;
using Persistance;

namespace Application.Stays;

public class CreateStay
{
    public class Command : IRequest
    {
        public Stay Stay { get; set; }
    }

    public class CreateStayHandler : IRequestHandler<Command>
    {
        private readonly DataContext _context;

        public CreateStayHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(Command request, CancellationToken token)
        {
            _context.Stays.Add(request.Stay);
            _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}