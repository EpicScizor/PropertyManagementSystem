using MediatR;
using PropertyManagementSystem.Persistance;

namespace PropertyManagementSystem.Application.Stays;

public class DeleteStay
{
    public class Command : IRequest
    {
        public Guid Id { set; get; }
    }

    public class DeleteStayHandler : IRequestHandler<Command>
    {
        private readonly DataContext _context;

        public DeleteStayHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(Command request, CancellationToken token)
        {
            var stay = await _context.Stays.FindAsync(request.Id);

            _context.Remove(stay);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}