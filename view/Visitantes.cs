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
    public partial class Visitantes : Form
    {
        public int idUsuario;

        public Visitantes()
        {
            InitializeComponent();
        }

        public Visitantes(int idUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            preecherLvVisitantes();
        }

        public void preecherLvVisitantes()
        {
            var condominos = obterListaCondominos();
            if (condominos != null)
            {
                lvVisitantes.Items.Clear();
                foreach (var vi in condominos)
                {
                    var row = new String[] { vi.id.ToString(), vi.nome, vi.sexo, vi.dataNascimento.ToString(), vi.documentoIdentificacao };
                    var lvi = new ListViewItem(row);
                    lvi.Tag = vi;
                    lvVisitantes.Items.Add(lvi);
                }
            }

        }

        private List<Visitante> obterListaCondominos()
        {
            SelectDAO selectDAO = new SelectDAO();
            if (selectDAO.selectDadosVisitante() == false)
            {
                MessageBox.Show("Lista de Visitantes vazia!");
                return null;
            }
            else
            {
                return selectDAO.visitantes;
            }

        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Inicio(idUsuario);
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void indeceSelecionado(object sender, EventArgs e)
        {
            if (lvVisitantes.SelectedItems.Count > 0)
            {
                int id = Convert.ToInt32(lvVisitantes.SelectedItems[0].Text);
                Console.WriteLine(id);
                this.Hide();
                Form f = new EditarVisitante(idUsuario, id);
                f.Closed += (s, args) => this.Close();
                f.Show();
            }
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

        private void cadastrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new CadastroVisitante(idUsuario);
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
    }
}
