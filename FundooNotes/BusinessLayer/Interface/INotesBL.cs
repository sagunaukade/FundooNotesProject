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
        public NotesEntity NotesCreation(NotesCreation notesCreation, long notesId);
        public NotesEntity UpdateNotes(UpdateNotes updateNotes, long notesId);
        public bool DeleteNotes(long id, long noteId);
        public IEnumerable<NotesEntity> RetrieveAllNotes(long userId);
        public NotesEntity ArchiveNotes(long userId, long notesId);
        public NotesEntity PinnedNotes(long userId, long notesId);
        public NotesEntity ColorNotes(long userId, long notesId, string color);
        public NotesEntity TrashNotes(long userId, long notesId);
        public NotesEntity UploadImage(long notesId, IFormFile image);

    }
}
