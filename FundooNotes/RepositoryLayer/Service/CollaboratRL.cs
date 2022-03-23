namespace RepositoryLayer.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Extensions.Configuration;
    using RepositoryLayer.Context;
    using RepositoryLayer.Entity;
    using RepositoryLayer.Interface;

    /// <summary>
    /// collaborator class
    /// </summary>
    public class CollaboratRL : ICollaboratRL
    {
        /// <summary>
        /// instance variables
        /// </summary>
        private readonly FundooContext fundooContext;

        /// <summary>
        /// instance variable
        /// </summary>
        private readonly IConfiguration appSettings;

        /// <summary>
        /// initialize new instance of the <see cref="CollaboratRL"/> class.</summary>
        /// <param name="fundooContext"> the fundooContext</param>
        /// <param name="appSettings">the appSettings</param>
        public CollaboratRL(FundooContext fundooContext, IConfiguration appSettings)
        {
            this.fundooContext = fundooContext;
            this.appSettings = appSettings;
        }

        /// <summary>
        /// method for add collaborator with register user
        /// </summary>
        /// <param name="email">the email</param>
        /// <param name="userId">the user id</param>
        /// <param name="noteId">the note id</param>
        /// <returns>add collaborator</returns>
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

        /// <summary>
        /// method for delete collab
        /// </summary>
        /// <param name="userId">the user id</param>
        /// <param name="collabid">the collaborator id</param>
        /// <returns>delete collaborator</returns>
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

        /// <summary>
        /// method for get all collaborator in database
        /// </summary>
        /// <returns>get all collaborator</returns>
        public IEnumerable<CollaboratEntity> GetAllCollab()
        {
            try
            {
                var collabs = fundooContext.Collab.ToList();
                if (collabs != null)
                {
                    return collabs;
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
