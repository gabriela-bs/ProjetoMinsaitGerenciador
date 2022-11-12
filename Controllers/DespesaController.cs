using GerenciadorFinanca.Repositorio.IContratos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GerenciadorFinanca.Models;



namespace GerenciadorFinanca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DespesaController : Controller
    {

        private readonly IDespesaRepositorio _despesaRepositorio;
        public DespesaController (IDespesaRepositorio despesaRepositorio){

            _despesaRepositorio = despesaRepositorio;
        }


    [HttpGet]
    public async Task<ActionResult<List<Despesa>>> GetDespesas(){
        var despesas = await _despesaRepositorio.ListarGastos();

        if(despesas == null){
            return BadRequest();
        }
        return Ok(despesas);
    }


    [HttpGet]
    [Route("get-teste")]
    public async Task<IActionResult> Busca(int id){
        var desp = await _despesaRepositorio.BuscarPorId(id);
        return Ok(desp);
    }


    [HttpPost]
    public async Task<IActionResult> CriaDespesa (Despesa desp){

        if(desp == null){
            return BadRequest("Despesa não adicionada");
        }

        await _despesaRepositorio.AdicionarDespesa(desp);
        return CreatedAtAction($"/get-teste?id={desp.Id}", desp);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizandoDesp(int id, Despesa despAtualizada){

        if(id != despAtualizada.Id){
            return BadRequest($"Não foi possível atualizar {id}");
        }

        await _despesaRepositorio.EditarDespesa(id, despAtualizada); 
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletandoDesp (int id){
        var despDeletada = await _despesaRepositorio.BuscarPorId(id);

        if (despDeletada == null){
            return NotFound();
        }

        await _despesaRepositorio.Deletar(id);
        return Ok(despDeletada);
    }








  
}
}