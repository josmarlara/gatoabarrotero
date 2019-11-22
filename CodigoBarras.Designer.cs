namespace GatoAbarrotero
{
    partial class frmCodigoBarras
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
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menúToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlCodigoBarras = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnGenerarCodigo = new System.Windows.Forms.Button();
            this.btnGuardarCodigo = new System.Windows.Forms.Button();
            this.btnImprimirCodigo = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menúToolStripMenuItem});
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // menúToolStripMenuItem
            // 
            this.menúToolStripMenuItem.Name = "menúToolStripMenuItem";
            this.menúToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.menúToolStripMenuItem.Text = "Menú";
            this.menúToolStripMenuItem.Click += new System.EventHandler(this.MenúToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(254, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Generador de Código de Barras";
            // 
            // pnlCodigoBarras
            // 
            this.pnlCodigoBarras.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlCodigoBarras.Location = new System.Drawing.Point(197, 91);
            this.pnlCodigoBarras.Name = "pnlCodigoBarras";
            this.pnlCodigoBarras.Size = new System.Drawing.Size(396, 101);
            this.pnlCodigoBarras.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(252, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Texto para código de barras:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(279, 236);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(294, 20);
            this.txtCodigo.TabIndex = 4;
            // 
            // btnGenerarCodigo
            // 
            this.btnGenerarCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarCodigo.Location = new System.Drawing.Point(36, 305);
            this.btnGenerarCodigo.Name = "btnGenerarCodigo";
            this.btnGenerarCodigo.Size = new System.Drawing.Size(247, 31);
            this.btnGenerarCodigo.TabIndex = 5;
            this.btnGenerarCodigo.Text = "Generar Código de Barras";
            this.btnGenerarCodigo.UseVisualStyleBackColor = true;
            this.btnGenerarCodigo.Click += new System.EventHandler(this.BtnGenerarCodigo_Click);
            // 
            // btnGuardarCodigo
            // 
            this.btnGuardarCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarCodigo.Location = new System.Drawing.Point(307, 305);
            this.btnGuardarCodigo.Name = "btnGuardarCodigo";
            this.btnGuardarCodigo.Size = new System.Drawing.Size(247, 31);
            this.btnGuardarCodigo.TabIndex = 6;
            this.btnGuardarCodigo.Text = "Guardar Código de Barras";
            this.btnGuardarCodigo.UseVisualStyleBackColor = true;
            this.btnGuardarCodigo.Click += new System.EventHandler(this.BtnGuardarCodigo_Click);
            // 
            // btnImprimirCodigo
            // 
            this.btnImprimirCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimirCodigo.Location = new System.Drawing.Point(36, 366);
            this.btnImprimirCodigo.Name = "btnImprimirCodigo";
            this.btnImprimirCodigo.Size = new System.Drawing.Size(247, 31);
            this.btnImprimirCodigo.TabIndex = 7;
            this.btnImprimirCodigo.Text = "Imprimir Código de Barras";
            this.btnImprimirCodigo.UseVisualStyleBackColor = true;
            this.btnImprimirCodigo.Click += new System.EventHandler(this.BtnImprimirCodigo_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocument1_PrintPage);
            // 
            // frmCodigoBarras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnImprimirCodigo);
            this.Controls.Add(this.btnGuardarCodigo);
            this.Controls.Add(this.btnGenerarCodigo);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnlCodigoBarras);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmCodigoBarras";
            this.Text = "CodigoBarras";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menúToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlCodigoBarras;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnGenerarCodigo;
        private System.Windows.Forms.Button btnGuardarCodigo;
        private System.Windows.Forms.Button btnImprimirCodigo;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}