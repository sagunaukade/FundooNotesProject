using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Context
{

    public class FundooContext : DbContext
    {
        public FundooContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<NotesEntity> Notes { get; set; }
        public DbSet<CollaboratEntity> Collab { get; set; }
        public DbSet<LabelEntity> Label { get; set; }
    }
}
