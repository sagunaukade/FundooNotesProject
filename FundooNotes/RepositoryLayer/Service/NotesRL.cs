using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
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
        private readonly IConfiguration configuration;


        public NotesRL(FundooContext fundooContext, IConfiguration configuration)
        {
            this.fundooContext = fundooContext;
            this.configuration = configuration;
        }
        public NotesEntity NotesCreation(NotesCreation notesCreation, long userId)
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
        public NotesEntity ArchiveNotes(long userId, long notesId)
        {
            try
            {
                NotesEntity note = this.fundooContext.Notes.FirstOrDefault(x => x.Id == userId && x.NotesId == notesId);
                if (note != null)
                {
                    bool checkArchive = note.IsArchieve;
                    if (checkArchive == true)
                    {
                        note.IsArchieve = false;
                    }

                    if (checkArchive == false)
                    {
                        note.IsArchieve = true;
                    }

                    this.fundooContext.SaveChanges();
                    return note;
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
        public NotesEntity PinnedNotes(long userId, long notesId)
        {
            try
            {
                NotesEntity note = this.fundooContext.Notes.FirstOrDefault(x => x.Id == userId && x.NotesId == notesId);
                if (note != null)
                {
                    bool checkPin = note.IsPinned;
                    if (checkPin == true)
                    {
                        note.IsPinned = false;
                    }

                    if (checkPin == false)
                    {
                        note.IsPinned = true;
                    }
                    this.fundooContext.SaveChanges();
                    return note;
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
        public NotesEntity ColorNotes(long userId, long notesId, string color)
        {
            try
            {
                NotesEntity note = this.fundooContext.Notes.FirstOrDefault(x => x.Id == userId && x.NotesId == notesId);
                if (note != null)
                {
                    note.Color = color;
                    fundooContext.Notes.Update(note);
                    this.fundooContext.SaveChanges();
                    return note;
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
        public NotesEntity TrashNotes(long userId, long notesId)
        {
            try
            {
                NotesEntity note = this.fundooContext.Notes.FirstOrDefault(x => x.Id == userId && x.NotesId == notesId);
                if (note != null)
                {
                    bool checkTrash = note.IsTrash;
                    if (checkTrash == true)
                    {
                        note.IsTrash = false;
                    }

                    if (checkTrash == false)
                    {
                        note.IsTrash = true;
                    }

                    this.fundooContext.SaveChanges();
                    return note;
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
        public NotesEntity UploadImage(long notesId, IFormFile image)
        {
            try
            {
                // Fetch All the details with the given noteId and userId
                var note = this.fundooContext.Notes.FirstOrDefault(n => n.NotesId == notesId);
                if (note != null)
                {
                    Account acc = new Account(configuration["Cloudinary:CloudName"], configuration["Cloudinary:ApiKey"], configuration["Cloudinary:ApiSecret"]);
                    Cloudinary cloud = new Cloudinary(acc);
                    var imagePath = image.OpenReadStream();
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(image.FileName, imagePath),
                    };
                    var uploadResult = cloud.Upload(uploadParams);
                    note.Image = image.FileName;
                    this.fundooContext.Notes.Update(note);
                    int upload = this.fundooContext.SaveChanges();
                    if (upload > 0)
                        return note;
                    else
                    {
                        return null;
                    }
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
