namespace RepositoryLayer.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using CommonLayer.Model;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using RepositoryLayer.Context;
    using RepositoryLayer.Entity;
    using RepositoryLayer.Interface;

    /// <summary>
    /// notes class
    /// </summary>
    public class NotesRL : INotesRL
    {
        /// <summary>
        /// instance variable
        /// </summary>
        private readonly FundooContext fundooContext;
        private readonly IConfiguration configuration;

        /// <summary>
        /// instance a new instance of the <see cref="NotesRL"/> class.</summary>>
        /// <param name="fundooContext">the fundoo context</param>
        /// <param name="configuration">the configuration</param>
        public NotesRL(FundooContext fundooContext, IConfiguration configuration)
        {
            this.fundooContext = fundooContext;
            this.configuration = configuration;
        }

        /// <summary>
        /// method for create notes in database
        /// </summary>
        /// <param name="notesCreation">the note creation</param>
        /// <param name="userId">the user Id</param>
        /// <returns>create notes</returns>
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
                {
                    return newNotes;
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

        /// <summary>
        /// method for update notes in database
        /// </summary>
        /// <param name="updateNotes">the update notes</param>
        /// <param name="notesId">the notes id</param>
        /// <returns>update notes</returns>
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
                    ///update database for given notes id
                    fundooContext.Notes.Update(note);
                    int result = fundooContext.SaveChanges();
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

        /// <summary>
        /// method for delete notes
        /// </summary>
        /// <param name="id">the id</param>
        /// <param name="noteId">the note Id</param>
        /// <returns>delete notes</returns>
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

        /// <summary>
        /// archive notes
        /// </summary>
        /// <param name="userId">user Id</param>
        /// <param name="notesId">note Id</param>
        /// <returns>archive notes</returns>
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

        /// <summary>
        /// pinned
        /// </summary>
        /// <param name="userId">user Id</param>
        /// <param name="notesId">notes Id</param>
        /// <returns>pinned notes</returns>
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

        /// <summary>
        /// color
        /// </summary>
        /// <param name="userId">user Id</param>
        /// <param name="notesId">note Id</param>
        /// <param name="color">color</param>
        /// <returns>color notes</returns>
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

        /// <summary>
        /// trash
        /// </summary>
        /// <param name="userId">user Id</param>
        /// <param name="notesId">notes Id</param>
        /// <returns>trash</returns>
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

        /// <summary>
        /// upload image
        /// </summary>
        /// <param name="notesId">notes Id</param>
        /// <param name="image">image</param>
        /// <returns>upload image</returns>
        public NotesEntity UploadImage(long notesId, IFormFile image)
        {
            try
            {
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
