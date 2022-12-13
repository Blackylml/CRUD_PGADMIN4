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
    public partial class Rol : Form
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
        public Rol()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void Rol_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string rolPrincipal = textBox1.Text;
            string rolSecundario = textBox2.Text;
            string idJugador = textBox3.Text;
 


            consulta = "INSERT INTO Build (rolPrincipal,rolSecundario,idJugador) values " +
                "('" + rolPrincipal + "','" + rolSecundario + "','" + idJugador + "')";
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
            string rolPrincipal = textBox1.Text;
            string rolSecundario = textBox2.Text;
            string idJugador = textBox3.Text;
            consulta = "UPDATE Build SET rolPrincipal = '" + rolPrincipal + "',rolSecundario =  '" + rolSecundario + "',idJugador = '" +
                idJugador;
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
