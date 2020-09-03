using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIBoletim.Context
{
    public class BoletimContext
    {
        SqlConnection con = new SqlConnection();
        public BoletimContext()
        {
            //String de conexão com o banco (sempre utilizado)
            con.ConnectionString = @"Data Source=TeJotaPC\SQLEXPRESS;Initial Catalog=boletim;User ID=sa;Password=sa132";
        }
        /// <summary>
        /// Abre a conexão com o banco
        /// </summary>
        /// <returns>retorna a conexão aberta</returns>
        public SqlConnection Conectar()
        {
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
        /// <summary>
        /// Fecha a conexão com o banco
        /// </summary>
        public void Desconectar()
        {
            if(con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
