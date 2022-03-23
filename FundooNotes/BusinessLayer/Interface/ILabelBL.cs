namespace BusinessLayer.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using RepositoryLayer.Entity;
   
    /// <summary>
    /// interface class
    /// </summary>
    public interface ILabelBL
    {
        /// <summary>
        /// method for create label
        /// </summary>
        /// <param name="labelName">the Label name</param>
        /// <param name="userId">the user Id</param>
        /// <param name="noteId">the note Id</param>
        /// <returns>add label</returns>
        public LabelEntity AddLabel(string labelName, long userId, long noteId);

        /// <summary>
        /// method for update label in database
        /// </summary>
        /// <param name="labelName">the Label name</param>
        /// <param name="labelId">the user label Id</param>
        /// <param name="userId">the user Id</param>
        /// <returns>update label</returns>
        public LabelEntity UpdateLabel(string labelName,  long labelId, long userId);

        /// <summary>
        /// method for delete label in database by using label Id
        /// </summary>
        /// <param name="labelId">the label id</param>
        /// <returns>delete label</returns>
        public bool DeleteLabel(long labelId);

        /// <summary>
        /// get all label by user id
        /// </summary>
        /// <param name="userId">the user Id</param>
        /// <returns>get all label by user Id</returns>
        public IEnumerable<LabelEntity> GetAllLabelbyUserid(long userId);
    }
}
