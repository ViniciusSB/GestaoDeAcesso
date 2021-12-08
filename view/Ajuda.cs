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
    public partial class Ajuda : Form
    {

        public int idUsuario;

        public Ajuda()
        {
            InitializeComponent();
        }

        public Ajuda(int idUser)
        {
            InitializeComponent();
            this.idUsuario = idUser;
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
