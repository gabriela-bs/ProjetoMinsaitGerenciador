using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using GerenciadorFinanca.Models;
using GerenciadorFinanca.Entidades;
using GerenciadorFinanca.Token;

namespace GerenciadorFinanca.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
         private readonly SignInManager<AplicacaoUsuario> _signInManager;
         private readonly UserManager<AplicacaoUsuario> _userManager;


    public UsuarioController (SignInManager<AplicacaoUsuario> signInManager,
    UserManager<AplicacaoUsuario> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }



    [AllowAnonymous]
    [HttpPost("/apifinanceira/cadastro")]
    public async Task<ActionResult> CadastroUsuario ([FromBody] Login login){

        if(string.IsNullOrWhiteSpace(login.EmailUsuario) || string.IsNullOrWhiteSpace(login.Senha))
        {
            return Ok("Falta preencher alguns dados");
        }


        var usuario = new AplicacaoUsuario
        {
            UserName = login.EmailUsuario,
            Email = login.EmailUsuario,
            Cpf = login.Cpf,
            EmailConfirmed = true //autentica o email sem precisar de confirmação
        };

        var resultado = await _userManager.CreateAsync(usuario, login.Senha);

        if(!resultado.Succeeded)
        {
            return BadRequest(resultado.Errors);
        }

            await _signInManager.SignInAsync(usuario, false);

            return Ok("Usuario adicionado com sucesso");

    }


    [AllowAnonymous]
    [HttpPost("login-autorizacao")]
    public async Task<IActionResult> GerarToken ([FromBody] Login login)
    {
        if(string.IsNullOrWhiteSpace(login.EmailUsuario) || string.IsNullOrWhiteSpace(login.Senha)){

            return Unauthorized();
        };


        //verifica se o usuário e senha existem
        var resultado = await _signInManager.PasswordSignInAsync(login.EmailUsuario, login.Senha, false, true);
    

        if(resultado.Succeeded){

            //Responsável por retornar o id logado
            var usuarioCurrent = await _userManager.FindByEmailAsync(login.EmailUsuario);
            var usuarioId = usuarioCurrent.Id;

            var token = new TokenJWTBuilder()
                    .AddSecurityKey(JwtSecurityKey.Create("Secret_Key-87654321"))
                .AddSubject("Empresa - ProjetoAPI")
                .AddIssuer("Teste.Securiry.Bearer")
                .AddAudience("Teste.Securiry.Bearer")
                .AddClaim("usuarioId", usuarioId) //criptografa o usuario
                .AddExpiry(10)
                .Builder();

                return Ok(token.value); //retorna o token para o usuário logado
            }

            else{
                return Unauthorized();
            }
    
    }
}
}
