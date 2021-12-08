using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeAcesso.dao
{
    class LoginDAO
    {
        public bool tem = false;
        public String mensagem = "";
        SqlCommand cmd = new SqlCommand();
        ConexaoDAO con = new ConexaoDAO();
        SqlDataReader dr;
        public int idUsuario;

        public bool verificarLogin(String login, String senha)
        {
            cmd.CommandText = "select * from usuario where email = @login and senha = @senha";
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@senha", senha);

            try
            {
                cmd.Connection = con.conectar();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    tem = true;
                    while (dr.Read())
                    {
                        idUsuario = Convert.ToInt32(dr["id"]);
                    }
                }
            }
            catch (SqlException)
            {
                this.mensagem = "Erro com BD";
            }

            return tem;
        }
        
    }
}
