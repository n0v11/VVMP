using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class ApplicationsContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=../Library/testdb.db"); // используется sqlite
        }
        public DbSet<User> Users { get; set; }
    }
}
