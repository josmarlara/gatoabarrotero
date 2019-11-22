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
    public partial class frmPuntoVenta : Form
    {

        MySqlConnection conexion = new MySqlConnection("server=localhost;User id=admin;password=adminlara;database=puntodeventadb");
        public frmPuntoVenta()
        {
            InitializeComponent();
            InitializaeEvents();
        }
        private void InitializaeEvents()
        {
            this.txtCodigo.KeyPress += new KeyPressEventHandler(TxtCodigo_KeyPress);

        }
        private void TxtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                try
                {
                    conexion.Open();
                    string selectQuery = "SELECT codigoBarras,nombre,precio FROM producto WHERE codigoBarras ='" + txtCodigo.Text + "' ";
                    MySqlCommand cmd = new MySqlCommand(selectQuery, conexion);
                    MySqlDataAdapter selecionnar = new MySqlDataAdapter();
                    selecionnar.SelectCommand = cmd;
                    DataTable datosProducto = new DataTable();
                    selecionnar.Fill(datosProducto);
                    if (datosProducto.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encuenta el producto");
                        conexion.Close();
                        txtCodigo.Text = "";
                    }
                    else
                    {
                        DataRow row = datosProducto.Rows[0];

                        Producto producto = new Producto();

                        producto.codigo = row["codigoBarras"].ToString();
                        producto.nombre = row["nombre"].ToString();
                        producto.precio = Convert.ToDecimal(row["precio"]);

                        Boolean agregar = true;
                        Boolean sumar = true;
                        producto.cantidad = 1;
                        decimal total = 0;
                        if (dtgvProductos.Rows.Count > 0)
                        {
                            foreach (DataGridViewRow fila in dtgvProductos.Rows)
                            {

                                object valor = fila.Cells["Codigo"].Value;
                                if (String.Compare(producto.codigo, valor.ToString()) == 0)
                                {
                                    producto.cantidad += Convert.ToInt32(fila.Cells["Cantidad"].Value);
                                    fila.Cells["Cantidad"].Value = producto.cantidad;
                                    total += Convert.ToDecimal(fila.Cells["PrecioU"].Value) * producto.cantidad;
                                    agregar = false;
                                }

                                else
                                {
                                    sumar = false;
                                }




                            }

                            if (sumar == false)
                            {
                                total = Convert.ToDecimal(txtTotal.Text) + producto.precio;
                            }



                            if (agregar == true)
                            {
                                dtgvProductos.Rows.Add(producto.cantidad, producto.codigo, producto.nombre, producto.precio);

                            }

                            txtTotal.Text = Convert.ToString(total);

                        }
                        else
                        {
                            dtgvProductos.Rows.Add(producto.cantidad, producto.codigo, producto.nombre, producto.precio);


                            total += producto.precio;
                            txtTotal.Text = Convert.ToString(total);
                        }




                        conexion.Close();




                    }


                    txtCodigo.Text = "";


                }
                catch (MySqlException E)
                {
                    MessageBox.Show(E.ToString());
                }
            }
        }

        private void BtnAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                string selectQuery = "SELECT codigoBarras,nombre,precio FROM producto WHERE codigoBarras ='" + txtCodigo.Text + "' ";
                MySqlCommand cmd = new MySqlCommand(selectQuery, conexion);
                MySqlDataAdapter selecionnar = new MySqlDataAdapter();
                selecionnar.SelectCommand = cmd;
                DataTable datosProducto = new DataTable();
                selecionnar.Fill(datosProducto);
                if (datosProducto.Rows.Count == 0)
                {
                    MessageBox.Show("No se encuenta el producto");
                    txtCodigo.Text = "";
                    conexion.Close();
                }
                else
                {
                    DataRow row = datosProducto.Rows[0];

                    Producto producto = new Producto();

                    producto.codigo = row["codigoBarras"].ToString();
                    producto.nombre = row["nombre"].ToString();
                    producto.precio = Convert.ToDecimal(row["precio"]);

                    Boolean agregar = true;
                    Boolean sumar = true;
                    producto.cantidad = 1;
                    decimal total = 0;
                    if (dtgvProductos.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow fila in dtgvProductos.Rows)
                        {

                            object valor = fila.Cells["Codigo"].Value;
                            if (String.Compare(producto.codigo, valor.ToString()) == 0)
                            {
                                producto.cantidad += Convert.ToInt32(fila.Cells["Cantidad"].Value);
                                fila.Cells["Cantidad"].Value = producto.cantidad;
                                total += Convert.ToDecimal(fila.Cells["PrecioU"].Value) * producto.cantidad;
                                agregar = false;
                            }

                            else
                            {
                                sumar = false;
                            }




                        }

                        if (sumar == false)
                        {
                            total = Convert.ToDecimal(txtTotal.Text) + producto.precio;
                        }



                        if (agregar == true)
                        {
                            dtgvProductos.Rows.Add(producto.cantidad, producto.codigo, producto.nombre, producto.precio);

                        }

                        txtTotal.Text = Convert.ToString(total);

                    }
                    else
                    {
                        dtgvProductos.Rows.Add(producto.cantidad, producto.codigo, producto.nombre, producto.precio);


                        total += producto.precio;
                        txtTotal.Text = Convert.ToString(total);
                    }




                    conexion.Close();

                    txtCodigo.Text = "";


                }





            }
            catch (MySqlException E)
            {
                MessageBox.Show(E.ToString());
            }
        }

        private void BtnCancelarCompra_Click(object sender, EventArgs e)
        {
            dtgvProductos.Rows.Clear();
            dtgvProductos.Refresh();

        }

        private void BtnPagar_Click(object sender, EventArgs e)
        {
            DataTable data = new DataTable();
            foreach (DataGridViewColumn columna in this.dtgvProductos.Columns)
            {
                DataColumn col = new DataColumn(columna.Name);
                data.Columns.Add(col);
            }
            //Recorrer filas
            foreach (DataGridViewRow fila in this.dtgvProductos.Rows)
            {
                DataRow dr = data.NewRow();
                dr[0] = fila.Cells[0].Value.ToString();
                dr[1] = fila.Cells[1].Value.ToString();
                dr[2] = fila.Cells[2].Value.ToString();
                dr[3] = fila.Cells[3].Value.ToString();
                data.Rows.Add(dr);
            }





            dtgvProductos.DataSource = data;
            frmPagar pg = new frmPagar(data);//En el otro código se crea el contructor

            pg.txtTotal.Text = txtTotal.Text;

            pg.Show();
            this.Hide();
        }

        private void BuscarProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVerProducto buscar = new frmVerProducto();
            buscar.Show();
        }

        private void MenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMenu menu = new frmMenu();
            menu.Show();
        }
    }
}
