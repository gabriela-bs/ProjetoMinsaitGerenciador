using System.Collections.Generic;
using GerenciadorFinanca.Models;

namespace GerenciadorFinanca.Repositorio.IContratos
{
    public interface IDespesaRepositorio
    {
        Task AdicionarDespesa(Despesa despesa);
        Task EditarDespesa(Despesa despesa);
        Task Deletar(int id);
        Task <Despesa?> BuscarPorId(int Id);
        Task <IEnumerable<Despesa>> ListarGastos();

    }
}