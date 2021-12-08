using GestaoDeAcesso.controller;
using GestaoDeAcesso.dao;
using GestaoDeAcesso.model;
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
    public partial class EditarVisitante : Form
    {

        public bool cepConfirmado = false;
        public int idUsuario;
        public int idVisitante;

        public EditarVisitante()
        {
            InitializeComponent();
        }

        public EditarVisitante(int idUsuario, int idVisitante)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.idVisitante = idVisitante;
            dtpDataNasc.Format = DateTimePickerFormat.Custom;
            Visitante visitante = carregarDadosVisitante();
            tbNome.Text = visitante.nome;
            if (visitante.sexo.Equals("M"))
            {
                rbMasculino.Checked = true;
            }
            else
            {
                rbFeminino.Checked = true;
            }
            dtpDataNasc.Text = visitante.dataNascimento.ToString().Replace("/", "-");
            if (visitante.documentoIdentificacao.Length.Equals(11))
            {
                rbCpf.Checked = true;
                tbDocumento.Text = visitante.documentoIdentificacao;
            } else
            {
                rbRg.Checked = true;
                tbDocumento.Text = visitante.documentoIdentificacao;
            }
            tbCep.Text = visitante.endereco.cep;
            tbCidade.Text= visitante.endereco.cidade;
            tbEstado.Text = visitante.endereco.estado;
            tbEndereco.Text = visitante.endereco.endereco;
            tbNumero.Text = visitante.endereco.numero.ToString();
            tbBairro.Text = visitante.endereco.bairro;
            tbComplemento.Text = visitante.endereco.complemento;
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

        

        private void btAutomoveis_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Automoveis(idUsuario, idVisitante);
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Inicio(idUsuario);
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private Visitante carregarDadosVisitante()
        {
            SelectDAO select = new SelectDAO();
            select.selectDadosVisitanteById(idVisitante);
            return select.visitante1;
        }

        private void btEntradaSaida_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new EntradaSaida(idUsuario, idVisitante);
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            VisitanteDAO visitante = new VisitanteDAO();
            EnderecoDAO endereco = new EnderecoDAO();
            if (validarCamposObrigatorios())
            {

                if (cepConfirmado)
                {
                    Controller controle = new Controller();
                    if (rbCpf.Checked)
                    {
                        if (rbMasculino.Checked)
                        {
                            visitante.updatePessoaVisitante(idVisitante, tbNome.Text, tbDocumento.Text, null, dtpDataNasc.Text, "M");
                        }
                        else
                        {
                            visitante.updatePessoaVisitante(idVisitante, tbNome.Text, tbDocumento.Text, null, dtpDataNasc.Text, "F");
                        }
                        int idEndereco = visitante.SelectIdEnderecoPessoa(idVisitante);
                        endereco.updatePessoaEndereco(idEndereco, tbCep.Text, tbEndereco.Text, tbComplemento.Text, tbNumero.Text, tbCidade.Text, tbBairro.Text, tbEstado.Text);
                    }
                    else
                    {
                        if (rbMasculino.Checked)
                        {
                            visitante.updatePessoaVisitante(idVisitante, tbNome.Text, null, tbDocumento.Text, dtpDataNasc.Text, "M");
                        }
                        else
                        {
                            visitante.updatePessoaVisitante(idVisitante, tbNome.Text, null, tbDocumento.Text, dtpDataNasc.Text, "F");
                        }
                        int idEndereco = visitante.SelectIdEnderecoPessoa(idVisitante);
                        endereco.updatePessoaEndereco(idEndereco, tbCep.Text, tbEndereco.Text, tbComplemento.Text, tbNumero.Text, tbCidade.Text, tbBairro.Text, tbEstado.Text);
                    }

                    MessageBox.Show("Cadastro bem sucedido", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Verifique o cep digitado");
                }
            }
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

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new CadastroCondomino(idUsuario);
            f.Closed += (s, args) => this.Close();
            f.Show();
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
    }
}
