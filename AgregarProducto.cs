using MySql.Data.MySqlClient;
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
    public partial class frmAgregarProducto : Form
    {
        MySqlConnection conexion = new MySqlConnection("server=localhost;User id=admin;password=adminlara;database=puntodeventadb");
        public frmAgregarProducto()
        {
            InitializeComponent();
        }

        private void BtnGuardarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                string insertarQuery = "INSERT INTO producto (idProducto,codigoBarras,nombre,precio) VALUES(null,?codigoBarras,?nombre,?precio)";
                MySqlCommand cmd = new MySqlCommand(insertarQuery, conexion);
                cmd.Parameters.Add("?codigoBarras", MySqlDbType.VarChar, 60).Value = txtCodigoBarras.Text;
                cmd.Parameters.Add("?nombre", MySqlDbType.VarChar, 60).Value = txtNombreProducto.Text;
                cmd.Parameters.Add("?precio", MySqlDbType.Decimal, 60).Value = txtPrecio.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Registro Exitoso");
                txtCodigoBarras.Text = " ";
                txtNombreProducto.Text = " ";
                txtPrecio.Text = " ";
                conexion.Close();
            }
            catch
            {

                MessageBox.Show("Inserción fallida");
            }

        }

        private void BuscarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVerProducto verProducto = new frmVerProducto();
            verProducto.Show();
        }

        private void EliminarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmEliminarProducto eliminarProdcuto = new frmEliminarProducto();
            eliminarProdcuto.Show();
        }

        private void ActualizarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmActualizarProducto actualizarProducto = new frmActualizarProducto();
            actualizarProducto.Show();
        }

        private void MenúToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMenu menu = new frmMenu();
            menu.Show();
        }
    }
}
