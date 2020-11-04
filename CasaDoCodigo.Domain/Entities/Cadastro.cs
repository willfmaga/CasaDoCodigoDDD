using System;
using System.ComponentModel.DataAnnotations;

namespace CasaDoCodigo.Domain.Entities
{
    public class Cadastro : BaseModel
    {
        public Cadastro()
        {
        }

        public virtual Pedido Pedido { get; set; }
        [Required]
        public string Nome { get; set; } = "";
        [Required]
        public string Email { get; set; } = "";
        [Required]
        public string Telefone { get; set; } = "";
        [Required]
        public string Endereco { get; set; } = "";
        [Required]
        public string Complemento { get; set; } = "";
        [Required]
        public string Bairro { get; set; } = "";
        [Required]
        public string Municipio { get; set; } = "";
        [Required]
        public string UF { get; set; } = "";

        public void Update(Cadastro cadastro)
        {
            this.Bairro = cadastro.Bairro;
            this.CEP = cadastro.CEP;
            this.Complemento = cadastro.Complemento;
            this.Email = cadastro.Email;
            this.Endereco = cadastro.Endereco;
            this.Municipio = cadastro.Municipio;
            this.Nome = cadastro.Nome;
            this.Telefone = cadastro.Telefone;
            this.UF = cadastro.UF;

        }

        [Required]
        public string CEP { get; set; } = "";
    }
}
