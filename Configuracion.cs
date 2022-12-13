using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace CRUD_SQLME
{
    public partial class Configuracion : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Configuracion";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Configuracion");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Configuracion"];

        }
        public Configuracion()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void Configuracion_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string graficos = textBox1.Text;
            string atajos = textBox2.Text;
            string sonido = textBox3.Text;
            string chat = textBox4.Text;
            string idUsuario = textBox5.Text;


            consulta = "INSERT INTO Configuracion (graficos,atajos,sonido,chat,idUsuario) values " +
                "('" + graficos + "','" + atajos + "','" + sonido + "','" + chat + "','" + idUsuario + "')";
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
            int idConfiguracion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Configuracion SET ESTATUS = 0 WHERE idConfiguracion =" + idConfiguracion.ToString();
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
            int idConfiguracion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE Configuracion SET cantidadCampeones ='" + cantidadCampeones + "','" + "',cantidadGestos = '" + cantidadGestos +
                "',cantidadHechizos = '" + cantidadHechizos + "',cantidadHechizos = '" + cantidadHechizos + "'" + "'WHERE idConfiguracion = " + idConfiguracion.ToString();
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
