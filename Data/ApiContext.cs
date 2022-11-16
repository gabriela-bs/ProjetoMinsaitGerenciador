using GerenciadorFinanca.Models;
using Microsoft.EntityFrameworkCore;
using GerenciadorFinanca.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace GerenciadorFinanca.Data

{
    public class ApiContext : IdentityDbContext
    {
       public DbSet<Despesa> Despesas { get; set; }
        
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {      
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {      

            base.OnModelCreating(builder);

        }


    }
}