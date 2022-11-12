using System;
using System.ComponentModel.DataAnnotations;
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

            try
            {
                await _apiContext.Set<Despesa>().AddRangeAsync(despesa);
                await _apiContext.SaveChangesAsync();
            }
            catch { 
                throw;
            }

        }

        public async Task<Despesa?> BuscarPorId(int id){
        try
        {
            return await _apiContext.Set<Despesa>().FindAsync(id);
            
        }
        catch (Exception e)
        {
            
            throw new ArgumentException("Ocorreu um erro na busca");
        }
        }

        public async Task EditarDespesa(int id, Despesa despesa){

            _apiContext.Set<Despesa>().Update(despesa);
            await _apiContext.SaveChangesAsync();
            
        }

        public async Task Deletar(int id){
            var item = await BuscarPorId(id);
            _apiContext.Set<Despesa>().Remove(item);
            await _apiContext.SaveChangesAsync();
        }
        
        public async Task<List<Despesa>> ListarGastos(){

            return await _apiContext.Set<Despesa>().AsNoTracking().ToListAsync(); 
        
        }

/*        public async Task<Despesa> TotalGastos(){
           decimal valorTotal = _apiContext.Despesas.Where(val => val.DespesaData > DateTime.Now)
            .Select(val => val.Valor)
            .Sum();

        return decimal valorTotal;
            ;
        }*/


    }
}
