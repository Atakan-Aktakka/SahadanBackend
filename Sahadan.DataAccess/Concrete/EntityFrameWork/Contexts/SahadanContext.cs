using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sahadan.Entities.Concrete;

namespace Sahadan.DataAccess.Concrete.EntityFrameWork.Contexts
{
    public class SahadanContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Sahadan;User Id=SA;Password=reallyStrongPwd123;Encrypt=false;TrustServerCertificate=True;");
        }
        public DbSet<Country> Countrys { get; set; }
        public DbSet<Legue> Legues { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}