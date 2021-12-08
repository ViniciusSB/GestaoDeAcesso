using GestaoDeAcesso.controller;
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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void btEntrar_Click(object sender, EventArgs e)
        {
            Controller controle = new Controller();
            String senhaCripto = controle.criptografarSenha(tbSenha.Text);
            controle.acessar(tbEmail.Text, senhaCripto);
            if (controle.mensagem.Equals(""))
            {
                if (controle.encontrado)
                {
                    MessageBox.Show("Logado com sucesso", "Autenticado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Form f = new Inicio(controle.idUsuario);
                    f.Closed += (s, args) => this.Close();
                    f.Show();
                }
                else
                {
                    MessageBox.Show("Verifique o login e senha", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show(controle.mensagem);
            }
        }

        private void btCadastrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new CadastroGestor();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
