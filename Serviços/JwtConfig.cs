namespace GerenciadorFinanca.Serviços
{
    public class JwtConfig
    {
        public string Secreto { get; set; }
        public int ExpiracaoHoras { get; set; }
        public string Emissor { get; set; }
        public string ValidoEm { get; set; }
    }
}