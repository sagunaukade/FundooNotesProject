using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Service
{
    public class LabelRL : ILabelRL
    {

        private readonly FundooContext fundooContext;
        public LabelRL(FundooContext fundooContext)
        {
            this.fundooContext = fundooContext;
        }
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
        public LabelEntity UpdateLabel(string labelName,  long labelId, long userId)
        {
            try
            {
                var result = fundooContext.Label.Where(e => e.LabelId == labelId && e.Id ==userId).FirstOrDefault();
                if (result != null)
                {
                    //  LabelEntity label = new LabelEntity();
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
