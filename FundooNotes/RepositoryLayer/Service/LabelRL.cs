namespace RepositoryLayer.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using RepositoryLayer.Context;
    using RepositoryLayer.Entity;
    using RepositoryLayer.Interface;

    /// <summary>
    /// Label class
    /// </summary>
    public class LabelRL : ILabelRL
    {
        /// <summary>
        /// instance variable
        /// </summary>
        private readonly FundooContext fundooContext;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="fundooContext"> the fundoo context</param>
        public LabelRL(FundooContext fundooContext)
        {
            this.fundooContext = fundooContext;
        }

        /// <summary>
        /// method for create new label
        /// </summary>
        /// <param name="labelName">the label name</param>
        /// <param name="userId">the user id</param>
        /// <param name="noteId">the note id</param>
        /// <returns>Add label</returns>
        public LabelEntity AddLabel(string labelName, long userId, long noteId)
        {
            try
            {
                LabelEntity label = new LabelEntity();
                label.LabelName = labelName;
                label.NoteId = noteId;
                label.Id = userId;
                fundooContext.Label.Add(label);
                int result = fundooContext.SaveChanges();
                if (result > 0)
                {
                    return label;
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
        /// method for update label
        /// </summary>
        /// <param name="labelName">the label name</param>
        /// <param name="labelId">the label id</param>
        /// <param name="userId">the user id</param>
        /// <returns>update label</returns>
        public LabelEntity UpdateLabel(string labelName,  long labelId, long userId)
        {
            try
            {
                var result = fundooContext.Label.Where(e => e.LabelId == labelId && e.Id == userId).FirstOrDefault();
                if (result != null)
                {
                    result.LabelName = labelName;
                    fundooContext.Label.Update(result);
                    fundooContext.SaveChanges();
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
        /// method for delete label
        /// </summary>
        /// <param name="labelId">the label id</param>
        /// <returns>delete label</returns>
        public bool DeleteLabel(long labelId)
        {
            try
            {
                var result = fundooContext.Label.Where(e => e.LabelId == labelId).FirstOrDefault();
                if (result != null)
                {
                    fundooContext.Label.Remove(result);
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
        /// method for get all label by user id
        /// </summary>
        /// <param name="userId">the user id</param>
        /// <returns>label by user id</returns>
        public IEnumerable<LabelEntity> GetAllLabelbyUserid(long userId)
        {
            try
            {
                var result = fundooContext.Label.Where(e => e.Id == userId).ToList();
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
