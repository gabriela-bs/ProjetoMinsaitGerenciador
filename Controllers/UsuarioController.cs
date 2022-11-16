using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using GerenciadorFinanca.Data;
using Microsoft.AspNetCore.Identity;
using GerenciadorFinanca.Serviços;
using Microsoft.Extensions.Options;
using GerenciadorFinanca.Models;
using System.IdentityModel.Tokens.Jwt;

namespace GerenciadorFinanca.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
         private readonly SignInManager<IdentityUser> _signInManager;
         private readonly UserManager<IdentityUser> _userManager;
//         private readonly JwtOp _jwtOp;


    public UsuarioController (SignInManager<IdentityUser> signInManager,
    UserManager<IdentityUser> userManager){

        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpPost("novo-cadastro")]
    public async Task<ActionResult> Cadastro(UsuarioCadastro usuarioCadastro){

        if(!ModelState.IsValid){
             return BadRequest("Ocorreu um erro");
        }

        var usuario = new IdentityUser{
            UserName = usuarioCadastro.EmailUsuario,
            Email = usuarioCadastro.EmailUsuario,
            EmailConfirmed = true
        };

        var resultado = await _userManager.CreateAsync(usuario, usuarioCadastro.Senha);

        if(!resultado.Succeeded){
            return BadRequest(resultado.Errors);
        }

            await _signInManager.SignInAsync(usuario, false);

            return Ok();
        


    }
 
        
    }
 
}