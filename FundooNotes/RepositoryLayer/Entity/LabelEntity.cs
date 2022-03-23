namespace RepositoryLayer.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    /// <summary>
    /// class label entity
    /// </summary>
    public class LabelEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        /// <summary>Gets or sets the label identifier.</summary>
        /// <value>The label identifier.</value>
        public long LabelId { get; set; }

        /// <summary>Gets or sets the name of the label.</summary>
        /// <value>The name of the label.</value>
        public string LabelName { get; set; }

        [ForeignKey("notes")]
        
        ///  /// <summary>Gets or sets the notes identifier.</summary>
        /// <value>The notes identifier.</value>
        public long NoteId { get; set; }
        
        /// /// <summary>Gets or sets the notes.</summary>
        /// <value>The notes.</value>
        public NotesEntity notes { get; set; }

        [ForeignKey("user")]
        
        /// /// <summary>Gets or sets the user.</summary>
        /// <value>The user.</value>
        public long Id { get; set; }

        /// /// <summary>Gets or sets the user.</summary>
        /// <value>The user.</value>
        public UserEntity user { get; set; }
    }
}
