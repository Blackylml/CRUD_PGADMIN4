using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace CRUD_SQLME
{
    public partial class Jugador : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM jugador";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "jugador");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["jugador"];

        }
        public Jugador()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void Jugador_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string apodo = textBox1.Text;
            string nombre = textBox2.Text;
            string edad = textBox3.Text;
            string nacionalidad = textBox4.Text;
            string main = textBox5.Text;
            string idEquipo = textBox6.Text;

            consulta = "INSERT INTO jugador (apodo,nombre,edad,nacionalidad,main,idEquipo) values " +
                "('" + apodo + "','" + nombre + "','" + edad + "','" + nacionalidad + "','" + main + "','" + idEquipo +
                "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idjugador = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE jugador SET ESTATUS = 0 WHERE idjugador =" + idjugador.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string cantidadCampeones = textBox1.Text;
            string cantidadGestos = textBox2.Text;
            string cantidadHechizos = textBox3.Text;
            string cantidadCentinelas = textBox4.Text;
            int idjugador = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE jugador SET cantidadCampeones ='" + cantidadCampeones + "','" + "',cantidadGestos = '" + cantidadGestos +
                "',cantidadHechizos = '" + cantidadHechizos + "',cantidadHechizos = '" + cantidadHechizos + "'" + "'WHERE idjugador = " + idjugador.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
            Menu regresar = new Menu();
            regresar.Show();
        }
    }
}
