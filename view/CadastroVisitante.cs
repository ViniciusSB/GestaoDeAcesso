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
    public partial class CadastroVisitante : Form
    {

        public int idUsuario;
        public bool cepConfirmado;

        public CadastroVisitante()
        {
            InitializeComponent();
        }

        public CadastroVisitante(int idUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            dtpDataNasc.Format = DateTimePickerFormat.Custom;
        }

        private void btCadastrar_Click(object sender, EventArgs e)
        {
            InsertDAO insert = new InsertDAO();
            if (validarCamposObrigatorios())
            {

                if (cepConfirmado)
                {
                    Controller controle = new Controller();
                    if (rbCpf.Checked)
                    {
                        if (rbMasculino.Checked)
                        {
                            controle.cadastrarVisitante(tbNome.Text, "", "", "visitante", tbDocumento.Text, null, dtpDataNasc.Text.ToString(), "M", tbCep.Text, tbEndereco.Text, tbComplemento.Text, Convert.ToInt32(tbNumero.Text), tbCidade.Text, tbBairro.Text, tbEstado.Text);
                        }
                        else
                        {
                            controle.cadastrarVisitante(tbNome.Text, "", "", "visitante", tbDocumento.Text, null, dtpDataNasc.Text.ToString(), "F", tbCep.Text, tbEndereco.Text, tbComplemento.Text, Convert.ToInt32(tbNumero.Text), tbCidade.Text, tbBairro.Text, tbEstado.Text);
                        }
                    }
                    else
                    {
                        if (rbMasculino.Checked)
                        {
                            controle.cadastrarVisitante(tbNome.Text, "", "", "visitante", null, tbDocumento.Text, dtpDataNasc.Text.ToString(), "M", tbCep.Text, tbEndereco.Text, tbComplemento.Text, Convert.ToInt32(tbNumero.Text), tbCidade.Text, tbBairro.Text, tbEstado.Text);
                        }
                        else
                        {
                            controle.cadastrarVisitante(tbNome.Text, "", "", "visitante", null, tbDocumento.Text, dtpDataNasc.Text.ToString(), "F", tbCep.Text, tbEndereco.Text, tbComplemento.Text, Convert.ToInt32(tbNumero.Text), tbCidade.Text, tbBairro.Text, tbEstado.Text);
                        }
                        
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
            if (rbCpf.Checked)
            {
                if (tbDocumento.Text != "")
                {
                    try
                    {
                        Int64 cpf = Convert.ToInt64(tbDocumento.Text);
                        if (tbDocumento.Text.ToString().Length != 11)
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
                    return false;
                }
                
            }
            if (rbRg.Checked)
            {
                if (tbDocumento.Text != "")
                {
                    try
                    {
                        int rg = Convert.ToInt32(tbDocumento.Text);
                        if (tbDocumento.Text.ToString().Length != 7)
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
                    return false;
                }
            }
            if (!rbRg.Checked && !rbCpf.Checked)
            {
                MessageBox.Show("Selecione uma opção de documento de identidade");
                return false;
            }
            if (tbNome.Text == "")
            {
                MessageBox.Show("O Campo Email é Obrigatório!");
                return false;
            }
            if (tbNumero.Text == "")
            {
                MessageBox.Show("O Campo número é Obrigatório!");
                return false;
            }

            return true;
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

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Inicio(idUsuario);
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        public void limparCampos()
        {
            tbNome.Text = "";
            rbMasculino.Checked = false;
            rbFeminino.Checked = false;
            rbRg.Checked = false;
            rbCpf.Checked = false;
            tbDocumento.Text = "";
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
            Form f = new CadastroCondomino(idUsuario);
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void listarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Condominos(idUsuario);
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void listarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Visitantes(idUsuario);
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void ajudaToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
