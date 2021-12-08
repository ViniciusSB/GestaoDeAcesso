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
    public partial class Automoveis : Form
    {

        public int idUsuario;
        public int idSelecionado;

        public Automoveis()
        {
            InitializeComponent();
        }

        public Automoveis(int idUsuario, int idSelecionado)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.idSelecionado = idSelecionado;
            preecherLvAutomoveis();
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Inicio(idUsuario);
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        public void preecherLvAutomoveis()
        {
            var condominos = obterListaAutomoveis();
            if (condominos != null)
            {
                lvAutomoveis.Items.Clear();
                foreach (var au in condominos)
                {
                    var row = new String[] { au.id.ToString(), au.tipo, au.modelo, au.marca, au.ano.ToString(), au.placa };
                    var lvi = new ListViewItem(row);
                    lvi.Tag = au;
                    lvAutomoveis.Items.Add(lvi);
                }
            }

        }

        private List<Automovel> obterListaAutomoveis()
        {
            SelectDAO selectDAO = new SelectDAO();
            if (selectDAO.selectAutomoveisPessoa(idSelecionado) == false)
            {
                MessageBox.Show("Lista de Autmóveis vazia!");
                return null;
            }
            else
            {
                return selectDAO.automoveis;
            }

        }

        private void indeceSelecionado(object sender, EventArgs e)
        {
            if (lvAutomoveis.SelectedItems.Count > 0)
            {
                int id = Convert.ToInt32(lvAutomoveis.SelectedItems[0].Text);
                this.Hide();
                Form f = new EditarAutomovel(idUsuario, idSelecionado, id);
                f.Closed += (s, args) => this.Close();
                f.Show();
            }
        }

        private void lbCadastrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new CadastroAutomovel(idUsuario, idSelecionado);
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

        private void ajudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Ajuda(idUsuario);
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
    }
}
