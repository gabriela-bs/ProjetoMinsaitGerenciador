using System.ComponentModel.DataAnnotations;

namespace GerenciadorFinanca.Models
{
    public class UsuarioLogin
    {
        [Required(ErrorMessage = "O campo é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo está em formato inválido")]
        public string EmailUsuario { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [MinLength(8)]
        public string Senha { get; set; }
    }
}