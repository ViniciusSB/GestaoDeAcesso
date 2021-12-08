using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoDeAcesso.dao
{
    class InsertDAO
    {
        public bool cadastroInserido = false;
        public String mensagem = "";
        SqlCommand cmd = new SqlCommand();
        ConexaoDAO con = new ConexaoDAO();
        SqlDataReader dr;

        public int verificarEmailExistente(String email)
        {
            int resultado = 0;
            cmd.CommandText = "select count(1) from Usuario where email = @email";
            cmd.Parameters.AddWithValue("@email", email);
            try
            {
                cmd.Connection = con.conectar();
                resultado = Convert.ToInt32(cmd.ExecuteScalar());
                con.desconectar();
                return resultado;
            }
            catch (SqlException)
            {
                this.mensagem = "Erro ao conectar ao banco";
                resultado = 0;
                return resultado;
            }
        }

        public int cadastrarEndereco(String cep, String end, int numero, String comp, String cidade, String bairro, String estado)
        {
            int idEndereco = 0;
            cmd.CommandText = "insert into Endereco(cep, endereco, complemento, numero, cidade, bairro, estado) values(@cep, @endereco, @complemento, @numero, @cidade, @bairro, @estado); Select max(id) from Endereco";
            cmd.Parameters.AddWithValue("@cep", cep);
            cmd.Parameters.AddWithValue("@endereco", end);
            cmd.Parameters.AddWithValue("@complemento", comp);
            cmd.Parameters.AddWithValue("@numero", numero);
            cmd.Parameters.AddWithValue("@cidade", cidade);
            cmd.Parameters.AddWithValue("@bairro", bairro);
            cmd.Parameters.AddWithValue("@estado", estado);
            try
            {
                cmd.Connection = con.conectar();
                idEndereco = Convert.ToInt32(cmd.ExecuteScalar());
                con.desconectar();
            }
            catch (SqlException)
            {
                this.mensagem = "Erro ao Endereco";
                cadastroInserido = false;
            }
            return idEndereco;
        }

        public int cadastrarPessoaVisitante(String nome, String cpf, String rg, String dataNascimento, String sexo, int idEndereco)
        {
            int idPessoa = 0;
            cmd.CommandText = "insert into Pessoa(nome, cpf, rg, dataNascimento, sexo, id_endereco) values(@nome, @cpf, @rg, @data, @sexo,  @end); Select max(id) from Pessoa";
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.Add(new SqlParameter("@cpf", string.IsNullOrEmpty(cpf) ? (object)DBNull.Value : cpf));
            cmd.Parameters.Add(new SqlParameter("@rg", string.IsNullOrEmpty(rg) ? (object)DBNull.Value : rg));
            cmd.Parameters.AddWithValue("@data", dataNascimento);
            cmd.Parameters.AddWithValue("@sexo", sexo);
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

        public int cadastrarPessoaCondomino(String nome, String cpf, String rg, String dataNascimento, String sexo, int idEndereco)
        {
            int idPessoa = 0;
            cmd.CommandText = "insert into Pessoa(nome, cpf, rg, dataNascimento, sexo, id_endereco) values(@nome, @cpf, @rg, @data, @sexo,  @end); Select max(id) from Pessoa";
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@cpf", cpf);
            cmd.Parameters.AddWithValue("@rg", rg);
            cmd.Parameters.AddWithValue("@data", dataNascimento);
            cmd.Parameters.AddWithValue("@sexo", sexo);
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

        public int cadastrarAutomovel(String tipo, String modelo, String marca, int ano, String placa)
        {
            int idAutomovel = 0;
            cmd.CommandText = "insert into Automovel(tipo, modelo, marca, ano, placa) values(@tipo, @modelo, @marca, @ano, @placa); Select max(id) from Automovel";
            cmd.Parameters.AddWithValue("@tipo", tipo);
            cmd.Parameters.AddWithValue("@modelo", modelo);
            cmd.Parameters.AddWithValue("@marca", marca);
            cmd.Parameters.AddWithValue("@ano", ano);
            cmd.Parameters.AddWithValue("@placa", placa);
            try
            {
                cmd.Connection = con.conectar();
                idAutomovel = Convert.ToInt32(cmd.ExecuteScalar());
                con.desconectar();
            }
            catch (SqlException)
            {
                this.mensagem = "Erro ao Inserir Automóvel";
            }
            return idAutomovel;
        }

        public void cadastrarPessoaAutomovel(int idPessoa, int idAutomovel)
        {
            cmd.CommandText = "insert into PessoaxAutomovel(id_pessoa, id_automovel) values(@pessoa, @automovel);";
            cmd.Parameters.AddWithValue("@pessoa", idPessoa);
            cmd.Parameters.AddWithValue("@automovel", idAutomovel);
            try
            {
                cmd.Connection = con.conectar();
                idAutomovel = Convert.ToInt32(cmd.ExecuteScalar());
                con.desconectar();
            }
            catch (SqlException)
            {
                this.mensagem = "Erro ao Inserir PessoaxAutomovel";
            }
        }



        public void cadastrarUsuario(String email, String senha, String tipo, int idPessoa)
        {
            cmd.CommandText = "insert into Usuario(email, senha, tipoUsuario, id_pessoa) values(@email, @senha, @tipo, @id_pessoa)";
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.Add(new SqlParameter("@senha", DBNull.Value));
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

        public void cadastrarEntradaSaida(int idPessoa, String dataEntrada, String horaEntrada, String dataSaida, String horaSaida)
        {
            cmd.CommandText = "insert into PessoaxEntradaSaida(dataEntrada, horaEntrada, dataSaida, horaSaida, id_pessoa) values(@dataEntrada, @horaEntrada, @dataSaida, @horaSaida, @id_pessoa)";
            cmd.Parameters.AddWithValue("@dataEntrada", dataEntrada);
            cmd.Parameters.AddWithValue("@horaEntrada", horaEntrada);
            cmd.Parameters.AddWithValue("@dataSaida", dataSaida);
            cmd.Parameters.AddWithValue("@horaSaida", horaSaida);
            cmd.Parameters.AddWithValue("@id_pessoa", idPessoa);
            try
            {
                cmd.Connection = con.conectar();
                cmd.ExecuteNonQuery();
                con.desconectar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao inserir a Entrada/Saída");
                Console.WriteLine(ex.Message);
            }
        }

    }
}
