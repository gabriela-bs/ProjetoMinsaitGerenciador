using System;
using GerenciadorFinanca.Models;
using Microsoft.EntityFrameworkCore;


namespace GerenciadorFinanca.Data

{
    public class ApiContext : DbContext
    {
        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {      
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {      
            builder.Entity<Despesa>()
            .HasOne (r => r.Usuario)
            .WithMany(c => c.Despesas)
            .HasForeignKey(r => r.DespFK)
            ;
        }
    }
}