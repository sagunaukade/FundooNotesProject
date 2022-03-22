using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Context
{
    //DbContext is used to communicate with database
    public class FundooContext : DbContext
    {
        public FundooContext(DbContextOptions options)
            : base(options)
        {
        }
        //dbset is used to view database and communicate with table in database
        public DbSet<UserEntity> User { get; set; }
        public DbSet<NotesEntity> Notes { get; set; }
        public DbSet<CollaboratEntity> Collab { get; set; }
        public DbSet<LabelEntity> Label { get; set; }
    }
}
