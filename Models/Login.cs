using System.ComponentModel.DataAnnotations;

namespace GerenciadorFinanca.Models
{
    public class Login
    {
        [Required(ErrorMessage = "O campo é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo está em formato inválido")]
        public string EmailUsuario { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [MinLength(8)]
        public string Senha { get; set; }

        [StringLength(15)]
        public string Cpf { get; set; }
    }
}