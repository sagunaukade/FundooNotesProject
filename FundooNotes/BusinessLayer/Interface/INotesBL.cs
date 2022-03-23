using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
   public interface INotesBL
   {
        /// <summary>Notes the creation.</summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="notesCreation">The notes creation.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public NotesEntity NotesCreation(NotesCreation notesCreation, long notesId);

        /// <summary>Notes the update.</summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <param name="notesUpdate">The notes update.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public NotesEntity UpdateNotes(UpdateNotes updateNotes, long notesId);

        /// <summary>
        /// delete notes
        /// </summary>
        /// <param name="id">the Id</param>
        /// <param name="noteId">the note Id</param>
        /// <returns> 
        /// <br />
        /// </returns>
        public bool DeleteNotes(long id, long noteId);

        /// <summary>
        /// retrieve all notes
        /// </summary>
        /// <param name="userId">the user Id</param>
        /// <returns>
        /// <br />
        /// </returns>
        public IEnumerable<NotesEntity> RetrieveAllNotes(long userId);

        /// <summary>
        /// archive note
        /// </summary>
        /// <param name="userId">the user Id</param>
        /// <param name="notesId">the note Id</param>
        /// <returns>
        /// <br />
        /// </returns>
        public NotesEntity ArchiveNotes(long userId, long notesId);

        /// <summary>
        /// Pinned Note
        /// </summary>
        /// <param name="userId">the user Id</param>
        /// <param name="notesId">the note Id</param>
        /// <returns>
        /// <br />
        /// </returns>
        public NotesEntity PinnedNotes(long userId, long notesId);

        /// <summary>
        /// Color Notes
        /// </summary>
        /// <param name="userId">the user Id</param>
        /// <param name="notesId">the note Id</param>
        /// <param name="color">the color</param>
        /// <returns>
        /// <br />
        /// </returns>
        public NotesEntity ColorNotes(long userId, long notesId, string color);

        /// <summary>
        /// Trash Notes
        /// </summary>
        /// <param name="userId">the user Id</param>
        /// <param name="notesId">the note Id</param>
        /// <returns>
        /// <br />
        /// </returns>
        public NotesEntity TrashNotes(long userId, long notesId);

        /// <summary>
        /// Upload Image
        /// </summary>
        /// <param name="notesId">the user Id</param>
        /// <param name="image">the image</param>
        /// <returns></returns>
        public NotesEntity UploadImage(long notesId, IFormFile image);
        
   }
}
