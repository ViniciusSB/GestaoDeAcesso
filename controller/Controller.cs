using GestaoDeAcesso.dao;
using GestaoDeAcesso.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeAcesso.controller
{
    class Controller
    {
        public bool encontrado;
        public String mensagem = "";
        public int idUsuario = 0;
        public Pessoa pessoa;
        public Usuario usuario;
        public Endereco endereco;
        public List<Automovel> automoveis;

        public bool acessar(String login, String senha)
        {
            LoginDAO loginDao = new LoginDAO();
            encontrado = loginDao.verificarLogin(login, senha);
            idUsuario = loginDao.idUsuario;
            if (!loginDao.mensagem.Equals(""))
            {
                this.mensagem = loginDao.mensagem;
            }

            return encontrado;
        }

        public bool verificarEmail(String email)
        {
            InsertDAO cadastrarDao = new InsertDAO();
            int resultado = cadastrarDao.verificarEmailExistente(email);
            if (resultado > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void cadastrarVisitante(String nome, String email, String senha, String tipo, String cpf, String rg, String dataNascimento, String sexo, String cep, String end, String comp, int numero, String cidade, String bairro, String estado)
        {
            InsertDAO cadastrarDao = new InsertDAO();
            int idEndereco = cadastrarDao.cadastrarEndereco(cep, end, numero, comp, cidade, bairro, estado);
            int idPessoa = cadastrarDao.cadastrarPessoaVisitante(nome, cpf, rg, dataNascimento, sexo, idEndereco);
            cadastrarDao.cadastrarUsuario(email, senha, tipo, idPessoa);
        }

        public void cadastrarCondomino(String nome, String email, String senha, String tipo, String cpf, String rg, String dataNascimento, String sexo, String cep, String end, String comp, int numero, String cidade, String bairro, String estado)
        {
            InsertDAO cadastrarDao = new InsertDAO();
            int idEndereco = cadastrarDao.cadastrarEndereco(cep, end, numero, comp, cidade, bairro, estado);
            int idPessoa = cadastrarDao.cadastrarPessoaCondomino(nome, cpf, rg, dataNascimento, sexo, idEndereco);
            cadastrarDao.cadastrarUsuario(email, senha, tipo, idPessoa);
        }

        public bool alterarSenha(int id, String senhaAtual, String senhaAlterada)
        {
            SelectDAO selectDao = new SelectDAO();
            UpdateDAO updateDao = new UpdateDAO();
            if (selectDao.conferirSenhaUsuario(id, senhaAtual) == true)
            {
                updateDao.updateSenha(id, senhaAlterada);
                return true;
            }
            else
            {
                return false;
            }
        }

        public String obterNomeUsuario(int id)
        {
            SelectDAO selectDao = new SelectDAO();
            String nome = selectDao.getNomeUsuario(id);
            return nome;
        }

        public String criptografarSenha(String senha)
        {
            // Instanciando a classe MD5CryptoServiceProvider
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            //Ceonvertendo em um array de bites
            byte[] array = Encoding.UTF8.GetBytes(senha);
            //Gerando o hash do aaray
            array = md5.ComputeHash(array);
            StringBuilder sb = new StringBuilder();

            foreach (byte ba in array)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }

            return sb.ToString();
        }
    }
}
