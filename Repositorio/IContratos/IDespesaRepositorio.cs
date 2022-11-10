using GerenciadorFinanca.Models;

namespace GerenciadorFinanca.Repositorio.IContratos
{
    public interface IDespesaRepositorio
    {
        Task AdicionarDespesa(Despesa despesa);
        Task EditarDespesa(int id, Despesa despesa);
        Task Deletar(int id);
        Task <Despesa?> BuscarPorId(int Id);
       Task <List<Despesa>> ListarGastos();     

    }
}