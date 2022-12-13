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
    public partial class inhibidor : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM inhibidor";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "inhibidor");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["inhibidor"];

        }
        public inhibidor()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nivel = textBox1.Text;
            string vida = textBox2.Text;
            string tiempo = textBox3.Text;
            string idPartida = textBox4.Text;



            consulta = "INSERT INTO inhibidor (nivel,vida,tiempo,idPartida) values " +
                "('" + nivel + "','" + vida + "','" + tiempo + "','" + idPartida +  "')";
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

        private void inhibidor_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idinhibidor = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE inhibidor SET ESTATUS = 0 WHERE idinhibidor =" + idinhibidor.ToString();
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
            int idinhibidor = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE inhibidor SET cantidadCampeones ='" + cantidadCampeones + "','" + "',cantidadGestos = '" + cantidadGestos +
                "',cantidadHechizos = '" + cantidadHechizos + "',cantidadHechizos = '" + cantidadHechizos + "'" + "'WHERE idinhibidor = " + idinhibidor.ToString();
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
