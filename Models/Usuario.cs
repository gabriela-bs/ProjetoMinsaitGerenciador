using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GerenciadorFinanca.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Digite o email", AllowEmptyStrings = false)]
        [StringLength(50)]
        [EmailAddress(ErrorMessage = "O email informado está incorreto")]
        public string EmailUsuario { get; set; }


        [Required(ErrorMessage = "Digite a senha", AllowEmptyStrings = false)]
        [MinLength(6)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)] //mostra a senha no formato *
        public string Senha { get; set; }
        public List<Despesa> Despesas { get; set; }

    }
}