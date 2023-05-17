using AutoMapper;
using System;
using Notes.Application.Common.Mappings;
using Notes.Application.Notes.Commands.UpdateNote;

namespace Notes.WebApi.Models
{
    public class UpdateNoteDto : IMapWith<UpdateNoteCommand>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateNoteDto, UpdateNoteCommand>()
                .ForMember(NoteCommand => NoteCommand.Id,
                    opt => opt.MapFrom(noteDto => noteDto.Id))
                .ForMember(NoteCommand => NoteCommand.Title,
                    opt => opt.MapFrom(noteDto => noteDto.Title))
                .ForMember(NoteCommand => NoteCommand.Details,
                    opt => opt.MapFrom(noteDto => noteDto.Details));
        }
    }
}
