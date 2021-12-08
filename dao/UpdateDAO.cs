using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoDeAcesso.dao
{
    class UpdateDAO
    {
        public bool tem = false;
        public String mensagem = "";
        SqlCommand cmd = new SqlCommand();
        ConexaoDAO con = new ConexaoDAO();
        SqlDataReader dr;
        public int idUsuario;

        public void updateSenha(int idUsuario, String senha)
        {
            cmd.CommandText = "update Usuario set senha = @senha where id = @id";
            cmd.Parameters.AddWithValue("@id", idUsuario);
            cmd.Parameters.AddWithValue("@senha", senha);
            try
            {
                cmd.Connection = con.conectar();
                cmd.ExecuteNonQuery();

            }
            catch (SqlException)
            {

            }
        }

        public void updateAutomovel(int idAutomovel, String tipo, String modelo, String marca, int ano, String placa)
        {
            cmd.CommandText = "update Automovel set tipo = @tipo, modelo = @modelo, marca = @marca, ano = @ano, placa = @placa where id = @id";
            cmd.Parameters.AddWithValue("@tipo", tipo);
            cmd.Parameters.AddWithValue("@modelo", modelo);
            cmd.Parameters.AddWithValue("@marca", marca);
            cmd.Parameters.AddWithValue("@ano", Convert.ToInt32(ano));
            cmd.Parameters.AddWithValue("@placa", placa);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(idAutomovel));
            try
            {
                cmd.Connection = con.conectar();
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao atualizar o automovel");
                Console.WriteLine(ex);
            }
        }

        public void updateRegistroDataHora(int idEntradaSaida, int idPessoa, String dataEntrada, String horaEntrada, String dataSaida, String horaSaida)
        {
            cmd.CommandText = "update PessoaxEntradaSaida set dataEntrada = @dataEntrada, horaEntrada = @horaEntrada, dataSaida = @dataSaida, horaSaida = @horaSaida, id_pessoa = @id_pessoa where id = @id";
            cmd.Parameters.AddWithValue("@dataEntrada", dataEntrada);
            cmd.Parameters.AddWithValue("@horaEntrada", horaEntrada);
            cmd.Parameters.AddWithValue("@dataSaida", dataSaida);
            cmd.Parameters.AddWithValue("@horaSaida", horaSaida);
            cmd.Parameters.AddWithValue("@id_pessoa", idPessoa);
            cmd.Parameters.AddWithValue("@id", idEntradaSaida);
            try
            {
                cmd.Connection = con.conectar();
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao atualizar o Registro de Entrada/Saída");
                Console.WriteLine(ex);
            }
        }
    }
}
