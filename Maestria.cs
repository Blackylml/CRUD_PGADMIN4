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
    public partial class Maestria : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Maestria";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Maestria");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Maestria"];

        }
        public Maestria()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void Maestria_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nivel = textBox1.Text;
            string puntos = textBox2.Text;
            string idUsuario = textBox3.Text;


            consulta = "INSERT INTO Maestria (nivel,puntos,idUsuario) values " +
                "('" + nivel + "','" + puntos + "','" + idUsuario + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idMaestria = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Maestria SET ESTATUS = 0 WHERE idMaestria =" + idMaestria.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string nivel = textBox1.Text;
            string puntos = textBox2.Text;
            string idUsuario = textBox3.Text;
            consulta = "  UPDATE Maestria SET nivel ='" + nivel + "','" + "',puntos = '" + puntos +
                "',idUsuario = '" + idUsuario  + "'" + "'WHERE idUsuario = " + idUsuario.ToString();
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
