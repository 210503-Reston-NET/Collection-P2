using System;
using Microsoft.EntityFrameworkCore;

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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
