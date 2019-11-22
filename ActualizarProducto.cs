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
    public partial class frmActualizarProducto : Form
    {
        MySqlConnection conexion = new MySqlConnection("server=localhost;User id=admin;password=adminlara;database=puntodeventadb");
        public frmActualizarProducto()
        {
            InitializeComponent();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                string selectQuery = "SELECT * FROM producto WHERE nombre LIKE '%" + txtProducto.Text + "%' ";
                MySqlCommand cmd = new MySqlCommand(selectQuery, conexion);
                MySqlDataAdapter selecionnar = new MySqlDataAdapter();
                selecionnar.SelectCommand = cmd;
                DataTable datosProducto = new DataTable();
                selecionnar.Fill(datosProducto);
                dtgvProductos.DataSource = datosProducto;
                conexion.Close();


                btnActualizarProducto.Enabled = true;



            }
            catch
            {
                MessageBox.Show("Error al conectar");
            }
        }

        private void BtnActualizarProducto_Click(object sender, EventArgs e)
        {
            if (dtgvProductos.CurrentRow == null)
            {
                MessageBox.Show("Selecionar fila");
                return;
            }
            int idProducto = Convert.ToInt32(dtgvProductos.CurrentRow.Cells["idProducto"].Value);
            string codigoBarras = Convert.ToString(dtgvProductos.CurrentRow.Cells["codigoBarras"].Value);
            string nombre = Convert.ToString(dtgvProductos.CurrentRow.Cells["nombre"].Value);
            double precio = Convert.ToDouble(dtgvProductos.CurrentRow.Cells["precio"].Value);

            try
            {
                conexion.Open();
                string actualizarQuery = "UPDATE  producto SET  codigoBarras = @codigoBarras, nombre = @nombre , precio = @precio   " +
                    "WHERE idProducto = @idProducto ";
                MySqlCommand cmd = new MySqlCommand(actualizarQuery, conexion);
                cmd.Parameters.AddWithValue("@idProducto", idProducto);
                cmd.Parameters.AddWithValue("@codigoBarras", codigoBarras);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@precio", precio);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Actualización Exitosa");
                dtgvProductos.Update();
                conexion.Close();
            }
            catch
            {

                MessageBox.Show("Actualización fallida");
            }

        }

        private void AgregarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAgregarProducto ap = new frmAgregarProducto();
            ap.Show();
        }

        private void EliminarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmEliminarProducto ep = new frmEliminarProducto();
            ep.Show();
        }

        private void MenúToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMenu menu = new frmMenu();
            menu.Show();
        }
    }
}
