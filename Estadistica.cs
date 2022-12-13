using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace CRUD_SQLME
{
    public partial class Estadistica : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Estadistica";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Estadistica");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Estadistica"];

        }
        public Estadistica()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Estadistica_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string killDeathAssistant = textBox1.Text;
            string farmPorMinuto = textBox2.Text;
            string campeonesDomesticos = textBox3.Text;
            string campeonesMundiales = textBox4.Text;
            string partidasJugadas = textBox5.Text;
            string idJugador = textBox6.Text;



            consulta = "INSERT INTO Estadistica (killDeathAssistant,farmPorMinuto,campeonesDomesticos,campeonesMundiales,partidasJugadas,idJugador) values " +
                "('" + killDeathAssistant + "','" + farmPorMinuto + "','" + campeonesDomesticos + "','" + campeonesMundiales + "','" + partidasJugadas + "','" + idJugador +
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
            int idEstadistica = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Estadistica SET ESTATUS = 0 WHERE idEstadistica =" + idEstadistica.ToString();
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
            int idEstadistica = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE Estadistica SET cantidadCampeones ='" + cantidadCampeones + "','" + "',cantidadGestos = '" + cantidadGestos +
                "',cantidadHechizos = '" + cantidadHechizos + "',cantidadHechizos = '" + cantidadHechizos + "'" + "'WHERE idEstadistica = " + idEstadistica.ToString();
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

        }
    }
}
