using System.Collections.Generic;
using GerenciadorFinanca.Data;
using GerenciadorFinanca.Models;
using GerenciadorFinanca.Repositorio.IContratos;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace GerenciadorFinanca.Repositorio
{
    public class DespesaRepositorio : IDespesaRepositorio
    {
        private readonly ApiContext _apiContext;

        public DespesaRepositorio(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }


        public async Task AdicionarDespesa(Despesa despesa){
             await _apiContext.Set<Despesa>().AddRangeAsync(despesa);

        }

        public async Task<Despesa?> BuscaPorId(int id){
            return await _apiContext.Set<Despesa>().FindAsync(id);
        }

        public async Task EditarDespesa(int id, Despesa despesa){
             _apiContext.Set<Despesa>().Update(despesa);
            await _apiContext.SaveChangesAsync();
            
        }

        public async Task Deletar(int id){
            var item = await BuscaPorId(id);
            _apiContext.Set<Despesa>().Remove(item);
            await _apiContext.SaveChangesAsync();
        }

        public Task<Despesa?> BuscarPorId(int Id)
        {
            throw new NotImplementedException();
        }
        
           public async Task<List<Despesa>> ListarGastos(){
                   return await _apiContext.Set<Despesa>().AsNoTracking().ToListAsync(); 
                }


    }
}
