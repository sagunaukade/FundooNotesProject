namespace RepositoryLayer.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using RepositoryLayer.Entity;
   
    /// <summary>
    /// interface class 
    /// </summary>
    public interface ILabelRL
    {

        /// <summary>Creates the label.</summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="notesId">The notes identifier.</param>
        /// <param name="labelName">The email.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public LabelEntity AddLabel(string labelName, long userId, long noteId);

        /// <summary>Updates the label.</summary>
        /// <param name="labelName">Name of the label.</param>
        /// <param name="labelId">The notes identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public LabelEntity UpdateLabel(string labelName, long labelId, long userId);

        /// <summary>Delete label the specified user identifier.</summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="labelId">The label identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public bool DeleteLabel(long labelId);

        /// <summary>Delete label the specified user identifier.</summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public IEnumerable<LabelEntity> GetAllLabelbyUserid(long userId);
    }
}
