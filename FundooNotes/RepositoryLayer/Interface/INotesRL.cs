namespace RepositoryLayer.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using RepositoryLayer.Entity;
    using CommonLayer.Model;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// interface class
    /// </summary>
    public interface INotesRL
    {
        public NotesEntity NotesCreation(NotesCreation notesCreation, long notesId);
        public NotesEntity UpdateNotes(UpdateNotes updateNotes, long notesId);

        bool DeleteNotes(long id, long noteId);

        /// <summary>
        /// method for retrieve all notes
        /// </summary>
        /// <param name="userId">the user id</param>
        /// <returns>retrieve all notes</returns>
        IEnumerable<NotesEntity> RetrieveAllNotes(long userId);

        /// <summary>
        /// method for archive notes
        /// </summary>
        /// <param name="userId">the user id</param>
        /// <param name="notesId">the notes id</param>
        /// <returns>Archive Notes</returns>
        public NotesEntity ArchiveNotes(long userId, long notesId);

        /// <summary>
        /// method for pinned notes
        /// </summary>
        /// <param name="userId">the user id</param>
        /// <param name="notesId">the notes id</param>
        /// <returns>Pinned Notes</returns>
        public NotesEntity PinnedNotes(long userId, long notesId);

        /// <summary>
        /// method for color notes
        /// </summary>
        /// <param name="userId">the user id</param>
        /// <param name="notesId">the notes id</param>
        /// <param name="color">the color</param>
        /// <returns>Color Notes</returns>
        public NotesEntity ColorNotes(long userId, long notesId, string color);

        /// <summary>
        /// method for trashed notes
        /// </summary>
        /// <param name="userId">the user id</param>
        /// <param name="notesId">notes id</param>
        /// <returns>Trash Notes</returns>
        public NotesEntity TrashNotes(long userId, long notesId);

        /// <summary>
        /// method for upload image 
        /// </summary>
        /// <param name="notesId">notes id</param>
        /// <param name="image">the image</param>
        /// <returns>upload image</returns>
        public NotesEntity UploadImage(long notesId, IFormFile image);
    }
}
