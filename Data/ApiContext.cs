using System;
using GerenciadorFinanca.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorFinanca.Data

{
    public class ApiContext : DbContext
    {
        public DbSet<Despesa> Despesas { get; set; }

/*        public ApiContext(){
            
        }*/
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {      
        }
    }
}