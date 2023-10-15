using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyMDB.Model;

namespace MyMDB.Data.Model
{
    public class MyMDBContext : DbContext
    {
        public MyMDBContext (DbContextOptions<MyMDBContext> options)
            : base(options)
        {
        }

        public DbSet<MyMDB.Model.Movie> Movie { get; set; } = default!;
        public DbSet<MyMDB.Model.Star> Star { get; set; } = default!;
    }
}
