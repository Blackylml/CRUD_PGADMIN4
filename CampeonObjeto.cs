using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace CRUD_SQLME
{
    public partial class CampeonObjeto : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM CampeonBuild";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "CampeonBuild");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["CampeonBuild"];

        }
        public CampeonObjeto()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void CampeonObjeto_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idObjeto = textBox1.Text;
            string idCampeon = textBox2.Text;
            string objeto1 = textBox3.Text;
            string objeto2 = textBox4.Text;
            string objeto3 = textBox3.Text;
            string objeto4 = textBox4.Text;
            string mitico = textBox5.Text;
            string botas = textBox5.Text;

            consulta = "INSERT INTO CampeonObjeto (idObjeto,idCampeon,objeto1,objeto2,objeto3,objeto4,mitico,botas) values " +
                "('" + idObjeto + "','" + idCampeon + "','" + objeto1 + "','" + objeto2 + "','" + objeto3 + "','" + objeto4 +
                "','" + mitico + "','" + botas + "')";
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
            int idCampeonBuild = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE CampeonBuild SET ESTATUS = 0 WHERE idCampeonBuild =" + idCampeonBuild.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
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
