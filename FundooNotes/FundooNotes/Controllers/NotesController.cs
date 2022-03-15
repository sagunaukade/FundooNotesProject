using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesBL noteBL;
        //Constructor
        public NotesController(INotesBL noteBL)
        {
            this.noteBL = noteBL;

        }
        [Authorize]
        [HttpPost("Create")]
        public IActionResult NotesCreations(NotesCreation noteCreation)
        {
            try
            {
                long noteId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = noteBL.NotesCreation(noteCreation, noteId);
                if (result != null)
                    return this.Ok(new { Success = true, message = "Notes created successful", data = result });
                else
                    return this.BadRequest(new { Success = false, message = "Notes not created " });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, Message = e.Message });
            }
        }
        [Authorize]
        [HttpPost("Update")]
        public IActionResult UpdateNotes(UpdateNotes updateNotes, long notesId)
        {
            try
            {
                var result = noteBL.UpdateNotes(updateNotes, notesId);
                if (result != null)
                    return this.Ok(new { Success = true, message = "Notes update successful", data = result });
                else
                    return this.BadRequest(new { Success = false, message = "Notes update failed " });
            }
            catch (Exception)
            {
                throw;
            }
        }
        [Authorize]
        [HttpDelete("Delete")]
        public IActionResult DeleteNotes(long id, long noteId)
        {
            try
            {
                if (noteBL.DeleteNotes(id, noteId))
                    return this.Ok(new { Success = true, message = "Deleted successful", data = noteBL.DeleteNotes(id, noteId) });
                else
                    return this.BadRequest(new { Success = false, message = "Notes not deleted " });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, Message = e.Message });
            }
        }

        [Authorize]
        [HttpGet("Retrieve")]
        public IActionResult RetrieveAllNotes(long id)
        {
            try
            {
                var result = noteBL.RetrieveAllNotes(id);
                if (result != null)
                    return this.Ok(new { Success = true, message = "Retrieve successful", data = noteBL.RetrieveAllNotes(id) });
                else
                    return this.BadRequest(new { Success = false, message = "Retrive Failed " });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, Message = e.Message });
            }
        }
        [Authorize]
        [HttpPut("Archive")]
        public IActionResult ArchiveNotes(long userId, long notesId)
        {
            try
            {
                var result = noteBL.ArchiveNotes(userId, notesId);
                if (result != null)
                    return this.Ok(new { Success = true, message = "Successfully note archived ", data = result });
                else
                    return this.BadRequest(new { Success = false, message = "Failed to note archive" });
            }
            catch (Exception)
            {
                throw;
            }
        }
        [Authorize]
        [HttpPut("Pin")]
        public IActionResult PinnedNotes(long userId, long notesId)
        {
            try
            {
                var result = noteBL.PinnedNotes(userId, notesId);
                if (result != null)
                    return this.Ok(new { Success = true, message = "Successfully note pinned ", data = result });
                else
                    return this.BadRequest(new { Success = false, message = "Failed to note pinned" });
            }
            catch (Exception)
            {
                throw;
            }
        }
        [Authorize]
        [HttpPut("Color")]
        public IActionResult ColorNotes(long userId, long notesId, String color)
        {
            try
            {
                var result = (noteBL.ColorNotes(userId, notesId, color));
                if (result != null)
                    return this.Ok(new { Success = true, message = "Notes color changed successfully", data = result });
                else
                    return this.BadRequest(new { Success = false, message = "Failed to change the color of the note" });
            }
            catch (Exception)
            {
                throw;
            }
        }
        [Authorize]
        [HttpPut("Trash")]
        public IActionResult TrashNotes(long userId, long notesId)
        {
            try
            {
                var result = (noteBL.TrashNotes(userId, notesId));
                if (result != null)
                    return this.Ok(new { Success = true, message = "Successfully note trashed ", data = result });
                else
                    return this.BadRequest(new { Success = false, message = "Failed to note trashed" });
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}