using Microsoft.VisualStudio.Services.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.Entity
{
    public class CollaboratEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long CollaboratId { get; set; }
        public string CollaboratEmail { get; set; }
        [ForeignKey("user")]  
        public long Id { get; set; }
        public UserEntity user { get; set; }

        
        [ForeignKey("note")]
        public long NotesId { get; set; }
        public NotesEntity note { get; set; }


    }
}
