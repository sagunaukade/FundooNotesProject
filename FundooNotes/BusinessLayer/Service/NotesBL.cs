using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class NotesBL : INotesBL
    {
        private readonly INotesRL notesRL;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="notesRL">name</param>
        public NotesBL(INotesRL notesRL)
        {
            this.notesRL = notesRL;
        }
        /// <summary>
        /// Notes Creation
        /// </summary>
        /// <param name="notesCreation"></param>
        /// <param name="notesId"></param>
        /// <returns>notes creation</returns>
        public NotesEntity NotesCreation(NotesCreation notesCreation, long notesId)
        {
            try
            {
                return notesRL.NotesCreation(notesCreation, notesId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// update notes
        /// </summary>
        /// <param name="updateNotes">update notes</param>
        /// <param name="notesId">notes id</param>
        /// <returns>update notes</returns>
        public NotesEntity UpdateNotes(UpdateNotes updateNotes, long notesId)
        {
            try
            {
                return notesRL.UpdateNotes(updateNotes, notesId);

            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// delete note
        /// </summary>
        /// <param name="id"> id</param>
        /// <param name="noteId">noteid</param>
        /// <returns>delete notes</returns>
        public bool DeleteNotes(long id, long noteId)
        {
            try
            {
                return notesRL.DeleteNotes(id, noteId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// retrieve all notes
        /// </summary>
        /// <param name="notesId">notes id</param>
        /// <returns>retrieve</returns>
        public IEnumerable<NotesEntity> RetrieveAllNotes(long notesId)
        {
            try
            {
                return notesRL.RetrieveAllNotes(notesId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// archive notes
        /// </summary>
        /// <param name="userId">userid</param>
        /// <param name="notesId">notesid</param>
        /// <returns>archive</returns>
        public NotesEntity ArchiveNotes(long userId, long notesId)
        {
            try
            {
                return this.notesRL.ArchiveNotes(userId, notesId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// pinned notes
        /// </summary>
        /// <param name="userId">userid</param>
        /// <param name="notesId">notesid</param>
        /// <returns>pinned notes</returns>
        public NotesEntity PinnedNotes(long userId, long notesId)
        {
            try
            {
                return this.notesRL.PinnedNotes(userId, notesId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// color notes
        /// </summary>
        /// <param name="userId">user id</param>
        /// <param name="notesId">notes id</param>
        /// <param name="color">color</param>
        /// <returns>color notes</returns>
        public NotesEntity ColorNotes(long userId, long notesId, string color)
        {
            try
            {
                return this.notesRL.ColorNotes(userId, notesId, color);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// trash notes
        /// </summary>
        /// <param name="userId">userid</param>
        /// <param name="notesId">notesid</param>
        /// <returns>trash notes</returns>
        public NotesEntity TrashNotes(long userId, long notesId)
        {
            try
            {
                return this.notesRL.TrashNotes(userId, notesId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// upload img
        /// </summary>
        /// <param name="notesId">notesid</param>
        /// <param name="image">image</param>
        /// <returns></returns>
        public NotesEntity UploadImage(long notesId, IFormFile image)
        {
            try
            {
                return this.notesRL.UploadImage( notesId, image);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}

