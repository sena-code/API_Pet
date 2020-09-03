using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pet.Context
{
    public class TipoPetContext
    {
        SqlConnection con = new SqlConnection();

        public TipoPetContext()
        {
            con.ConnectionString = @"Data Source=VINICIUS\SQLEXPRESS;Initial Catalog=vet;Persist Security Info=True;User ID=sa;Password=sa132;";
        }

        public SqlConnection Conectar()
        {
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            return con;
        }

        public SqlConnection Desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }

            return con;
        }
    }
}
