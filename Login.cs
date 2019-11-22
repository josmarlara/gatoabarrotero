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
    public partial class frmLogin : Form
    {

        MySqlConnection conexion = new MySqlConnection("server=localhost;User id=admin;password=adminlara;database=puntodeventadb");
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void LblUsuario_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            conexion.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM usuario WHERE usuario ='" +
                txtUsuario.Text + "' AND password = '" + txtPassword.Text + "' ", conexion);
            MySqlDataReader leerLogin = cmd.ExecuteReader();

            if (leerLogin.Read())
            {

                this.Hide();
                frmMenu menu = new frmMenu();
                menu.Show();


            }
            else
                MessageBox.Show("Error: Ingrese sus datos corectamente");

            conexion.Close();
        }
    }
}
