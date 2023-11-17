using Client.Domain;
using Client.Domain.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Infrastructure.DBContext
{
    public class ClienteDbContext : DbContext 
    {
        public ClienteDbContext(DbContextOptions<ClienteDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Cliente>().OwnsOne(p => p.Persona);		
        }   
        public DbSet<Cliente> Clientes { get; set; }
      
    }
}
    