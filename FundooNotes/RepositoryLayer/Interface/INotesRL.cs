using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using RepositoryLayer.Entity;
using CommonLayer.Model;

namespace RepositoryLayer.Interface
{
    public interface INotesRL
    {
        public NotesEntity NotesCreation(NotesCreation notesCreation, long notesId);
        public NotesEntity UpdateNotes(UpdateNotes updateNotes, long notesId);
        bool DeleteNotes(long id, long noteId);
        IEnumerable<NotesEntity> RetrieveAllNotes(long userId);
    }
}
