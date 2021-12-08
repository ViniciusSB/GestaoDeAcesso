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
    public partial class Inicio : Form
    {
        public int idUsuario;

        public Inicio()
        {
            InitializeComponent();
        }

        public Inicio(int id)
        {
            InitializeComponent();
            idUsuario = id;
            lbCondominos.Text = "Total de Condôminos: " + qtdCondominos();
            lbVisitantes.Text = "Visitantes Recebidos: " + qtdVisitantes();
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

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Condominos(idUsuario);
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        public int qtdCondominos()
        {
            SelectDAO select = new SelectDAO();
            return select.countCondominos();
        }

        public int qtdVisitantes()
        {
            SelectDAO select = new SelectDAO();
            return select.countVisitantes();
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
