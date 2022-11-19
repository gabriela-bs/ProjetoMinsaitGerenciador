using GerenciadorFinanca.Data;
using Microsoft.EntityFrameworkCore;
using GerenciadorFinanca.Entidades;

namespace GerenciadorFinanca.Repositorio
{
    public class DespesaRepositorio
    {
        private readonly DbContextOptions<APIContexto> _OptionsBuilder;

        public DespesaRepositorio()
        {
            _OptionsBuilder = new DbContextOptions<APIContexto>();
        }

        public async Task<Despesa> GetEntityById(int Id)
        {
            using (var data = new APIContexto(_OptionsBuilder))
            {
                return await data.Set<Despesa>().FindAsync(Id);
            }
        }

        public async Task<List<Despesa>> List()
        {
            using (var data = new APIContexto(_OptionsBuilder))
            {
                return await data.Set<Despesa>().ToListAsync();
            }
        }

        public async Task Update(Despesa Objeto)
        {
            using (var data = new APIContexto(_OptionsBuilder))
            {
                data.Set<Despesa>().Update(Objeto);
                await data.SaveChangesAsync();
            }
        }
    }
}