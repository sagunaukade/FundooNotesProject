using CommonLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
   public interface INotesBL
   {
        public NotesEntity NotesCreation(NotesCreation notesCreation, long notesId);
        public NotesEntity UpdateNotes(UpdateNotes updateNotes, long notesId);
        public bool DeleteNotes(long id, long noteId);
        public IEnumerable<NotesEntity> RetrieveAllNotes(long userId);



    }
}
