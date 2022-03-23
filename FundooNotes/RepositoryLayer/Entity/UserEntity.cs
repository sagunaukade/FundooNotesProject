namespace RepositoryLayer.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    /// <summary>
    /// class user entity
    /// </summary>
    public class UserEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public long Id { get; set; }

        /// <summary>Gets or sets the first name.</summary>
        /// <value>The first name.</value>
        public string FirstName { get; set; }

        /// <summary>Gets or sets the last name.</summary>
        /// <value>The last name.</value>
        public string LastName { get; set; }

        /// <summary>Gets or sets the email.</summary>
        /// <value>The email.</value>
        public string Email { get; set; }

        /// <summary>Gets or sets the password.</summary>
        /// <value>The password.</value>
        public string Password { get; set; }

        /// <summary>Gets or sets the created at.</summary>
        /// <value>The created at.</value>
        public DateTime? CreatedAt { get; set; }

        /// <summary>Gets or sets the edited at.</summary>
        /// <value>The edited at.</value>
        public DateTime? ModifiedAt { get; set; }
    }
}
