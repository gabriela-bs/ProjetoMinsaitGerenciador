using System.Text;
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
         private readonly JwtConfig _jwtConfig;


    public UsuarioController (SignInManager<IdentityUser> signInManager,
    UserManager<IdentityUser> userManager, IOptions<JwtConfig> jwtConfig)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _jwtConfig = jwtConfig.Value;
    }




    [HttpPost("cadastro")]
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

            return Ok(await GerarJwt(usuarioCadastro.EmailUsuario));


    }

    [HttpPost("login")]
    public async Task<ActionResult> Login (UsuarioCadastro loginUsuario){

        if(!ModelState.IsValid){
            return BadRequest(ModelState.Values.SelectMany(e => e.Errors));
        }

        var resultado = await _signInManager.PasswordSignInAsync(loginUsuario.EmailUsuario, loginUsuario.Senha, false, true);

        if(resultado.Succeeded){
            return Ok(await GerarJwt(loginUsuario.EmailUsuario));
        }

        return BadRequest("Usuário ou senha inválidos");
    
    }

    private async Task<string> GerarJwt(string email) {

        var usuario = await _userManager.FindByEmailAsync(email);
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtConfig.Secreto);


        var tokenDescriptor = new SecurityTokenDescriptor{

            Issuer = _jwtConfig.Emissor,
            Audience = _jwtConfig.ValidoEm,
            Expires = DateTime.UtcNow.AddHours(_jwtConfig.ExpiracaoHoras),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        return  tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

    }
 
        
    }
 
}