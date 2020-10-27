using FeedbackExample.Repository.SQL.PersistenceEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackExample.Repository.SQL.DataAccess
{
    //klasa pomocu koje se prave migracije
    //DbSet je u stvari skup podataka koji se cuva
    //Migracije sam kreira Entity Framework, tj one su izvrsni kod za bazu (tu je kod za kriranje tabela, kljuceva itd...)
    public class FeedbackDbContext : DbContext
    {
        public DbSet<FeedbackPersistence> Feedbacks { get; set; }
        public DbSet<UserPersistence> Users { get; set; }

        public FeedbackDbContext(DbContextOptions options) : base(options) { }

        public FeedbackDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"");
        }

    }
}
