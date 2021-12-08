using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeAcesso.dao
{
    class ConexaoDAO
    {
        SqlConnection con = new SqlConnection();

        public ConexaoDAO()
        {
            con.ConnectionString = @"Data Source=DESKTOP-U52QN0O;Initial Catalog=GestaoDeAcesso;Integrated Security=True";
        }

        public SqlConnection conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public void desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
