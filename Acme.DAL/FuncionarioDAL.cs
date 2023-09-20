using Acme.DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.DAL
{
    public class FuncionarioDAL : Conexao
    {
        //Método Cadastrar
        public void Cadastrar(FuncionarioDTO funcionario)
        {
            try
            {
                //1º conecto no banco
                Conectar();
                //2º Montar o comando sql
                cmd = new SqlCommand($"INSERT INTO Funcionario(IdDepartamento, IdCargo, Nome, Cpf, Email, Telefone, Sexo, DtNascimento, DtAdmissao, Logradouro, Numero, Complemento, Bairro, Cidade, Uf, Cep, SalarioBruto) VALUES({funcionario.IdDepartamento},{funcionario.IdCargo},'{funcionario.Nome}','{funcionario.Cpf}','{funcionario.Email}','{funcionario.Telefone}','{funcionario.Sexo}','{funcionario.DtNascimento}','{funcionario.DtAdmissao}','{funcionario.Logradouro}','{funcionario.Numero}','{funcionario.Complemento}','{funcionario.Bairro}','{funcionario.Cidade}','{funcionario.Uf}','{funcionario.Cep}','{funcionario.SalarioBruto}')");
                //3º Exeutar o comando
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro no INSERT");
            }
            finally
            {
                //4º Desconectar
                Desconectar();
            }
        }

        //Método Alterar

        //método excluir

        //método listar

        //método selecionar
    }
}
