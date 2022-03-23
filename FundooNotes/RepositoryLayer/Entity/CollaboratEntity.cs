namespace RepositoryLayer.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;
    using Microsoft.VisualStudio.Services.Users;
    
    /// <summary>
    /// class collaborator entity
    /// </summary>
    public class CollaboratEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        /// <summary>Gets or sets the collab identifier.</summary>
        /// <value>The collab identifier.</value>
        public long CollaboratId { get; set; }

        /// <summary>Gets or sets the COLLAB email.</summary>
        /// <value>The collab email.</value>
        public string CollaboratEmail { get; set; }

        [ForeignKey("user")]

        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public long Id { get; set; }

        /// <summary>Gets or sets the user.</summary>
        /// <value>The user.</value>
        public UserEntity user { get; set; }

        
        [ForeignKey("note")]

        /// <summary>Gets or sets the notes identifier.</summary>
        /// <value>The notes identifier.</value>
        public long NotesId { get; set; }

        /// <summary>Gets or sets the notes.</summary>
        /// <value>The notes.</value>
        public NotesEntity note { get; set; }
    }
}
