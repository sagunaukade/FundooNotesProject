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
    public class CollaboratRL : ICollaboratRL
    {
        private readonly FundooContext fundooContext;
        private readonly IConfiguration _appSettings;

        public CollaboratRL(FundooContext fundooContext, IConfiguration _appSettings)
        {
            this.fundooContext = fundooContext;
            this._appSettings = _appSettings;
        }
        public CollaboratEntity AddCollab(string email, long userId, long noteId)
        {
            try
            {
                var result = fundooContext.User.FirstOrDefault(e => e.Email == email);

                if (result.Email == email)
                {
                    CollaboratEntity collab = new CollaboratEntity();
                    collab.CollaboratEmail = email;
                    collab.Id = userId;
                    collab.NotesId = noteId;
                    fundooContext.Collab.Add(collab);
                    fundooContext.SaveChanges();
                    return collab;
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
        public bool DeleteCollab(long userId, long collabid)
        {
            try
            {
                var result = fundooContext.Collab.Where(e => e.Id == userId && e.CollaboratId == collabid).FirstOrDefault();
                if (result != null)
                {
                    fundooContext.Collab.Remove(result);
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
       
        public IEnumerable<CollaboratEntity> GetByNoteId(long userId, long notesId)
        {

            try
            {
                //Fetch All the details from Collab Table
                var collabs = fundooContext.Collab.ToList();
                if (collabs != null)
                {
                    return collabs;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    
}
