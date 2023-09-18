using System.Data.SqlClient;

namespace Acme.DAL
{
    public class Conexao
    {
        //variaveis
        protected SqlCommand cmd; // comando sql
        protected SqlDataReader dr; // resultado do comando
        protected SqlConnection conn; //conexao

        //abre conexao com banco de dados
        protected void Conectar()
        {
            try
            {
                conn = new SqlConnection("Data Source=(localdb)\MSSQLLocaldb;Initial Catalog=BD_Acme;Integrated Security=True");
                    conn.Open();
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
    }
}