using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace CRUD_SQLME
{
    public partial class BuildObjeto : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM BuildObjeto";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "BuildObjeto");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["BuildObjeto"];

        }
        public BuildObjeto()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void BuildObjeto_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string mitico = textBox1.Text;
            string bota = textBox2.Text;
            string nombreObjeto1 = textBox3.Text;
            string nombreObjeto2 = textBox4.Text;
            string nombreObjeto3 = textBox3.Text;
            string nombreObjeto4 = textBox4.Text;
            string idTiendaJuego = textBox5.Text;

            consulta = "INSERT INTO BuildObjeto (mitico,bota,nombreObjeto1,nombreObjeto2,nombreObjeto3,nombreObjeto4,idTiendaJuego) values " +
                "('" + mitico + "','" + bota + "','" + nombreObjeto1 + "','" + nombreObjeto2 + "','" + nombreObjeto3 + "','" + nombreObjeto4 +
                "','" + idTiendaJuego + "')";
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
            int idBuildObjeto  = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE BuildObjeto SET ESTATUS = 0 WHERE idBuildObjeto =" + idBuildObjeto.ToString();
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
            int idBuildObjeto = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE BuildObjeto SET cantidadCampeones ='" + cantidadCampeones + "','" + "',cantidadGestos = '" + cantidadGestos +
                "',cantidadHechizos = '" + cantidadHechizos + "',cantidadHechizos = '" + cantidadHechizos + "'" + "'WHERE idBuildObjeto = " + idBuildObjeto.ToString();
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
