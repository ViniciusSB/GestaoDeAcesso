using GestaoDeAcesso.dao;
using GestaoDeAcesso.model;
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
    public partial class EditarAutomovel : Form
    {

        public int idUsuario;
        public int idSelecionado;
        public int idAutomovel;

        public EditarAutomovel()
        {
            InitializeComponent();
        }

        public EditarAutomovel(int idUsuario, int idSelecionado, int idAutomovel)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.idSelecionado = idSelecionado;
            this.idAutomovel = idAutomovel;
            Automovel automovel = preecherAutomovel();
            tbTipo.Text = automovel.tipo;
            tbPlaca.Text = automovel.placa;
            tbModelo.Text = automovel.modelo;
            tbMarca.Text = automovel.marca;
            tbAno.Text = automovel.ano.ToString();
        }


        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Inicio(idUsuario);
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            UpdateDAO update = new UpdateDAO();
            update.updateAutomovel(idAutomovel, tbTipo.Text, tbModelo.Text, tbMarca.Text, Convert.ToInt32(tbAno.Text), tbPlaca.Text);
            MessageBox.Show("Automovel editado");
        }

        private Automovel preecherAutomovel()
        {
            SelectDAO selectDAO = new SelectDAO();
            return selectDAO.selectAutomovelById(idAutomovel);
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
