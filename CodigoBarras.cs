using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GatoAbarrotero
{
    public partial class frmCodigoBarras : Form
    {
        public frmCodigoBarras()
        {
            InitializeComponent();
            btnGuardarCodigo.Enabled = false;
            btnImprimirCodigo.Enabled = false;
        }

        private void BtnGenerarCodigo_Click(object sender, EventArgs e)
        {
            BarcodeLib.Barcode codigo = new BarcodeLib.Barcode();
            codigo.IncludeLabel = true;
            pnlCodigoBarras.BackgroundImage = codigo.Encode(BarcodeLib.TYPE.CODE128, txtCodigo.Text, Color.Black, Color.White, 400, 100);
            btnGuardarCodigo.Enabled = true;
            btnImprimirCodigo.Enabled = true;
        }

        private void BtnGuardarCodigo_Click(object sender, EventArgs e)
        {
            Image imgFinal = (Image)pnlCodigoBarras.BackgroundImage.Clone();
            SaveFileDialog dialogoGuardar = new SaveFileDialog();
            dialogoGuardar.AddExtension = true;
            dialogoGuardar.Filter = "Image PNG (*.png)|*.png";
            dialogoGuardar.ShowDialog();
            if (!string.IsNullOrEmpty(dialogoGuardar.FileName))
            {
                imgFinal.Save(dialogoGuardar.FileName, ImageFormat.Png);
            }
            imgFinal.Dispose();
        }

        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.pnlCodigoBarras.Width, this.pnlCodigoBarras.Height);
            pnlCodigoBarras.DrawToBitmap(bm, new Rectangle(0, 0, this.pnlCodigoBarras.Width, this.pnlCodigoBarras.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void BtnImprimirCodigo_Click(object sender, EventArgs e)
        {
            printDocument1.Print();

        }

        private void MenúToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMenu menu = new frmMenu();
            menu.Show();
        }
    }
}
