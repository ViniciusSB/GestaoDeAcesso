using GestaoDeAcesso.dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoDeAcesso.view
{
    public partial class CadastroAutomovel : Form
    {

        public int idUsuario;
        public int idSelecionado;

        public CadastroAutomovel()
        {
            InitializeComponent();
        }

        public CadastroAutomovel(int idUsuario, int idSelecionado)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.idSelecionado = idSelecionado;
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Inicio(idUsuario);
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            InsertDAO insert = new InsertDAO();
            int idAutomovel = insert.cadastrarAutomovel(tbTipo.Text, tbModelo.Text, tbMarca.Text, Convert.ToInt32(tbAno.Text), tbPlaca.Text);
            insert.cadastrarPessoaAutomovel(idSelecionado, idAutomovel);
            MessageBox.Show("Automovel inserido com sucesso");
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
