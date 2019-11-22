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
    public partial class frmReportes : Form
    {
        MySqlConnection conexion = new MySqlConnection("server=localhost;User id=admin;password=adminlara;database=puntodeventadb");
        public frmReportes()
        {
            InitializeComponent();
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();

                string selectQuery = "SELECT SUM(total) as ventatotal FROM ventastotales " +
                    "WHERE CAST(fecha as date) = @dia ";
                MySqlCommand cmd = new MySqlCommand(selectQuery, conexion);
                cmd.Parameters.AddWithValue("@dia", dtpFecha.Value.Date);
                MySqlDataAdapter selecionnar = new MySqlDataAdapter();
                selecionnar.SelectCommand = cmd;
                DataTable datosVentas = new DataTable();
                selecionnar.Fill(datosVentas);
                if (datosVentas.Rows.Count == 0)
                {
                    MessageBox.Show("No tuviste ventas");

                    conexion.Close();
                }
                else
                {
                    DataRow row = datosVentas.Rows[0];
                    decimal ventasPorDia = Convert.ToDecimal(row["ventatotal"] is DBNull ? 0 : row["ventatotal"]);
                    lblventa.Text = "Las ventas totales fueron de: $" + ventasPorDia;
                    conexion.Close();
                }
            }
            catch (MySqlException E)
            {
                MessageBox.Show(E.ToString());
            }
        }

        private void MenúToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMenu menu = new frmMenu();
            menu.Show();
        }
    }
}
