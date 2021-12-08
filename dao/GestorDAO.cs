using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoDeAcesso.dao
{
    class GestorDAO
    {
        public bool cadastroInserido = false;
        public String mensagem = "";
        SqlCommand cmd = new SqlCommand();
        ConexaoDAO con = new ConexaoDAO();
        SqlDataReader dr;

        public int cadastrarPessoaGestor(String nome, String cpf, String rg, String dataNascimento, int idEndereco)
        {
            int idPessoa = 0;
            cmd.CommandText = "insert into Pessoa(nome, cpf, rg, dataNascimento, id_endereco) values(@nome, @cpf, @rg, @data,  @end); Select max(id) from Pessoa";
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@cpf", Convert.ToInt64(cpf.ToString()));
            cmd.Parameters.AddWithValue("@rg", rg);
            cmd.Parameters.AddWithValue("@data", dataNascimento);
            cmd.Parameters.Add(new SqlParameter("@sexo", DBNull.Value));
            cmd.Parameters.AddWithValue("@end", idEndereco);
            try
            {
                cmd.Connection = con.conectar();
                idPessoa = Convert.ToInt32(cmd.ExecuteScalar());
                con.desconectar();
            }
            catch (SqlException)
            {
                this.mensagem = "Erro ao Inserir Pessoa";
            }
            return idPessoa;
        }

        public void cadastrarUsuario(String email, String senha, String tipo, int idPessoa)
        {
            cmd.CommandText = "insert into Usuario(email, senha, tipoUsuario, id_pessoa) values(@email, @senha, @tipo, @id_pessoa)";
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@senha", senha);
            cmd.Parameters.AddWithValue("@tipo", tipo);
            cmd.Parameters.AddWithValue("@id_pessoa", idPessoa);
            try
            {
                cmd.Connection = con.conectar();
                cmd.ExecuteNonQuery();
                con.desconectar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao inserir usuario");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
