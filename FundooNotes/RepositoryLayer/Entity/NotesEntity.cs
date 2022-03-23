namespace RepositoryLayer.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    /// <summary>
    /// notes entity
    /// </summary>
    public class NotesEntity
    {
        /// <summary>Gets or sets the notes identifier.</summary>
        /// <value>The notes identifier.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long NotesId { get; set; }

        /// <summary>Gets or sets the title.</summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>Gets or sets the description.</summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>Gets or sets the reminder.</summary>
        /// <value>The reminder.</value>
        public DateTime Reminder { get; set; }

        /// <summary> Gets or sets the description. </summary>
        /// <value>The color.</value>
        public string Color { get; set; }

        /// <summary>Gets or sets the image.</summary>
        /// <value>The image.</value>
        public string Image { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance is ARCHIEVE.</summary>
        /// <value>
        /// <c>true</c> if this instance is ARCHIEVE; otherwise, <c>false</c>.</value>
        public bool IsArchieve { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance is trash.</summary>
        /// <value>
        /// <c>true</c> if this instance is trash; otherwise, <c>false</c>.</value>
        public bool IsTrash { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance is pin.</summary>
        /// <value>
        /// <c>true</c> if this instance is pin; otherwise, <c>false</c>.</value>
        public bool IsPinned { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        [ForeignKey("user")]
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public long Id { get; set; }

        /// <summary>Gets or sets the user.</summary>
        /// <value>The user.</value>
        public UserEntity user { get; set; }
    }
}

