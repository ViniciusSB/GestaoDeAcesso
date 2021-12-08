using GestaoDeAcesso.dao;
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
    public partial class CadastroEntradaSaida : Form
    {

        public int idUsuario;
        public int idSelecionado;

        public CadastroEntradaSaida()
        {
            InitializeComponent();
        }

        public CadastroEntradaSaida(int idUsuario, int idSelecionado)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.idSelecionado = idSelecionado;
            dtpHoraEntrada.Format = DateTimePickerFormat.Time;
            dtpDataEntrada.Format = DateTimePickerFormat.Custom;
            dtpHoraSaida.Format = DateTimePickerFormat.Time;
            dtpDataSaida.Format = DateTimePickerFormat.Custom;
            dtpHoraEntrada.ShowUpDown = true;
            dtpHoraSaida.ShowUpDown = true;
        }

        private void btCadastrar_Click(object sender, EventArgs e)
        {
            InsertDAO insert = new InsertDAO();
            
            DateTime dtEntrada = dtpHoraEntrada.Value;
            TimeSpan stEntrada = new TimeSpan(dtEntrada.Hour, dtEntrada.Minute, dtEntrada.Second);
            DateTime dtSaida = dtpHoraSaida.Value;
            TimeSpan stSaida = new TimeSpan(dtSaida.Hour, dtSaida.Minute, dtSaida.Second);
            insert.cadastrarEntradaSaida(idSelecionado, dtpDataEntrada.Text, stEntrada.ToString(), dtpDataSaida.Text, stSaida.ToString());
            MessageBox.Show("Registro inserido com sucesso!");
            
            
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
