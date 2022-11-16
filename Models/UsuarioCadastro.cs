
using System.ComponentModel.DataAnnotations;

namespace GerenciadorFinanca.Models
{
    public class UsuarioCadastro 
    {

        [Required(ErrorMessage = "É necessário adicionar o Email")]
        [EmailAddress(ErrorMessage = "O campo está em um formato inválido")]
        public string EmailUsuario { get; set; }

        [Required(ErrorMessage = "É necessário cadastrar uma senha")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Senha { get; set; }

        public List<Despesa> Despesas { get; set; }

    }
}