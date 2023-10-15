using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InvManagement1.models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvManagement1.Data
{
    public class InvManagement1Context : DbContext
    {
        public InvManagement1Context (DbContextOptions<InvManagement1Context> options)
            : base(options)
        {
        }

        public DbSet<InvManagement1.models.Product> Product { get; set; } = default!;

        public DbSet<InvManagement1.models.Catogory> Catogory { get; set; } = default!;

        public DbSet<InvManagement1.models.Supplier> Supplier { get; set; } = default!;
    }
}








