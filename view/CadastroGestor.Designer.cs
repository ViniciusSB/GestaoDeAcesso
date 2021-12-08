
namespace GestaoDeAcesso.view
{
    partial class CadastroGestor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btVoltar = new System.Windows.Forms.Button();
            this.btCadastrar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.tbEndereco = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btConsultarCep = new System.Windows.Forms.Button();
            this.tbCep = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpDataNasc = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.tbRg = new System.Windows.Forms.TextBox();
            this.tbCpf = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNome = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbNumero = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbComplemento = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbEstado = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbBairro = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbCidade = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbConfirmarSenha = new System.Windows.Forms.TextBox();
            this.tbSenha = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btVoltar
            // 
            this.btVoltar.Location = new System.Drawing.Point(375, 481);
            this.btVoltar.Name = "btVoltar";
            this.btVoltar.Size = new System.Drawing.Size(67, 42);
            this.btVoltar.TabIndex = 61;
            this.btVoltar.Text = "Voltar";
            this.btVoltar.UseVisualStyleBackColor = true;
            this.btVoltar.Click += new System.EventHandler(this.btVoltar_Click);
            // 
            // btCadastrar
            // 
            this.btCadastrar.Location = new System.Drawing.Point(464, 481);
            this.btCadastrar.Name = "btCadastrar";
            this.btCadastrar.Size = new System.Drawing.Size(115, 42);
            this.btCadastrar.TabIndex = 60;
            this.btCadastrar.Text = "Cadastrar";
            this.btCadastrar.UseVisualStyleBackColor = true;
            this.btCadastrar.Click += new System.EventHandler(this.btCadastrar_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(73, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 57;
            this.label10.Text = "Nome";
            // 
            // tbEndereco
            // 
            this.tbEndereco.Location = new System.Drawing.Point(623, 132);
            this.tbEndereco.Name = "tbEndereco";
            this.tbEndereco.Size = new System.Drawing.Size(217, 20);
            this.tbEndereco.TabIndex = 56;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(550, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 55;
            this.label5.Text = "Endereço";
            // 
            // btConsultarCep
            // 
            this.btConsultarCep.Location = new System.Drawing.Point(765, 80);
            this.btConsultarCep.Name = "btConsultarCep";
            this.btConsultarCep.Size = new System.Drawing.Size(75, 23);
            this.btConsultarCep.TabIndex = 54;
            this.btConsultarCep.Text = "Consultar";
            this.btConsultarCep.UseVisualStyleBackColor = true;
            this.btConsultarCep.Click += new System.EventHandler(this.btConsultarCep_Click);
            // 
            // tbCep
            // 
            this.tbCep.Location = new System.Drawing.Point(623, 82);
            this.tbCep.Name = "tbCep";
            this.tbCep.Size = new System.Drawing.Size(124, 20);
            this.tbCep.TabIndex = 53;
            this.tbCep.Tag = "<obrigatorio>";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(575, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 52;
            this.label4.Text = "CEP";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpDataNasc);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.tbRg);
            this.groupBox2.Controls.Add(this.tbCpf);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbNome);
            this.groupBox2.Location = new System.Drawing.Point(34, 35);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(407, 216);
            this.groupBox2.TabIndex = 58;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informações Pessoais";
            // 
            // dtpDataNasc
            // 
            this.dtpDataNasc.CustomFormat = "dd-MM-yyyy";
            this.dtpDataNasc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataNasc.Location = new System.Drawing.Point(174, 85);
            this.dtpDataNasc.Name = "dtpDataNasc";
            this.dtpDataNasc.Size = new System.Drawing.Size(217, 20);
            this.dtpDataNasc.TabIndex = 53;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(43, 167);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 13);
            this.label12.TabIndex = 52;
            this.label12.Text = "RG";
            // 
            // tbRg
            // 
            this.tbRg.Location = new System.Drawing.Point(174, 167);
            this.tbRg.Name = "tbRg";
            this.tbRg.Size = new System.Drawing.Size(217, 20);
            this.tbRg.TabIndex = 51;
            this.tbRg.Tag = "<obrigatorio>";
            // 
            // tbCpf
            // 
            this.tbCpf.Location = new System.Drawing.Point(174, 127);
            this.tbCpf.Name = "tbCpf";
            this.tbCpf.Size = new System.Drawing.Size(217, 20);
            this.tbCpf.TabIndex = 50;
            this.tbCpf.Tag = "<obrigatorio>";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(43, 127);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 13);
            this.label11.TabIndex = 49;
            this.label11.Text = "CPF";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Data de Nascimento";
            // 
            // tbNome
            // 
            this.tbNome.Location = new System.Drawing.Point(174, 38);
            this.tbNome.Name = "tbNome";
            this.tbNome.Size = new System.Drawing.Size(217, 20);
            this.tbNome.TabIndex = 46;
            this.tbNome.Tag = "<obrigatorio>";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbNumero);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.tbComplemento);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.tbEstado);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.tbBairro);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.tbCidade);
            this.groupBox3.Location = new System.Drawing.Point(516, 35);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(374, 386);
            this.groupBox3.TabIndex = 59;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Endereço";
            // 
            // tbNumero
            // 
            this.tbNumero.Location = new System.Drawing.Point(107, 142);
            this.tbNumero.Name = "tbNumero";
            this.tbNumero.Size = new System.Drawing.Size(217, 20);
            this.tbNumero.TabIndex = 52;
            this.tbNumero.Tag = "<obrigatorio>";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(43, 142);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 43;
            this.label13.Text = "Numero";
            // 
            // tbComplemento
            // 
            this.tbComplemento.Location = new System.Drawing.Point(107, 183);
            this.tbComplemento.Name = "tbComplemento";
            this.tbComplemento.Size = new System.Drawing.Size(217, 20);
            this.tbComplemento.TabIndex = 39;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "Complemento";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Cidade";
            // 
            // tbEstado
            // 
            this.tbEstado.Location = new System.Drawing.Point(107, 345);
            this.tbEstado.Name = "tbEstado";
            this.tbEstado.ReadOnly = true;
            this.tbEstado.Size = new System.Drawing.Size(217, 20);
            this.tbEstado.TabIndex = 42;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(53, 300);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "Bairro";
            // 
            // tbBairro
            // 
            this.tbBairro.Location = new System.Drawing.Point(107, 293);
            this.tbBairro.Name = "tbBairro";
            this.tbBairro.ReadOnly = true;
            this.tbBairro.Size = new System.Drawing.Size(217, 20);
            this.tbBairro.TabIndex = 41;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(47, 348);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "Estado";
            // 
            // tbCidade
            // 
            this.tbCidade.Location = new System.Drawing.Point(107, 243);
            this.tbCidade.Name = "tbCidade";
            this.tbCidade.ReadOnly = true;
            this.tbCidade.Size = new System.Drawing.Size(217, 20);
            this.tbCidade.TabIndex = 40;
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(155, 36);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(217, 20);
            this.tbEmail.TabIndex = 63;
            this.tbEmail.Tag = "<obrigatorio>";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 62;
            this.label1.Text = "E-mail";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbConfirmarSenha);
            this.groupBox1.Controls.Add(this.tbSenha);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.tbEmail);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(34, 279);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 160);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados de Acesso";
            // 
            // tbConfirmarSenha
            // 
            this.tbConfirmarSenha.Location = new System.Drawing.Point(155, 122);
            this.tbConfirmarSenha.Name = "tbConfirmarSenha";
            this.tbConfirmarSenha.PasswordChar = '*';
            this.tbConfirmarSenha.Size = new System.Drawing.Size(217, 20);
            this.tbConfirmarSenha.TabIndex = 67;
            this.tbConfirmarSenha.Tag = "<obrigatorio>";
            // 
            // tbSenha
            // 
            this.tbSenha.Location = new System.Drawing.Point(155, 82);
            this.tbSenha.Name = "tbSenha";
            this.tbSenha.PasswordChar = '*';
            this.tbSenha.Size = new System.Drawing.Size(217, 20);
            this.tbSenha.TabIndex = 66;
            this.tbSenha.Tag = "<obrigatorio>";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(20, 122);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(83, 13);
            this.label15.TabIndex = 65;
            this.label15.Text = "Confirmar senha";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(20, 82);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 13);
            this.label14.TabIndex = 64;
            this.label14.Text = "Senha";
            // 
            // CadastroGestor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 535);
            this.Controls.Add(this.btVoltar);
            this.Controls.Add(this.btCadastrar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbEndereco);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btConsultarCep);
            this.Controls.Add(this.tbCep);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "CadastroGestor";
            this.Text = "CadastroGestor";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btVoltar;
        private System.Windows.Forms.Button btCadastrar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbEndereco;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btConsultarCep;
        private System.Windows.Forms.TextBox tbCep;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbRg;
        private System.Windows.Forms.TextBox tbCpf;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNome;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbNumero;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbComplemento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbEstado;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbBairro;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbCidade;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbConfirmarSenha;
        private System.Windows.Forms.TextBox tbSenha;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtpDataNasc;
    }
}