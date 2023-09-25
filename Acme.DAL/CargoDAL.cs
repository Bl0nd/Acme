using Acme.DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.DAL
{
    public class CargoDAL : Conexao
    {
        public List<CargoDTO> Listar()
        {
            try
            {
                //1º Conectar
                Conectar();
                //2º Comando
                cmd = new SqlCommand("SELECT * FROM CARGO", conn);
                //3º Executar e pegar o resultado
                dr = cmd.ExecuteReader();
                //4º Montar a lista de objeto com o resultado
                List<CargoDTO> cargos = new List<CargoDTO>();
                //5º Para cada item da lista, vou add na lista de cargos
                while (dr.Read())
                {
                    CargoDTO cargo = new CargoDTO()
                    {
                        IdCargo = Convert.ToInt32(dr["idCargo"]),
                        Nome = Convert.ToString(dr["Nome"])
                    };
                    cargos.Add(cargo);
                }
                //6º Retorno a lista de cargos (resultdo)
                return cargos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao listar cargos");
            }
            finally
            {
                Desconectar();
            }
        }
    }
}
