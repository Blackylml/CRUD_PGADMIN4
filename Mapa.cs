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
    public partial class Mapa : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Mapa";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Mapa");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Mapa"];

        }
        public Mapa()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void Mapa_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            string tamaño = textBox2.Text;
            string numeroCarriles = textBox3.Text;


            consulta = "INSERT INTO Mapa (nombre,tamaño,numeroCarriles) values " +
                "('" + nombre + "','" + tamaño + "','" + numeroCarriles + "')";
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
            int idMapa = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Mapa SET ESTATUS = 0 WHERE idMapa =" + idMapa.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            string tamaño = textBox2.Text;
            string numeroCarriles = textBox3.Text;
            consulta = "UPDATE Idioma SET nombre = '" + nombre + "',tamaño =  '" + tamaño + "',numeroCarriles = '" +
                numeroCarriles ;
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
