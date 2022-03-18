using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface ICollaboratRL
    {
        public CollaboratEntity AddCollab(string email, long userId, long noteId);
        public bool DeleteCollab(long userId, long collabid);
        public IEnumerable<CollaboratEntity> GetByNoteId(long userId, long notesId);



    }
}
