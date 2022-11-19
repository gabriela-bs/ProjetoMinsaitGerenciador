using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GerenciadorFinanca.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using GerenciadorFinanca.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using GerenciadorFinanca.Entidades;
using GerenciadorFinanca.Repositorio;


namespace GerenciadorFinanca.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class DespesaController : ControllerBase
    {

    private readonly APIContexto _apiContexto;
    private readonly DespesaRepositorio _despRepositorio;
    private readonly UserManager<AplicacaoUsuario> _userManager;

        public DespesaController (APIContexto apiContexto, UserManager<AplicacaoUsuario> userManager, DespesaRepositorio despRepositorio)
        {
            _despRepositorio = despRepositorio;
            _apiContexto = apiContexto;
            _userManager = userManager;
        }

    [Authorize]
    [HttpGet]
    public async Task <IEnumerable<Despesa>>ListarGastos(){

        return await _despRepositorio.List();
        
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> Buscar(DespesaModel despesa){

        var desp = await _apiContexto.Despesas.FindAsync(despesa.DespId);


        if(desp == null){
            return NotFound();
        }


        return Ok(desp);
    }

    [Authorize]
    [HttpPost("api/inserindo-despesa")]
    public async Task<IActionResult> CriarDespesa (DespesaModel despesa){

        var despesaNova = new Despesa();
        
        despesaNova.NomeDespesa = despesa.NomeDespesa;
        despesaNova.Valor = despesa.Valor;
        despesaNova.DespesaData = despesa.DespesaData;
        despesaNova.Categoria = despesa.Categoria;
        despesaNova.DespId = await RetornarUsuarioLogado();

        await _apiContexto.Set<Despesa>().AddRangeAsync(despesaNova);

        await _apiContexto.SaveChangesAsync();


        return Ok();
    }

    [Authorize]
    [HttpPut("api/atualizando-despesa")]
    public async Task<IActionResult> AtualizarDesp(int id, DespesaModel despesa){


   //     var despesaAtualizada = _apiContexto.Entry(despesa).State = EntityState.Modified;
        var despesaAtualizada = _apiContexto.Entry(despesa).State = EntityState.Modified;


        await _apiContexto.SaveChangesAsync();

        return NoContent();
    }

    [Authorize]
    [HttpDelete("api/deletando-despesa")]
    public async Task<IActionResult> DeletarDesp (int id, DespesaModel despesa){

        var item = await _apiContexto.Despesas.FindAsync(despesa.Id);
        
        if (item == null){

            return NotFound();
        }

        _apiContexto.Despesas.Remove(item);
        await _apiContexto.SaveChangesAsync();
        
        return Ok();
    }


    private async Task<string> RetornarUsuarioLogado()
    {

        if(User != null){

            //retorno do id do usuario logado
            var usuarioId = User.FindFirst("usuarioId");
            return usuarioId.Value;
        }

        return string.Empty;


    }
  
}

}