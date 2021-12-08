using GestaoDeAcesso.dao;
using GestaoDeAcesso.model;
using GestaoDeAcesso.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoDeAcesso
{
    public partial class Condominos : Form
    {

        public int idUsuario;

        public Condominos()
        {
            InitializeComponent();

        }

        public Condominos(int idUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            preecherLvCondominos();
        }

        public void preecherLvCondominos()
        {
            var condominos = obterListaCondominos();
            if (condominos != null)
            {
                lvCondominos.Items.Clear();
                foreach (var co in condominos)
                {
                    var row = new String[] { co.id.ToString(), co.nome, co.email, co.sexo, co.dataNascimento.ToString(), co.rg.ToString(), co.cpf.ToString() };
                    var lvi = new ListViewItem(row);
                    lvi.Tag = co;
                    lvCondominos.Items.Add(lvi);
                }
            }
            
        }

        private List<Condomino> obterListaCondominos()
        {
            SelectDAO selectDAO = new SelectDAO();
            if (selectDAO.selectDadosCondominos() == false)
            {
                MessageBox.Show("Lista de Condominos vazia!");
                return null;
            } else
            {
                return selectDAO.condominos;
            }
            
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Inicio(idUsuario);
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void lvCondominos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCondominos.SelectedItems.Count > 0)
            {
                int id = Convert.ToInt32(lvCondominos.SelectedItems[0].Text);
                Console.WriteLine(id);
                this.Hide();
                Form f = new EditarCondomino(idUsuario, id);
                f.Closed += (s, args) => this.Close();
                f.Show();
            }
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

        private void visitarToolStripMenuItem_Click(object sender, EventArgs e)
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

        }
    }
}
