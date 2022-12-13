using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace CRUD_SQLME
{
    public partial class Eterno : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Eterno";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Eterno");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Eterno"];

        }
        public Eterno()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string serie = textBox1.Text;
            string descripcionEternoInicial = textBox2.Text;
            string decripcionEternoMedio = textBox3.Text;
            string decripcionEternoFinal = textBox4.Text;
            string descripcion = textBox5.Text;
            string precio = textBox6.Text;


            consulta = "INSERT INTO Eterno (serie,descripcionEternoInicial,decripcionEternoMedio,decripcionEternoFinal,descripcion,precio) values " +
                "('" + serie + "','" + descripcionEternoInicial + "','" + decripcionEternoMedio + "','" + decripcionEternoFinal + "','" + descripcion + "','" + precio+ "')";
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
            int idEterno = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Eterno SET ESTATUS = 0 WHERE idEterno =" + idEterno.ToString();
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
            int idEterno = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE Eterno SET cantidadCampeones ='" + cantidadCampeones + "','" + "',cantidadGestos = '" + cantidadGestos +
                "',cantidadHechizos = '" + cantidadHechizos + "',cantidadHechizos = '" + cantidadHechizos + "'" + "'WHERE idEterno = " + idEterno.ToString();
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

        private void Eterno_Load(object sender, EventArgs e)
        {

        }
    }
}
