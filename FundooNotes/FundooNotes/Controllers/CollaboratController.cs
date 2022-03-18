using BusinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Exchange.WebServices.Data;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollaboratController : ControllerBase
    {
        private readonly ICollaboratBL collabratorBL;
        public CollaboratController(ICollaboratBL collabratorBL)
        {
            this.collabratorBL = collabratorBL;
        }

        [Authorize]
        [HttpPost("AddCollaborator")]
        public IActionResult AddCollab(string email, long noteId)
        {
            try
            {
                var userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = collabratorBL.AddCollab(email, userId, noteId);
                if (result != null)
                {
                    return this.Ok(new { Success = true, message = " Successfully Collaborator Added", data = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Collaborator Not Added" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpDelete("RemoveCollaborator")]
        public IActionResult DeleteCollab(long collabId)
        {
            try
            {
                var userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = collabratorBL.DeleteCollab(userId, collabId);
                if (result)
                {
                    return this.Ok(new { Success = true, message = "Successfully Collaborator Remove", data = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = " Collaborator Not Removed" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
       
        [Authorize]
        [HttpGet("{NotesId}/GetCollabrator")]
        public IEnumerable<CollaboratEntity> GetByNoteId( long notesId)
        {
            try
            {
               long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = collabratorBL.GetByNoteId(userId, notesId);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

   