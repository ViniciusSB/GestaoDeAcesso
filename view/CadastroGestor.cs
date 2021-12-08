using GestaoDeAcesso.controller;
using GestaoDeAcesso.dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoDeAcesso.view
{
    public partial class CadastroGestor : Form
    {

        public bool cepConfirmado = false;

        public CadastroGestor()
        {
            InitializeComponent();
            dtpDataNasc.Format = DateTimePickerFormat.Custom;
        }

        private void btConsultarCep_Click(object sender, EventArgs e)
        {
            using (var ws = new wsCorreios.AtendeClienteClient())
            {
                try
                {
                    var resultado = ws.consultaCEP(tbCep.Text);
                    tbEndereco.Text = resultado.end;
                    tbEndereco.Text = resultado.complemento2;
                    tbCidade.Text = resultado.cidade;
                    tbBairro.Text = resultado.bairro;
                    tbEstado.Text = resultado.uf;
                    cepConfirmado = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cep inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cepConfirmado = false;
                }
            }
        }

        private void btCadastrar_Click(object sender, EventArgs e)
        {
            Controller controller = new Controller();
            String senhaCripto = controller.criptografarSenha(tbSenha.Text);
            if (validarCamposObrigatorios())
            {
                if (cepConfirmado)
                {
                    if (controller.verificarEmail(tbEmail.Text))
                    {
                        InsertDAO insert = new InsertDAO();
                        int idEndereco = insert.cadastrarEndereco(tbCep.Text, tbEndereco.Text, Convert.ToInt32(tbNumero.Text), tbComplemento.Text, tbCidade.Text, tbBairro.Text, tbEstado.Text);
                        GestorDAO gestor = new GestorDAO();
                        int idPessoa = gestor.cadastrarPessoaGestor(tbNome.Text, tbCpf.Text, tbRg.Text, dtpDataNasc.Text, idEndereco);
                        gestor.cadastrarUsuario(tbEmail.Text, senhaCripto, "gestor", idPessoa);
                        MessageBox.Show("Cadastro bem sucedido");
                        limparCampos();
                    }
                    else
                    {
                        MessageBox.Show("Esse e-mail já existe");
                    }
                }
            }
            
        }

        public bool validarCamposObrigatorios()
        {
            if (tbCpf.Text != "")
            {
                try
                {
                    Int64 cpf = Convert.ToInt64(tbCpf.Text);
                    if (tbCpf.Text.ToString().Length != 11)
                    {
                        MessageBox.Show("O campo cpf deve ter obrigatoriamente 11 números");
                        return false;
                    }
                }
                catch
                {
                    MessageBox.Show("Apenas numeros são aceitos no campo cpf");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("O campo cpf é obrigatório");
            }
            if (tbRg.Text != "")
            {
                try
                {
                    int rg = Convert.ToInt32(tbRg.Text);
                    if (tbRg.Text.ToString().Length != 7)
                    {
                        MessageBox.Show("O campo rg deve ter obrigatoriamente 7 números");
                        return false;
                    }
                }
                catch
                {
                    MessageBox.Show("Apenas numeros são aceitos no campo rg");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("O campo rg é obrigatório");
            }

            if (tbEmail.Text == "")
            {
                MessageBox.Show("O Campo E-mail é Obrigatório!");
                return false;
            }
            if (tbSenha.Text == "")
            {
                MessageBox.Show("O Campo Senha é Obrigatório!");
                return false;
            }
            if (tbConfirmarSenha.Text == "")
            {
                MessageBox.Show("O Campo de confirmar senha é obrigatório!");
                return false;
            }
            if (tbConfirmarSenha.Text != tbSenha.Text)
            {
                MessageBox.Show("As senhas não conferem, por favor, tente novamente");
                return false;
            }
            if (tbNome.Text == "")
            {
                MessageBox.Show("O Campo nome é Obrigatório!");
                return false;
            }
            if (tbNumero.Text == "")
            {
                MessageBox.Show("O Campo número é Obrigatório!");
                return false;
            }
            if (tbEndereco.Text == "")
            {
                MessageBox.Show("O Campo endereço é Obrigatório!");
                return false;
            }
            if (tbComplemento.Text == "")
            {
                MessageBox.Show("O Campo complemento é Obrigatório!");
                return false;
            }

            return true;
        }

        private void btVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new login();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        public void limparCampos()
        {
            tbNome.Text = "";
            tbCpf.Text = "";
            tbRg.Text = "";
            tbEmail.Text = "";
            tbSenha.Text = "";
            tbConfirmarSenha.Text = "";
            tbCep.Text = "";
            tbEndereco.Text = "";
            tbNumero.Text = "";
            tbComplemento.Text = "";
            tbCidade.Text = "";
            tbEstado.Text = "";
            tbBairro.Text = "";
            cepConfirmado = false;
        }

    }
}
