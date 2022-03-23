namespace BusinessLayer.Interface
{
    using RepositoryLayer.Entity;
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// interface class
    /// </summary>
    public interface ICollaboratBL
    {
        /// <summary>
        /// method for create collab
        /// </summary>
        /// <param name="email"> the email</param>
        /// <param name="userId">the user Id</param>
        /// <param name="noteId">the note Id</param>
        /// <returns>add collab</returns>
        public CollaboratEntity AddCollab(string email, long userId, long noteId);

        /// <summary>
        /// method for delete collab
        /// </summary>
        /// <param name="userId">the user Id</param>
        /// <param name="collabid">the collab Id</param>
        /// <returns>delete collab</returns>
        public bool DeleteCollab(long userId, long collabid);

        /// <summary>
        /// method for get all collab in database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CollaboratEntity> GetAllCollab();
    }
}
