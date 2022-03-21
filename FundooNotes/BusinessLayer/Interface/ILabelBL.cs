using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
   public interface ILabelBL
    {
        public LabelEntity AddLabel(string labelName, long userId, long noteId);
        public LabelEntity UpdateLabel(string labelName,  long labelId, long userId);
        public bool DeleteLabel(long labelId);
        public IEnumerable<LabelEntity> GetAllLabelbyUserid(long userId);
    }
}
