using BusinessLayer.Interface;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class LabelBL : ILabelBL
    {

        private readonly ILabelRL labelRL;

       
        public LabelBL(ILabelRL labelRL)
        {
            this.labelRL = labelRL;
        }
       
        public LabelEntity AddLabel(string labelName, long userId, long noteId)
        {
            try
            {

                return labelRL.AddLabel(labelName, userId, noteId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public LabelEntity UpdateLabel(string labelName, long labelId, long userId)
        {
           
                try
                {

                    return labelRL.UpdateLabel(labelName, labelId, userId);
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

                return labelRL.DeleteLabel(labelId);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
    }
    

