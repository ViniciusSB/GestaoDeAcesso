using GestaoDeAcesso.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeAcesso.dao
{
    class SelectDAO
    {
        public bool cadastroInserido = false;
        public String mensagem = "";
        SqlCommand cmd = new SqlCommand();
        ConexaoDAO con = new ConexaoDAO();
        SqlDataReader dr;
        public List<Automovel> automoveis;
        public List<Condomino> condominos;
        public List<Visitante> visitantes;
        public List<EntradaSaidaModel> entradaSaidas;
        public EntradaSaidaModel entradaSaida;
        public Visitante visitante1;
        public Automovel automovel1;
        public Condomino condomino;


        public String getNomeUsuario(int idUsuario)
        {
            String nome = "";
            cmd.CommandText = "select nome from Pessoa p Inner Join Usuario u on u.id_pessoa = p.id Where u.id = @id";
            cmd.Parameters.AddWithValue("@id", idUsuario);
            try
            {
                cmd.Connection = con.conectar();
                nome = Convert.ToString(cmd.ExecuteScalar());
                con.desconectar();
                return nome;
            }
            catch (SqlException)
            {
                this.mensagem = "Erro no select de usuario";
                cadastroInserido = false;
                return nome;
            }
        }

        public bool selectDadosVisitante()
        {
            cmd.CommandText = "select p.id, p.nome, p.sexo, coalesce(cpf, rg) as documentoIdentificacao, p.dataNascimento, u.*, e.* from Usuario u Inner Join Pessoa p on u.id_pessoa = p.id Inner Join Endereco e on p.id_endereco = e.id Where u.tipoUsuario = 'visitante'";
            try
            {
                cmd.Connection = con.conectar();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    visitantes = new List<Visitante>();
                    while (dr.Read())
                    {
                        Visitante visitante = new Visitante();
                        visitante.id = Convert.ToInt32(dr["id"]);
                        visitante.nome = dr["nome"].ToString();
                        visitante.sexo = dr["sexo"].ToString();
                        visitante.documentoIdentificacao = dr["documentoIdentificacao"].ToString();
                        visitante.dataNascimento = dr["dataNascimento"].ToString().Substring(0,10);
                        visitante.tipoUsuario = dr["tipoUsuario"].ToString();
                        visitante.endereco = new Endereco();
                        visitante.endereco.cep = dr["cep"].ToString();
                        visitante.endereco.bairro = dr["bairro"].ToString();
                        visitante.endereco.cidade = dr["cidade"].ToString();
                        visitante.endereco.estado = dr["estado"].ToString();
                        visitante.endereco.numero = Convert.ToInt32(dr["numero"]);
                        visitante.endereco.complemento = dr["complemento"].ToString();
                        visitante.endereco.endereco = dr["endereco"].ToString();
                        visitantes.Add(visitante);
                    }
                    con.desconectar();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (SqlException)
            {
                this.mensagem = "Erro no select dos Visitantes";
                cadastroInserido = false;
                return false;
            }
        }

        public void selectDadosVisitanteById(int id)
        {
            cmd.CommandText = "select p.id, p.nome, p.sexo, coalesce(cpf, rg) as documentoIdentificacao, p.dataNascimento, u.*, e.* from Usuario u Inner Join Pessoa p on u.id_pessoa = p.id Inner Join Endereco e on p.id_endereco = e.id Where p.id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                cmd.Connection = con.conectar();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    visitante1 = new Visitante();
                    while (dr.Read())
                    {

                        visitante1.id = Convert.ToInt32(dr["id"]);
                        visitante1.nome = dr["nome"].ToString();
                        visitante1.sexo = dr["sexo"].ToString();
                        visitante1.dataNascimento = dr["dataNascimento"].ToString();
                        visitante1.documentoIdentificacao = dr["documentoIdentificacao"].ToString();
                        visitante1.tipoUsuario = dr["tipoUsuario"].ToString();
                        visitante1.endereco = new Endereco();
                        visitante1.endereco.cep = dr["cep"].ToString();
                        visitante1.endereco.bairro = dr["bairro"].ToString();
                        visitante1.endereco.cidade = dr["cidade"].ToString();
                        visitante1.endereco.estado = dr["estado"].ToString();
                        visitante1.endereco.numero = Convert.ToInt32(dr["numero"]);
                        visitante1.endereco.complemento = dr["complemento"].ToString();
                        visitante1.endereco.endereco = dr["endereco"].ToString();
                    }
                    con.desconectar();
                }

            }
            catch (SqlException ex)
            {
                this.mensagem = "Erro no select dos Visitantes";
            }
        }

        public bool selectDadosCondominos()
        {
            cmd.CommandText = "select * from Usuario u Inner Join Pessoa p on u.id_pessoa = p.id Inner Join Endereco e on p.id_endereco = e.id Where u.tipoUsuario = 'condomino'";
            try
            {
                cmd.Connection = con.conectar();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    condominos = new List<Condomino>();
                    while (dr.Read())
                    {
                        Condomino condomino = new Condomino();
                        condomino.id = Convert.ToInt32(dr["id"]);
                        condomino.nome = dr["nome"].ToString();
                        condomino.cpf = dr["cpf"].ToString();
                        condomino.rg = dr["rg"].ToString();
                        condomino.dataNascimento = dr["dataNascimento"].ToString().Substring(0, 10);
                        condomino.sexo = dr["sexo"].ToString();
                        condomino.email = dr["email"].ToString();
                        condomino.tipoUsuario = dr["tipoUsuario"].ToString();
                        condomino.endereco = new Endereco();
                        condomino.endereco.cep = dr["cep"].ToString();
                        condomino.endereco.bairro = dr["bairro"].ToString();
                        condomino.endereco.cidade = dr["cidade"].ToString();
                        condomino.endereco.estado = dr["estado"].ToString();
                        condomino.endereco.numero = Convert.ToInt32(dr["numero"]);
                        condomino.endereco.complemento = dr["complemento"].ToString();
                        condomino.endereco.endereco = dr["endereco"].ToString();
                        condominos.Add(condomino);
                    }
                    con.desconectar();
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (SqlException ex)
            {
                this.mensagem = "Erro no select dos Condominos";
                cadastroInserido = false;
                return false;
            }
        }

        public bool selectDadosCondominosById(int idUsuario)
        {
            cmd.CommandText = "select * from Usuario u Inner Join Pessoa p on u.id_pessoa = p.id Inner Join Endereco e on p.id_endereco = e.id Where u.id = @id";
            cmd.Parameters.AddWithValue("@id", idUsuario);
            try
            {
                cmd.Connection = con.conectar();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    condomino = new Condomino();
                    while (dr.Read())
                    {
                        condomino.id = Convert.ToInt32(dr["id"]);
                        condomino.nome = dr["nome"].ToString();
                        condomino.cpf = dr["cpf"].ToString();
                        condomino.rg = dr["rg"].ToString();
                        condomino.dataNascimento = dr["dataNascimento"].ToString().Substring(0, 10);
                        condomino.sexo = dr["sexo"].ToString();
                        condomino.email = dr["email"].ToString();
                        condomino.tipoUsuario = dr["tipoUsuario"].ToString();
                        condomino.endereco = new Endereco();
                        condomino.endereco.cep = dr["cep"].ToString();
                        condomino.endereco.bairro = dr["bairro"].ToString();
                        condomino.endereco.cidade = dr["cidade"].ToString();
                        condomino.endereco.estado = dr["estado"].ToString();
                        condomino.endereco.numero = Convert.ToInt32(dr["numero"]);
                        condomino.endereco.complemento = dr["complemento"].ToString();
                        condomino.endereco.endereco = dr["endereco"].ToString();
                    }
                    con.desconectar();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (SqlException ex)
            {
                this.mensagem = "Erro no select dos Condominos";
                cadastroInserido = false;
                return false;
            }
        }

        public bool selectAutomoveisPessoa(int id)
        {
            cmd.CommandText = "select a.id, tipo, modelo, marca, ano, placa from Pessoa p Inner Join PessoaxAutomovel pa on p.id = pa.id_pessoa Inner Join Automovel a on a.id = pa.id_automovel where p.id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                cmd.Connection = con.conectar();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    automoveis = new List<Automovel>();
                    while (dr.Read())
                    {
                        Automovel automovel = new Automovel();
                        automovel.id = Convert.ToInt32(dr["id"]);
                        automovel.tipo = dr["tipo"].ToString();
                        automovel.modelo = dr["modelo"].ToString();
                        automovel.marca = dr["marca"].ToString();
                        automovel.ano = Convert.ToInt32(dr["ano"]);
                        automovel.placa = dr["placa"].ToString();
                        automoveis.Add(automovel);
                    }
                    con.desconectar();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (SqlException)
            {
                this.mensagem = "Erro no select dos Automóveis";
                return false;
            }
        }

        public bool conferirSenhaUsuario(int idUsuario, string senha)
        {
            cmd.CommandText = "select * from Usuario Where id = @id";
            cmd.Parameters.AddWithValue("@id", idUsuario);

            try
            {
                cmd.Connection = con.conectar();
                dr = cmd.ExecuteReader();
                String senhaCaptuada = "";
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        senhaCaptuada = dr["senha"].ToString();
                    }
                }
                con.desconectar();
                if (senhaCaptuada.Equals(senha))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException)
            {
                this.mensagem = "Erro no select de usuario";
                return false;
            }
        }

        public int countVisitantes()
        {
            cmd.CommandText = "select count(1) from Usuario u Where u.tipoUsuario = 'visitante'";

            int qtd;
            try
            {
                cmd.Connection = con.conectar();
                qtd = Convert.ToInt32(cmd.ExecuteScalar());
                con.desconectar();
                return qtd;
            }
            catch (SqlException)
            {
                this.mensagem = "Erro no select de visitante";
                return 0;
            }
        }

        public int countCondominos()
        {
            cmd.CommandText = "select count(1) from Usuario u Where u.tipoUsuario = 'condomino'";
            int qtd;
            try
            {
                cmd.Connection = con.conectar();
                qtd = Convert.ToInt32(cmd.ExecuteScalar());
                con.desconectar();
                return qtd;
            }
            catch (SqlException)
            {
                this.mensagem = "Erro no select de visitante";
                return 0;
            }
        }

        public Automovel selectAutomovelById(int idAutomovel)
        {
            cmd.CommandText = "select * from Automovel a Where a.id = @id";
            cmd.Parameters.AddWithValue("@id", idAutomovel);
            try
            {
                cmd.Connection = con.conectar();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    automovel1 = new Automovel();
                    while (dr.Read())
                    {
                        automovel1.id = Convert.ToInt32(dr["id"]);
                        automovel1.tipo = dr["tipo"].ToString();
                        automovel1.modelo = dr["modelo"].ToString();
                        automovel1.marca = dr["marca"].ToString();
                        automovel1.ano = Convert.ToInt32(dr["ano"]);
                        automovel1.placa = dr["placa"].ToString();
                    }
                    con.desconectar();
                }
                return automovel1;
            }
            catch (SqlException)
            {
                this.mensagem = "Erro no select de visitante";
                return automovel1;
            }
        }

        public bool selectEntradaSaida(int idPessoa)
        {
            cmd.CommandText = "select * from PessoaxEntradaSaida pes Inner Join Pessoa p on p.id = pes.id_pessoa Where p.id = @id";
            cmd.Parameters.AddWithValue("@id", idPessoa);
            entradaSaidas = new List<EntradaSaidaModel>();
            try
            {
                cmd.Connection = con.conectar();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    
                    while (dr.Read())
                    {
                        entradaSaida = new EntradaSaidaModel();
                        entradaSaida.idPessoa = Convert.ToInt32(dr["id"]);
                        entradaSaida.dataEntrada = dr["dataEntrada"].ToString().Substring(0, 10);
                        entradaSaida.horaEntrada = dr["horaEntrada"].ToString();
                        entradaSaida.dataSaida = dr["dataSaida"].ToString().Substring(0, 10);
                        entradaSaida.horaSaida = dr["horaSaida"].ToString();
                        entradaSaidas.Add(entradaSaida);
                    }
                    con.desconectar();
                }
                return true;
            }
            catch (SqlException)
            {
                this.mensagem = "Erro no select de Entrada/Saída";
                return false;
            }
        }

        public EntradaSaidaModel selecEntradaSaidaById(int idEntradaSaida)
        {
            cmd.CommandText = "select * from PessoaxEntradaSaida pas Where pas.id = @id";
            cmd.Parameters.AddWithValue("@id", idEntradaSaida);
            try
            {
                cmd.Connection = con.conectar();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    entradaSaida = new EntradaSaidaModel();
                    while (dr.Read())
                    {
                        entradaSaida.id = Convert.ToInt32(dr["id"]);
                        entradaSaida.dataEntrada = dr["dataEntrada"].ToString().Substring(0, 10);
                        entradaSaida.horaEntrada = dr["horaEntrada"].ToString();
                        entradaSaida.dataSaida = dr["dataSaida"].ToString().Substring(0,10);
                        entradaSaida.horaSaida = dr["horaSaida"].ToString();
                    }
                    con.desconectar();
                }
                return entradaSaida;
            }
            catch (SqlException)
            {
                this.mensagem = "Erro no select de Entrada/Saída";
                return entradaSaida;
            }
        }
    }
}
