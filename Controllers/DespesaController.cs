using GerenciadorFinanca.Repositorio.IContratos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GerenciadorFinanca.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;


namespace GerenciadorFinanca.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DespesaController : ControllerBase
    {

        private readonly IDespesaRepositorio _despesaRepositorio;
        public DespesaController (IDespesaRepositorio despesaRepositorio){

            _despesaRepositorio = despesaRepositorio;
        }


    [HttpGet]
    public async Task <IEnumerable<Despesa>> ListaTudo(){

        var item = await _despesaRepositorio.ListarGastos();
        return item;
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> Buscar(int id){

        var desp = await _despesaRepositorio.BuscarPorId(id);


        if(desp == null){
            return NotFound();
        }


        return Ok(desp);
    }

 //   [ClaimsAuthorize("Incluir Despesa")]
    [HttpPost]
    public async Task<IActionResult> CriaDespesa (Despesa desp){

        if(desp == null){
            return BadRequest("Despesa não adicionada");
        }

        await _despesaRepositorio.AdicionarDespesa(desp);
        return CreatedAtAction("Buscar", new { id = desp.IdDespesa}, desp);
    }


 //   [ClaimsAuthorize("Atualizar Despesa")]
    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizandoDesp(int id, Despesa desp){

        if(id != desp.IdDespesa){
            
            return BadRequest($"Não foi possível atualizar {id}");
        }

        await _despesaRepositorio.EditarDespesa(desp); 
        return NoContent();
    }

 //   [ClaimsAuthorize("Deletar Despesa")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarDesp (int id){

        var despDeletada = await _despesaRepositorio.BuscarPorId(id);

          if (despDeletada == null){
            return NotFound();
        }
        await _despesaRepositorio.Deletar(id);
        return Ok(despDeletada);
    }
  
}
}