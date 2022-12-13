using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace CRUD_SQLME
{
    public partial class Historial : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Historial";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Historial");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Historial"];

        }
        public Historial()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void Historial_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            string campeonJugado = textBox1.Text;
            string asesinatos = textBox2.Text;
            string muertes = textBox3.Text;
            string asistencias = textBox4.Text;
            string minionsEliminados = textBox3.Text;
            string oroObtenido = textBox4.Text;
            string fecha = textBox5.Text;
            string duracion = textBox1.Text;
            string idUsuario = textBox2.Text;



            consulta = "INSERT INTO Historial (campeonJugado,asesinatos,muertes,asistencias,minionsEliminados,oroObtenido,fecha,duracion,idUsuario) values " +
                "('" + campeonJugado + "','" + asesinatos + "','" + muertes + "','" + asistencias + "','" + minionsEliminados + "','" + oroObtenido +
                "','" + fecha + "','" + duracion +"','" + idUsuario+"')";
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
            int idHistorial = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Historial SET ESTATUS = 0 WHERE idHistorial =" + idHistorial.ToString();
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
            int idHistorial = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE Historial SET cantidadCampeones ='" + cantidadCampeones + "','" + "',cantidadGestos = '" + cantidadGestos +
                "',cantidadHechizos = '" + cantidadHechizos + "',cantidadHechizos = '" + cantidadHechizos + "'" + "'WHERE idHistorial = " + idHistorial.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
            Menu regresar = new Menu();
            regresar.Show();
        }
    }
}
