﻿using System;
using MediatR;
using System.Threading;
using Notes.Domain;
using Notes.Application.Interfaces;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommandHandler
        : IRequestHandler<CreateNoteCommand, Guid>
    {
        private readonly INotesDbContext _dbContext;
        public CreateNoteCommandHandler(INotesDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Guid> Handle(CreateNoteCommand requst,
            CancellationToken cancellationToken)
        {
            var note = new Note
            {
                UserId = requst.UserId,
                Title = requst.Title,
                Details = requst.Details,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                EditDate = null
            };
            await _dbContext.Notes.AddAsync(note, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return note.Id;
        }
    }
}
