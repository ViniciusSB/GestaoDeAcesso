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
    public partial class CadastroCondomino : Form
    {

        public int idUsuario;
        public bool cepConfirmado = false;

        public CadastroCondomino()
        {
            InitializeComponent();
        }

        public CadastroCondomino(int idUsuario)
        {
            InitializeComponent();
            dtpDataNasc.Format = DateTimePickerFormat.Custom;
            this.idUsuario = idUsuario;
        }

        

        private void btCadastrar_Click(object sender, EventArgs e)
        {
            InsertDAO insert = new InsertDAO();
            if (validarCamposObrigatorios())
            {
                
                if (cepConfirmado)
                {
                    Controller controle = new Controller();
                    if (rbMasculino.Checked == true)
                    {
                        controle.cadastrarCondomino(tbNome.Text, tbEmail.Text, "", "condomino", tbCpf.Text, tbRg.Text, dtpDataNasc.Text.ToString(), "M", tbCep.Text, tbEndereco.Text, tbComplemento.Text, Convert.ToInt32(tbNumero.Text), tbCidade.Text, tbBairro.Text, tbEstado.Text);
                    }
                    else
                    {
                        controle.cadastrarCondomino(tbNome.Text, tbEmail.Text, "", "condomino", tbCpf.Text, tbRg.Text, dtpDataNasc.Text.ToString(), "F", tbCep.Text, tbEndereco.Text, tbComplemento.Text, Convert.ToInt32(tbNumero.Text), tbCidade.Text, tbBairro.Text, tbEstado.Text);
                    }
                    MessageBox.Show("Cadastro bem sucedido", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limparCampos();
                }
                else
                {
                    MessageBox.Show("Verifique o cep digitado");
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
            if (tbNome.Text == "")
            {
                MessageBox.Show("O Campo nome é Obrigatório!");
                return false;
            }
            if (!rbFeminino.Checked && !rbMasculino.Checked)
            {
                MessageBox.Show("O Campo sexo é Obrigatório!");
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

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Inicio(idUsuario);
            f.Closed += (s, args) => this.Close();
            f.Show();
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

        public void limparCampos()
        {
            tbNome.Text = "";
            tbCpf.Text = "";
            tbRg.Text = "";
            tbEmail.Text = "";
            rbFeminino.Checked = false;
            rbMasculino.Checked = false;
            tbCep.Text = "";
            tbEndereco.Text = "";
            tbNumero.Text = "";
            tbComplemento.Text = "";
            tbCidade.Text = "";
            tbEstado.Text = "";
            tbBairro.Text = "";
            cepConfirmado = false;
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Condominos(idUsuario);
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void cadastrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new CadastroVisitante(idUsuario);
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void listarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Visitantes(idUsuario);
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void ajudarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Ajuda(idUsuario);
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Deslogado");
            this.Hide();
            Form f = new login();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }
    }
}
