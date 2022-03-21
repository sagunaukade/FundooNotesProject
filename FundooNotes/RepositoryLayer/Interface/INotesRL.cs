using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using RepositoryLayer.Entity;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;

namespace RepositoryLayer.Interface
{
    public interface INotesRL
    {
        public NotesEntity NotesCreation(NotesCreation notesCreation, long notesId);
        public NotesEntity UpdateNotes(UpdateNotes updateNotes, long notesId);
        bool DeleteNotes(long id, long noteId);
        IEnumerable<NotesEntity> RetrieveAllNotes(long userId);
        public NotesEntity ArchiveNotes(long userId, long notesId);
        public NotesEntity PinnedNotes(long userId, long notesId);
        public NotesEntity ColorNotes(long userId, long notesId, string color);
        public NotesEntity TrashNotes(long userId, long notesId);
        public NotesEntity UploadImage(long notesId, IFormFile image);
    }
}
