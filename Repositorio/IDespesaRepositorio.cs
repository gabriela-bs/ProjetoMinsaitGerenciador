//fica os contratos - métodos do crud
using GerenciadorFinanca.Models;

namespace GerenciadorFinanca.Repositorio
{
    public interface IDespesaRepositorio
    {   
        
        Despesa BuscarPorId(int Id);
        List<Despesa> ListarGastos();
        Despesa AdicionarDespesa(Despesa despesa);
    }
}