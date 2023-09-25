using Acme.DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.DAL
{
    public class DepartamentoDAL : Conexao
    {
        public List<DepartamentoDTO> Listar()
        {
            try
            {
                //1º Conectar
                Conectar();
                //2º Comando
                cmd = new SqlCommand("SELECT * FROM Departamento", conn);
                //3º Executar e pegar o resultado
                dr = cmd.ExecuteReader();
                //4º Montar a lista de objeto com o resultado
                List<DepartamentoDTO> departamentos = new List<DepartamentoDTO>();
                //5º Para cada item da lista, vou add na lista de departamentos
                while (dr.Read())
                {
                    DepartamentoDTO Departamento = new DepartamentoDTO()
                    {
                        IdDepartamento = Convert.ToInt32(dr["idDepartamento"]),
                        Nome = Convert.ToString(dr["Nome"])
                    };
                    departamentos.Add(Departamento);
                }
                //6º Retorno a lista de departamentos (resultado)
                return departamentos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao listar Departamentos");
            }
            finally
            {
                Desconectar();
            }
        }
    }
}
