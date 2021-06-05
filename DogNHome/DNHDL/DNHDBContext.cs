using System;
using Microsoft.EntityFrameworkCore;
using DNHModels;


namespace DNHDL
{
    public class DNHDBContext : DbContext
    {
        public DNHDBContext() : base()
        {

        }
        // Constructer needed to pass in connection string
        public DNHDBContext(DbContextOptions options) : base(options)
        {

        }
        // Insert DBSets here for data models
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<ListedDog> DogLists { get; set; }
        public DbSet<DogList> ListedDogs { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Like> Likes { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Preference> Preferences { get; set; }
        public DbSet<Tags> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            


            modelBuilder.Entity<User>()
                .HasKey(user => user.UserName);
            modelBuilder.Entity<ListedDog>()
                .HasKey(LDog => new { LDog.ListID, LDog.DogID });
            modelBuilder.Entity<DogList>()
                .HasKey(list => list.ListID);
            modelBuilder.Entity<Dog>()
                .HasKey(dog => dog.DogID);

           
        }
    }
}
