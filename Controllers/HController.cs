using GerenciadorFinanca.Data;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorFinanca.Controllers
{
    public class HController : ControllerBase
    {
        private readonly ApiContext _contexto;

        public HController(ApiContext contexto){
            _contexto = contexto;
        }

    }
}