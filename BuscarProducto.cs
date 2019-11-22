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

   
    public partial class frmVerProducto : Form
    {
        MySqlConnection conexion = new MySqlConnection("server=localhost;User id=admin;password=adminlara;database=puntodeventadb");
        public frmVerProducto()
        {
            InitializeComponent();
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






            }
            catch
            {
                MessageBox.Show("Error al conectar");
            }
        }

    }
    }

