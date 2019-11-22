using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GatoAbarrotero
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void BtnProductos_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAgregarProducto agregarProdcuto = new frmAgregarProducto();
            agregarProdcuto.Show();

        }

        private void BtnCodigo_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCodigoBarras codigo = new frmCodigoBarras();
            codigo.Show();
        }

        private void BtnPunto_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmPuntoVenta punto = new frmPuntoVenta();
            punto.Show();
        }

        private void BtnReportes_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmReportes reportes = new frmReportes();
            reportes.Show();
        }
    }
}
