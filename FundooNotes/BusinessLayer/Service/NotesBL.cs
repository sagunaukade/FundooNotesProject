using BusinessLayer.Interface;
using CommonLayer.Model;
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
        //Method to return create note obj to Repository Layer notes.
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
    }
}

   