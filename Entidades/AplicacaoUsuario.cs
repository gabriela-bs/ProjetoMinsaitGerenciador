using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace GerenciadorFinanca.Entidades
{
    public class AplicacaoUsuario : IdentityUser
    {

        [StringLength(15)]
        public string Cpf { get; set; }

    }
}