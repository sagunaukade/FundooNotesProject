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
        //Constructor
        public NotesBL(INotesRL notesRL)
        {
            this.notesRL = notesRL;
        }
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

