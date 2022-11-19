using GerenciadorFinanca.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using GerenciadorFinanca.Entidades;

namespace GerenciadorFinanca.Data

{
    
    public class APIContexto : IdentityDbContext<AplicacaoUsuario>
    {
        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<AplicacaoUsuario> AplicacaoUsuario { get; set; }
        
        public APIContexto(DbContextOptions<APIContexto> options) : base(options)
        {      
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {      

            builder.Entity<AplicacaoUsuario>().ToTable("AspNetUsers").HasKey(t => t.Id);

            base.OnModelCreating(builder);

        }


    }
}