namespace RepositoryLayer.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using RepositoryLayer.Entity;

    /// <summary>
    /// interface class 
    /// </summary>
    public interface ICollaboratRL
    {
        /// <summary>Creates the collab.</summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="notesId">The notes identifier.</param>
        /// <param name="email">The email.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public CollaboratEntity AddCollab(string email, long userId, long noteId);

        /// <summary>Removes the collab.</summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="collabId">The COLLAB identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public bool DeleteCollab(long userId, long collabid);

        /// <summary>VGet all collaborators.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public IEnumerable<CollaboratEntity> GetAllCollab();
    }
}
