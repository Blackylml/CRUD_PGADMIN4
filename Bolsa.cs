using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace CRUD_SQLME
{
    public partial class Bolsa : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Bolsa";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Bolsa");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Bolsa"];

        }
        public Bolsa()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string cantidadCampeones = textBox1.Text;
            string cantidadGestos = textBox2.Text;
            string cantidadHechizos = textBox3.Text;
            string cantidadCentinelas = textBox4.Text;

            consulta = "INSERT INTO Bolsa (cantidadCampeones,cantidadGestos,cantidadHechizos,cantidadCentinelas) values " +
                "('" + cantidadCampeones + "','" + cantidadGestos + "','" + cantidadHechizos + "','" + cantidadCentinelas + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idBolsa = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Bolsa SET ESTATUS = 0 WHERE idBolsa =" + idBolsa.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            {
                string cantidadCampeones = textBox1.Text;
                string cantidadGestos = textBox2.Text;
                string cantidadHechizos = textBox3.Text;
                string cantidadCentinelas = textBox4.Text;
                consulta = "UPDATE Idioma SET cantidadCampeones = '" + cantidadCampeones + "',cantidadGestos =  '" + cantidadGestos + "',cantidadHechizos = '" +
                    cantidadHechizos + "', cantidadCentinelas = '" + cantidadCentinelas ;
                conexion.Open();
                comando = new SqlCommand(consulta, conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
                MostrarDatos();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
            Menu regresar = new Menu();
            regresar.Show();
        }

        private void Bolsa_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
    }
}
