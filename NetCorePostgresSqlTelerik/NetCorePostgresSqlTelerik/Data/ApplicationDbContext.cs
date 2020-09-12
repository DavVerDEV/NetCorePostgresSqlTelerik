using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetCorePostgresSqlTelerik.Models;

namespace NetCorePostgresSqlTelerik.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Corsi> Corsi { get; set; }

        public DbSet<Prenotazioni> Prenotazioni { get; set; }
    }
}
