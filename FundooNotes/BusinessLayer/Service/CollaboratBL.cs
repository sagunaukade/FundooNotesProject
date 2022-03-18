using BusinessLayer.Interface;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class CollaboratBL : ICollaboratBL
    {
        private readonly ICollaboratRL collabratorRL;

        public CollaboratBL(ICollaboratRL collabratorRL)
        {
            this.collabratorRL = collabratorRL;
        }
        public CollaboratEntity AddCollab(string email, long userId, long noteId)
        {
            try
            {
                return collabratorRL.AddCollab(email, userId, noteId);
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
                return collabratorRL.DeleteCollab(userId, collabid);
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
                    return collabratorRL.GetByNoteId(userId, notesId);
                }
                catch (Exception)
                {
                    throw;
                }
            

        }
    }
}
        