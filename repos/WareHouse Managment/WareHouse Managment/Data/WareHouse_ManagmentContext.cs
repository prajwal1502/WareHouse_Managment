using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WareHouse_Managment.Models;

namespace WareHouse_Managment.Data
{
    public class WareHouse_ManagmentContext : DbContext
    {
        public WareHouse_ManagmentContext (DbContextOptions<WareHouse_ManagmentContext> options)
            : base(options)
        {
        }

        public DbSet<WareHouse_Managment.Models.Cloth> Cloth { get; set; } = default!;

        public DbSet<WareHouse_Managment.Models.BOH> BOH { get; set; } = default!;

        public DbSet<WareHouse_Managment.Models.FOH> FOH { get; set; } = default!;
    }
}
