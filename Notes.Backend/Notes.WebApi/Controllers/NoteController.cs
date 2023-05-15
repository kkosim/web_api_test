using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Notes.Application.Notes.Queries.GetNoteList;
using Notes.Application.Notes.Queries.GetNoteDetails;

namespace Notes.WebApi.Controllers
{
    public class NoteController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<NoteListVm>> GetAll()
        {
            var querry = new GetNoteListQuery
            {
                UserId = UserId
            };

            var vm = await Mediator.Send(querry);
            return Ok(vm);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<NoteDetailsVm>> Get(Guid id)
        {
            var querry = new GetNoteDetailsQuery
            { 
                UserId = UserId,
                Id = id 
            };
            var vm = await Mediator.Send(querry);
            return Ok(vm);
        }
    }
}
