using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Service
{
    public class NotesRL : INotesRL
    {
       
        private readonly FundooContext fundooContext;
        private readonly IConfiguration _Toolsettings;
        public NotesRL(FundooContext fundooContext, IConfiguration _Toolsettings)
        {
            this.fundooContext = fundooContext;
            this._Toolsettings = _Toolsettings;
        }

        public NotesEntity NotesCreation(NotesCreation notesCreation , long userId)
        {
            try
            {
                NotesEntity newNotes = new NotesEntity();
                newNotes.Title = notesCreation.Title;
                newNotes.Description = notesCreation.Description;
                newNotes.Color = notesCreation.Color;
                newNotes.Image = notesCreation.Image;
                newNotes.IsArchieve = notesCreation.IsArchieve;
                newNotes.IsTrash = notesCreation.IsTrash;
                newNotes.IsPinned = notesCreation.IsPinned;
                newNotes.CreatedAt = notesCreation.CreatedAt;
                newNotes.ModifiedAt = notesCreation.ModifiedAt;
                newNotes.Id = userId;
                fundooContext.Notes.Add(newNotes);
                int result = fundooContext.SaveChanges();
                if (result > 0)
                    return newNotes;
                else
                    return null;
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
                var note = fundooContext.Notes.Where(update => update.NotesId == notesId).FirstOrDefault();
                if (note != null)
                {
                    note.Title = updateNotes.Title;
                    note.Description = updateNotes.Description;
                    note.Color = updateNotes.Color;
                    note.Image = updateNotes.Image;
                    note.ModifiedAt = updateNotes.ModifiedAt;
                    note.Id = notesId;
                    fundooContext.Notes.Update(note);
                    int result = fundooContext.SaveChanges();
                    return note;
                }

                else
                    return null;
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
                var result = fundooContext.Notes.Where(e => e.Id == id && e.NotesId == noteId).FirstOrDefault();

                if (result != null)
                {
                    fundooContext.Notes.Remove(result);
                    fundooContext.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        // methods for retrieve notes details by note id 
        public IEnumerable<NotesEntity> RetrieveAllNotes(long userId)
        {
            try
            {
                var result = fundooContext.Notes.Where(e => e.Id == userId).ToList();
                if (result != null)
                {

                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}