namespace RepositoryLayer.Context
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using RepositoryLayer.Entity;

    /// <summary>
    ///DbContext is used to communicate with database
    /// </summary>
    
    public class FundooContext : DbContext
    {

        /// <summary>Initializes a new instance of the <see cref="FundooContext" /> class.</summary>
        /// <param name="options">The options for this context.</param>
        public FundooContext(DbContextOptions options)
            : base(options)
        {
        }

        /// <summary>Gets or sets the user table.</summary>
        /// <value>The user table.</value>
        public DbSet<UserEntity> User { get; set; }

        /// <summary>Gets or sets the notes table.</summary>
        /// <value>The notes table.</value>
        public DbSet<NotesEntity> Notes { get; set; }

        /// <summary>Gets or sets the collaborator table.</summary>
        /// <value>The collaborator table.</value>
        public DbSet<CollaboratEntity> Collab { get; set; }

        /// <summary>Gets or sets the label table.</summary>
        /// <value>The label table.</value>
        public DbSet<LabelEntity> Label { get; set; }
    }
}
