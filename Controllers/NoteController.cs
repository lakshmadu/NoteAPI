using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NoteAPI.Models;
using NoteAPI.DataAccess;

namespace NoteAPI.Controllers
{
    [Route("api/note")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly NoteDbContext _context;
        public NoteController(NoteDbContext context)
        {
            _context=context;
        }

        // [HttpGet]
        // public ActionResult<IEnumerable<string>> GetTModels()
        // {
        //     return new string[] {"note1","note2" };
        // }

        [HttpGet]
        public ActionResult<IEnumerable<Note>> GetAllNotes(){
            return Ok(_context.Notes);
        }

        [HttpGet("{id}")]
        public ActionResult<Note> GetTModelById(int id)
        {
            try{
                var o = _context.Notes.Find(id);
                if(o is null){
                    return NoContent();
                }

            
                return Ok(o);
            }catch{
                return NotFound();
            }
            
        }

        [HttpPost]
        public ActionResult<Note> CreateNote(Note note)
        {
            _context.Notes.Add(note);

            return Ok("Ceated");
        }

        // [HttpPut("{id}")]
        // public IActionResult PutTModel(int id, TModel model)
        // {
        //     return NoContent();
        // }

        // [HttpDelete("{id}")]
        // public ActionResult<TModel> DeleteTModelById(int id)
        // {
        //     return null;
        // }
    }
}