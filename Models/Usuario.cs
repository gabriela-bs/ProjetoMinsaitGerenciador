using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GerenciadorFinanca.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Digite o email", AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage = "O email informado está incorreto")]
        private string EmailUsuario { get; set; }

        [Required(ErrorMessage = "Digite a senha", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)] //mostra a senha no formato *
        private string Senha { get; set; }

        public List<Despesa> Despesa { get; set;} //cria a lista de despesas de 1 usuario no relacionamento 1 para muitos

    }
}