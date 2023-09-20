using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.DAL.DTOs
{
    //DTO = Data Transfer Obbject. Representa uma tabela do banco
    public class FuncionarioDTO
    {
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Sexo { get; set; }
        public DateTime DtNascimento { get; set; }
        public DateTime DtAdmissao { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }
        public decimal SalarioBruto { get; set; }
        public int IdCargo { get; set; }
        public int IdDepartamento { get; set; }
    }
}
