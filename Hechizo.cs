using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CRUD_SQLME
{
    public partial class Hechizo : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Hechizo";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Hechizo");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Hechizo"];

        }
        public Hechizo()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            string efecto = textBox2.Text;
            string endriamiento = textBox3.Text;
            string idUsuario = textBox4.Text;



            consulta = "INSERT INTO Hechizo (nombre,efecto,endriamiento,idUsuario) values " +
                "('" + nombre + "','" + efecto + "','" + endriamiento + "','" + idUsuario +  "')";
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
            int idHechizo = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Hechizo SET ESTATUS = 0 WHERE idHechizo =" + idHechizo.ToString();
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
            int idHechizo = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE Hechizo SET cantidadCampeones ='" + cantidadCampeones + "','" + "',cantidadGestos = '" + cantidadGestos +
                "',cantidadHechizos = '" + cantidadHechizos + "',cantidadHechizos = '" + cantidadHechizos + "'" + "'WHERE idHechizo = " + idHechizo.ToString();
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

        private void Hechizo_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
    }
}
