using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace CRUD_SQLME
{
    public partial class Equipo : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Equipo";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Equipo");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Equipo"];

        }
        public Equipo()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void Equipo_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
            Menu regresar = new Menu();
            regresar.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombreEquipo = textBox1.Text;
            string toplaner = textBox2.Text;
            string jungla = textBox3.Text;
            string mid = textBox4.Text;
            string tirador = textBox5.Text;
            string soporte = textBox6.Text;
            string coach = textBox7.Text;
            string suplente = textBox8.Text;
            string idRegion = textBox9.Text;

            consulta = "INSERT INTO Equipo (nombreEquipo,toplaner,jungla,mid,tirador,soporte,coach,suplente,idRegion) values " +
                "('" + nombreEquipo + "','" + toplaner + "','" + jungla + "','" + mid + "','" + tirador + "','" + soporte +
                "','" + coach + "','" + suplente + "'.'" + idRegion + "')";
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

            int idEquipo = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Equipo SET ESTATUS = 0 WHERE idEquipo =" + idEquipo.ToString();
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
            int idEquipo = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE Equipo SET cantidadCampeones ='" + cantidadCampeones + "','" + "',cantidadGestos = '" + cantidadGestos +
                "',cantidadHechizos = '" + cantidadHechizos + "',cantidadHechizos = '" + cantidadHechizos + "'" + "'WHERE idEquipo = " + idEquipo.ToString();
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
}
