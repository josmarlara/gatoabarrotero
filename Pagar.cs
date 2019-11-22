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
    public partial class frmPagar : Form
    {
        MySqlConnection conexion = new MySqlConnection("server=localhost;User id=admin;password=adminlara;database=puntodeventadb");
        DataRow rowVenta;
        private DataTable data = new DataTable();
        public frmPagar(DataTable data)
        {
            InitializeComponent();
            this.data = data;
        }

        private void FrmPagar_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            // Remove the control box so the form will only display client area.
            this.ControlBox = false;
        }

        private void BtnCobrar_Click(object sender, EventArgs e)
        {
            decimal cambio;
            string llaveUnica = Guid.NewGuid().ToString();
            DateTime theDate = DateTime.Now;
            string fecha = theDate.ToString("yyyy-MM-dd H:mm:ss");

            int idVenta;
            try
            {
                conexion.Open();
                string insertarQuery = "INSERT INTO ventastotales (idventa,llaveventa,total,fecha) VALUES(null,?llaveventa,?total,?fecha)";
                MySqlCommand cmd = new MySqlCommand(insertarQuery, conexion);
                cmd.Parameters.Add("?llaveventa", MySqlDbType.VarChar, 100).Value = llaveUnica;
                cmd.Parameters.Add("?total", MySqlDbType.Decimal, 60).Value = txtTotal.Text;
                cmd.Parameters.Add("?fecha", MySqlDbType.DateTime, 60).Value = fecha;
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch
            {

                MessageBox.Show("Inserción fallida");
            }
            try
            {
                conexion.Open();
                string selectQuery = "SELECT idventa FROM ventastotales WHERE llaveventa ='" + llaveUnica + "' ";
                MySqlCommand cmd = new MySqlCommand(selectQuery, conexion);
                MySqlDataAdapter selecionnar = new MySqlDataAdapter();
                selecionnar.SelectCommand = cmd;
                DataTable datosVentas = new DataTable();
                selecionnar.Fill(datosVentas);
                rowVenta = datosVentas.Rows[0];
                idVenta = Convert.ToInt32(rowVenta["idventa"]);

                //MessageBox.Show(Dt.Rows.Count.ToString());



                foreach (DataRow row in data.Rows)
                {
                    int cantidad = Convert.ToInt32(row["Cantidad"]);
                    decimal totalVenta = cantidad * Convert.ToDecimal(row["PrecioU"]);
                    string insertarQuery = "INSERT INTO ventasdetalle (idventa,cantidad,total,codigoBarras) " +
                        "VALUES(@idventa,@cantidad,@total,@codigo)";
                    MySqlCommand cmd2 = new MySqlCommand(insertarQuery, conexion);
                    cmd2.Parameters.AddWithValue("@idventa", idVenta);
                    cmd2.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd2.Parameters.AddWithValue("@total", totalVenta);
                    cmd2.Parameters.AddWithValue("@codigo", row[1].ToString());
                    cmd2.ExecuteNonQuery();

                }



                Ticket Ticket1 = new Ticket();
                //Ticket1.AbreCajon();  //abre el cajon
                Ticket1.TextoCentro("GATO ABARROTERO");
                Ticket1.TextoCentro("Venta No." + idVenta);
                Ticket1.TextoCentro("FECHA:" + fecha);// imprime en el centro "Venta mostrador"
                Ticket1.LineasGuion(); // imprime una linea de guiones
                Ticket1.EncabezadoVenta(); // imprime encabezados
                foreach (DataRow row in data.Rows)
                {
                    int cantidad = Convert.ToInt32(row["Cantidad"]);
                    double totalVenta = cantidad * Convert.ToDouble(row["PrecioU"]);
                    String producto = row["Producto"].ToString();
                    double precio = Convert.ToDouble(row["PrecioU"]);
                    Ticket1.AgregaArticulo(producto, cantidad, precio, totalVenta); //imprime una linea de descripcion
                }

                Ticket1.LineasTotales(); // imprime linea

                Ticket1.AgregaTotales("Total", Convert.ToDouble(txtTotal.Text)); // imprime linea con total

                //Ticket1.CortaTicket(); // corta el ticket

                conexion.Close();


            }
            catch (MySqlException E)
            {
                MessageBox.Show(E.ToString());
            }






            cambio = Convert.ToDecimal(txtEfectivo.Text) - Convert.ToDecimal(txtTotal.Text);
            txtCambio.Text = Convert.ToString(cambio);

        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            frmPuntoVenta puntoVenta = new frmPuntoVenta();
            puntoVenta.Show();
            this.Hide();
        }
    }
}
