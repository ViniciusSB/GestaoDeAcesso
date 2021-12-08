
namespace GestaoDeAcesso.view
{
    partial class Automoveis
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lvAutomoveis = new System.Windows.Forms.ListView();
            this.chId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTipo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chModelo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMarca = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPlaca = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbAutomovel = new System.Windows.Forms.Label();
            this.lbCadastrar = new System.Windows.Forms.Button();
            this.condôminosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visitantesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.listarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicioToolStripMenuItem,
            this.condôminosToolStripMenuItem,
            this.visitantesToolStripMenuItem,
            this.ajudaToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(835, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            this.inicioToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.inicioToolStripMenuItem.Text = "Inicio";
            this.inicioToolStripMenuItem.Click += new System.EventHandler(this.inicioToolStripMenuItem_Click);
            // 
            // lvAutomoveis
            // 
            this.lvAutomoveis.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chId,
            this.chTipo,
            this.chModelo,
            this.chMarca,
            this.chAno,
            this.chPlaca});
            this.lvAutomoveis.FullRowSelect = true;
            this.lvAutomoveis.GridLines = true;
            this.lvAutomoveis.HideSelection = false;
            this.lvAutomoveis.Location = new System.Drawing.Point(155, 75);
            this.lvAutomoveis.Name = "lvAutomoveis";
            this.lvAutomoveis.Size = new System.Drawing.Size(369, 381);
            this.lvAutomoveis.TabIndex = 24;
            this.lvAutomoveis.UseCompatibleStateImageBehavior = false;
            this.lvAutomoveis.View = System.Windows.Forms.View.Details;
            this.lvAutomoveis.SelectedIndexChanged += new System.EventHandler(this.indeceSelecionado);
            // 
            // chId
            // 
            this.chId.Text = "Id";
            // 
            // chTipo
            // 
            this.chTipo.Text = "Tipo";
            // 
            // chModelo
            // 
            this.chModelo.Text = "Modelo";
            // 
            // chMarca
            // 
            this.chMarca.Text = "Marca";
            // 
            // chAno
            // 
            this.chAno.Text = "Ano";
            // 
            // chPlaca
            // 
            this.chPlaca.Text = "Placa";
            // 
            // lbAutomovel
            // 
            this.lbAutomovel.AutoSize = true;
            this.lbAutomovel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAutomovel.Location = new System.Drawing.Point(151, 48);
            this.lbAutomovel.Name = "lbAutomovel";
            this.lbAutomovel.Size = new System.Drawing.Size(109, 24);
            this.lbAutomovel.TabIndex = 25;
            this.lbAutomovel.Text = "Automóveis";
            // 
            // lbCadastrar
            // 
            this.lbCadastrar.Location = new System.Drawing.Point(449, 49);
            this.lbCadastrar.Name = "lbCadastrar";
            this.lbCadastrar.Size = new System.Drawing.Size(75, 23);
            this.lbCadastrar.TabIndex = 26;
            this.lbCadastrar.Text = "Cadastrar";
            this.lbCadastrar.UseVisualStyleBackColor = true;
            this.lbCadastrar.Click += new System.EventHandler(this.lbCadastrar_Click);
            // 
            // condôminosToolStripMenuItem
            // 
            this.condôminosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarToolStripMenuItem,
            this.listarToolStripMenuItem});
            this.condôminosToolStripMenuItem.Name = "condôminosToolStripMenuItem";
            this.condôminosToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.condôminosToolStripMenuItem.Text = "Condôminos";
            // 
            // visitantesToolStripMenuItem
            // 
            this.visitantesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarToolStripMenuItem1,
            this.listarToolStripMenuItem1});
            this.visitantesToolStripMenuItem.Name = "visitantesToolStripMenuItem";
            this.visitantesToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.visitantesToolStripMenuItem.Text = "Visitantes";
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.ajudaToolStripMenuItem.Text = "Ajuda";
            this.ajudaToolStripMenuItem.Click += new System.EventHandler(this.ajudaToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // cadastrarToolStripMenuItem
            // 
            this.cadastrarToolStripMenuItem.Name = "cadastrarToolStripMenuItem";
            this.cadastrarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cadastrarToolStripMenuItem.Text = "Cadastrar";
            this.cadastrarToolStripMenuItem.Click += new System.EventHandler(this.cadastrarToolStripMenuItem_Click);
            // 
            // listarToolStripMenuItem
            // 
            this.listarToolStripMenuItem.Name = "listarToolStripMenuItem";
            this.listarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.listarToolStripMenuItem.Text = "Listar";
            this.listarToolStripMenuItem.Click += new System.EventHandler(this.listarToolStripMenuItem_Click);
            // 
            // cadastrarToolStripMenuItem1
            // 
            this.cadastrarToolStripMenuItem1.Name = "cadastrarToolStripMenuItem1";
            this.cadastrarToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.cadastrarToolStripMenuItem1.Text = "Cadastrar";
            this.cadastrarToolStripMenuItem1.Click += new System.EventHandler(this.cadastrarToolStripMenuItem1_Click);
            // 
            // listarToolStripMenuItem1
            // 
            this.listarToolStripMenuItem1.Name = "listarToolStripMenuItem1";
            this.listarToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.listarToolStripMenuItem1.Text = "Listar";
            this.listarToolStripMenuItem1.Click += new System.EventHandler(this.listarToolStripMenuItem1_Click);
            // 
            // Automoveis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 493);
            this.Controls.Add(this.lbCadastrar);
            this.Controls.Add(this.lbAutomovel);
            this.Controls.Add(this.lvAutomoveis);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Automoveis";
            this.Text = "Automoveis";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inicioToolStripMenuItem;
        private System.Windows.Forms.ListView lvAutomoveis;
        private System.Windows.Forms.ColumnHeader chId;
        private System.Windows.Forms.ColumnHeader chTipo;
        private System.Windows.Forms.ColumnHeader chModelo;
        private System.Windows.Forms.ColumnHeader chMarca;
        private System.Windows.Forms.ColumnHeader chAno;
        private System.Windows.Forms.ColumnHeader chPlaca;
        private System.Windows.Forms.Label lbAutomovel;
        private System.Windows.Forms.Button lbCadastrar;
        private System.Windows.Forms.ToolStripMenuItem condôminosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visitantesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem listarToolStripMenuItem1;
    }
}