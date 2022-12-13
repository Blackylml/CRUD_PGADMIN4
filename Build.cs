using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace CRUD_SQLME
{
    public partial class Build : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Build";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Build");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Build"];

        }
        public Build()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void Build_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string mitico = textBox1.Text;
            string bota = textBox2.Text;
            string nombreObjeto1 = textBox3.Text;
            string nombreObjeto2 = textBox4.Text;
            string nombreObjeto3 = textBox5.Text;
            string nombreObjeto4 = textBox6.Text;
            string idTiendaJuego = textBox7.Text;


            consulta = "INSERT INTO Build (mitico,bota,nombreObjeto1,nombreObjeto2,nombreObjeto3,nombreObjeto4,idTiendaJuego) values " +
                "('" + mitico + "','" + bota + "','" + nombreObjeto1 + "','" + nombreObjeto2 + "','" + nombreObjeto3 + "','" +nombreObjeto4+
                "','" +idTiendaJuego + "')";
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
            int idBuild = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Build SET ESTATUS = 0 WHERE idBuild =" + idBuild.ToString();
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
            consulta = "UPDATE Build SET cantidadCampeones = '" + cantidadCampeones + "',cantidadGestos =  '" + cantidadGestos + "',cantidadHechizos = '" +
                cantidadHechizos + "', cantidadCentinelas = '" + cantidadCentinelas  ;
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
