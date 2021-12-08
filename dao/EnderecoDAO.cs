using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoDeAcesso.dao
{
    class EnderecoDAO
    {
        public bool tem = false;
        public String mensagem = "";
        SqlCommand cmd = new SqlCommand();
        ConexaoDAO con = new ConexaoDAO();
        SqlDataReader dr;
        public int idUsuario;

        public void updatePessoaEndereco(int idEndereco, String cep, string endereco, string complemento, String numero, String cidade, String bairro, String estado)
        {
            cmd.CommandText = "update Endereco set cep = @cep, endereco = @endereco, complemento = @complemento, numero = @numero, cidade = @cidade, bairro = @bairro, estado = @estado where id = @id";
            cmd.Parameters.AddWithValue("@id", idEndereco);
            cmd.Parameters.AddWithValue("@cep", cep);
            cmd.Parameters.AddWithValue("@endereco", endereco);
            cmd.Parameters.AddWithValue("@complemento", complemento);
            cmd.Parameters.AddWithValue("@numero", numero);
            cmd.Parameters.AddWithValue("@cidade", cidade);
            cmd.Parameters.AddWithValue("@bairro", bairro);
            cmd.Parameters.AddWithValue("@estado", estado);
            try
            {
                cmd.Connection = con.conectar();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                MessageBox.Show("Erro ao fazer o update do endereco do visistante");
            }
        }
    }
}
