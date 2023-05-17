using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Notes.Domain;
using Notes.Application.Interfaces;
using Notes.Application.Common.Exceptions;

namespace Notes.Application.Notes.Commands.DeleteCommand
{
    public class DeleteNoteCommandHandler
        :IRequestHandler<DeleteNoteCommand>
    {
        private readonly INotesDbContext _dbcontext;
        public DeleteNoteCommandHandler(INotesDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Unit> Handle (DeleteNoteCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.Notes
                .FindAsync(new object[] { request.UserId }, cancellationToken);

            if (entity == null || entity.UserId != request.UserId) 
            {
                throw new NotFoundException(nameof(Note), request.Id);
            }
            _dbcontext.Notes .Remove(entity);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        Task IRequestHandler<DeleteNoteCommand>.Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
