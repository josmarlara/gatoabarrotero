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
    public partial class frmEliminarProducto : Form
    {
        MySqlConnection conexion = new MySqlConnection("server=localhost;User id=admin;password=adminlara;database=puntodeventadb");
        public frmEliminarProducto()
        {
            InitializeComponent();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void BtnBuscarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                string selectQuery = "SELECT * FROM producto WHERE nombre LIKE '%" + txtNombreProducto.Text + "%' ";
                MySqlCommand cmd = new MySqlCommand(selectQuery, conexion);
                MySqlDataAdapter selecionnar = new MySqlDataAdapter();
                selecionnar.SelectCommand = cmd;
                DataTable datosProducto = new DataTable();
                selecionnar.Fill(datosProducto);
                dtgvProductos.DataSource = datosProducto;
                conexion.Close();


                btnEliminarProducto.Enabled = true;



            }
            catch
            {
                MessageBox.Show("Error al conectar");
            }

        }

        private void FrmEliminarProducto_Load(object sender, EventArgs e)
        {
            btnEliminarProducto.Enabled = false;
        }

        private void BtnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (dtgvProductos.CurrentRow == null)
            {
                MessageBox.Show("Selecionar fila");
                return;
            }
            int idProducto = Convert.ToInt32(dtgvProductos.CurrentRow.Cells["idProducto"].Value);
            try
            {
                conexion.Open();
                string eliminarQuery = "DELETE FROM producto WHERE idProducto = @idProducto ";
                MySqlCommand cmd = new MySqlCommand(eliminarQuery, conexion);
                cmd.Parameters.AddWithValue("@idProducto", idProducto);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Eliminación Exitosa");
                dtgvProductos.Rows.Remove(dtgvProductos.CurrentRow);
                conexion.Close();
            }
            catch
            {

                MessageBox.Show("Eliminación fallida");
            }

        }

        private void AgregarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAgregarProducto agregarProducto = new frmAgregarProducto();
            agregarProducto.Show();
        }

        private void MenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMenu menu = new frmMenu();
            menu.Show();

        }

        private void ActualizarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmActualizarProducto ac = new frmActualizarProducto();
            ac.Show();
        }
    }
}
