using GerenciadorFinanca.Repositorio.IContratos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GerenciadorFinanca.Models;



namespace GerenciadorFinanca.Controllers
{
    public class DespesaController : Controller
    {

        private readonly IDespesaRepositorio _despesaRepositorio;
        public DespesaController (IDespesaRepositorio despesaRepositorio){

            _despesaRepositorio = despesaRepositorio;
        }

  
}
}