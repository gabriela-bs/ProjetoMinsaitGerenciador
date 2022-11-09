using GerenciadorFinanca.Data;
using GerenciadorFinanca.Models;


namespace GerenciadorFinanca.Repositorio
{
    public class DespesaRepositorio : IDespesaRepositorio
    {
        private readonly ApiContext _apiContext;

        public DespesaRepositorio(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        public Despesa AdicionarDespesa(Despesa despesa) 
        {
            _apiContext.Despesas.Add(despesa);
            _apiContext.SaveChanges();

            return despesa;
        }

        public List<Despesa> ListarGastos() {

            return _apiContext.Despesas.ToList();
        }

        public Despesa BuscarPorId(int Id){
            return _apiContext.Despesas.FirstOrDefault(x => x.Id == Id);
        }

    }
}