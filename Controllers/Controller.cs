using GerenciadorFinanca.Data;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorFinanca.Controllers
{
    public class Controller : ControllerBase
    {
        private readonly ApiContext _contexto;

        public Controller(ApiContext contexto){
            _contexto = contexto;
        }

    }
}