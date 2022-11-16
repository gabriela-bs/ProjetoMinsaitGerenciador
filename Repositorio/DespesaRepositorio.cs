using GerenciadorFinanca.Data;
using GerenciadorFinanca.Models;
using GerenciadorFinanca.Repositorio.IContratos;
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

      public async Task<IEnumerable<Despesa>> ListarGastos(){

         return await _apiContext.Despesas.AsNoTracking().ToListAsync();
        
    }

        public async Task AdicionarDespesa(Despesa despesa){

            _apiContext.Despesas.AddAsync(despesa);
            await _apiContext.SaveChangesAsync();

        }

        public async Task<Despesa> BuscarPorId(int id){
        
           return await _apiContext.Despesas.FindAsync(id); 
    }

        public async Task EditarDespesa(Despesa despesa){

            _apiContext.Entry(despesa).State = EntityState.Modified;


            try{

                await _apiContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException){

            }
            
        }

        public async Task Deletar(int id){
     
            var item = await BuscarPorId(id);
            _apiContext.Despesas.Remove(item);
            await _apiContext.SaveChangesAsync();
        }

    }
}



/*        public async Task<Despesa> TotalGastos(){
           decimal valorTotal = _apiContext.Despesas.Where(val => val.DespesaData > DateTime.Now)
            .Select(val => val.Valor)
            .Sum();

        return decimal valorTotal;
            ;

        }*/
