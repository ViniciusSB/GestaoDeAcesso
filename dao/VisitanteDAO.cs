using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoDeAcesso.dao
{
    class VisitanteDAO
    {
        public bool tem = false;
        public String mensagem = "";
        SqlCommand cmd = new SqlCommand();
        ConexaoDAO con = new ConexaoDAO();
        SqlDataReader dr;
        public int idUsuario;

        

        public void updatePessoaVisitante(int idUsuario, String nome, string cpf, string rg, String data, String sexo)
        {
            cmd.CommandText = "update Pessoa set nome = @nome, cpf = @cpf, rg = @rg, dataNascimento = @data, sexo = @sexo where id = @idUsuario";
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.Add(new SqlParameter("@cpf", string.IsNullOrEmpty(cpf) ? (object)DBNull.Value : cpf));
            cmd.Parameters.Add(new SqlParameter("@rg", string.IsNullOrEmpty(rg) ? (object)DBNull.Value : rg));
            cmd.Parameters.AddWithValue("@data", data);
            cmd.Parameters.AddWithValue("@sexo", sexo);
            try
            {
                cmd.Connection = con.conectar();
                cmd.ExecuteScalar();
                con.desconectar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao fazer o update nos dados do visitante");
            }
        }

        public int SelectIdPessoaByUsuario(int idUsuario)
        {
            cmd.CommandText = "select p.id from Usuario u Inner Join Pessoa p on p.id = u.id_pessoa where u.id = @id";
            cmd.Parameters.AddWithValue("@id", idUsuario);
            try
            {
                cmd.Connection = con.conectar();
                return Convert.ToInt32(cmd.ExecuteScalar());
                con.desconectar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no select do endereço");
                return 0;
            }
        }

        public int SelectIdEnderecoPessoa(int idPessoa)
        {
            cmd.CommandText = "select e.id from Pessoa p Inner Join Endereco e on e.id = p.id_endereco where p.id = @idPessoa";
            cmd.Parameters.AddWithValue("@idPessoa", idPessoa);
            try
            {
                cmd.Connection = con.conectar();
                return Convert.ToInt32(cmd.ExecuteScalar());
                con.desconectar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no select do endereço");
                return 0;
            }
        }
    }
}
