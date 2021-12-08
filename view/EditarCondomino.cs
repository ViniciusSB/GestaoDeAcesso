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
    public partial class EditarCondomino : Form
    {

        public bool cepConfirmado = false;
        public int idUsuario;
        public int idCondomino;

        public EditarCondomino()
        {
            InitializeComponent();
        }

        public EditarCondomino(int idUsuario, int idVisitante)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.idCondomino = idVisitante;
            dtpDataNasc.Format = DateTimePickerFormat.Custom;
            Condomino condomino = carregarDadosCondominos();
            tbNome.Text = condomino.nome;
            tbEmail.Text = condomino.email;
            if (condomino.sexo.Equals("M"))
            {
                rbMasculino.Checked = true;
            }
            else
            {
                rbFeminino.Checked = true;
            }
            dtpDataNasc.Text = condomino.dataNascimento.ToString().Replace("/", "-");
            tbCpf.Text = condomino.cpf;
            tbRg.Text = condomino.rg;
            tbCep.Text = condomino.endereco.cep;
            tbCidade.Text = condomino.endereco.cidade;
            tbEstado.Text = condomino.endereco.estado;
            tbEndereco.Text = condomino.endereco.endereco;
            tbNumero.Text = condomino.endereco.numero.ToString();
            tbBairro.Text = condomino.endereco.bairro;
            tbComplemento.Text = condomino.endereco.complemento;
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            CondominoDAO condomino = new CondominoDAO();
            EnderecoDAO endereco = new EnderecoDAO();
            if (validarCamposObrigatorios())
            {

                if (cepConfirmado)
                {
                    condomino.updatePessoaUsuario(idCondomino, tbEmail.Text);
                    int idPessoa = condomino.SelectIdPessoaByUsuario(idCondomino);
                    if (rbFeminino.Checked)
                    {
                        condomino.updatePessoaCondomino(idPessoa, tbNome.Text, tbCpf.Text, tbRg.Text, dtpDataNasc.Text, "F");
                    }
                    else
                    {
                        condomino.updatePessoaCondomino(idPessoa, tbNome.Text, tbCpf.Text, tbRg.Text, dtpDataNasc.Text, "M");
                    }
                    
                    int idEndereco = condomino.SelectIdEnderecoPessoa(idPessoa);
                    endereco.updatePessoaEndereco(idEndereco, tbCep.Text, tbEndereco.Text, tbComplemento.Text, tbNumero.Text, tbCidade.Text, tbBairro.Text, tbEstado.Text);
                    MessageBox.Show("Cadastro bem sucedido", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private Condomino carregarDadosCondominos()
        {
            SelectDAO select = new SelectDAO();
            select.selectDadosCondominosById(idCondomino);
            return select.condomino;
        }

        private void btEntradaSaida_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new EntradaSaida(idUsuario, idCondomino);
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void btAutomoveis_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Automoveis(idUsuario, idCondomino);
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

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Inicio(idUsuario);
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new CadastroCondomino(idUsuario);
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

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Condominos(idUsuario);
            f.Closed += (s, args) => this.Close();
            f.Show();
        }
    }
}
