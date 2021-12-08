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
    public partial class EntradaSaida : Form
    {

        public int idUsuario;
        public int idSelecionado;

        public EntradaSaida()
        {
            InitializeComponent();
        }

        public EntradaSaida(int idUsuario, int idSelecionado)
        {
            InitializeComponent();
            this.idSelecionado = idSelecionado;
            this.idUsuario = idUsuario;
            preecherLvVisitantes();
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Inicio(idUsuario);
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        public void preecherLvVisitantes()
        {
            var entradaSaidas = obterListaEntradaSaida();
            if (entradaSaidas != null)
            {
                lvEntradaSaida.Items.Clear();
                foreach (var es in entradaSaidas)
                {
                    var row = new String[] { es.idPessoa.ToString(), es.dataEntrada, es.horaEntrada.ToString(), es.dataSaida.ToString(), es.horaSaida.ToString() };
                    var lvi = new ListViewItem(row);
                    lvi.Tag = es;
                    lvEntradaSaida.Items.Add(lvi);
                }
            }

        }

        private List<EntradaSaidaModel> obterListaEntradaSaida()
        {
            SelectDAO selectDAO = new SelectDAO();
            if (selectDAO.selectEntradaSaida(idSelecionado) == false)
            {
                MessageBox.Show("Lista de Entrada/Saída vazia!");
                return null;
            }
            else
            {
                return selectDAO.entradaSaidas;
            }

        }

        private void btAdicionar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new CadastroEntradaSaida(idUsuario, idSelecionado);
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void eventoSelecionado(object sender, EventArgs e)
        {
            if (lvEntradaSaida.SelectedItems.Count > 0)
            {
                int id = Convert.ToInt32(lvEntradaSaida.SelectedItems[0].Text);
                Console.WriteLine(id);
                this.Hide();
                Form f = new EditarEntradaSaida(idUsuario, idSelecionado, id);
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

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Deslogado");
            this.Hide();
            Form f = new login();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }
    }
}
