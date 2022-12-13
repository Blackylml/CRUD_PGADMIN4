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
    public partial class CampeonBuild : Form
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
        public CampeonBuild()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idBuild = textBox1.Text;
            string idCampeon = textBox2.Text;
            string buildRecomendada = textBox3.Text;

            consulta = "INSERT INTO CampeonBuild (idBuild,idCampeon,buildRecomendada) values " +
                "('" + idBuild + "','" + idCampeon + "','" + buildRecomendada  + "')";
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

        private void btnMostrar_Click(object sender, EventArgs e)
        {

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
            Menu regresar = new Menu();
            regresar.Show();
        }

        private void CampeonBuild_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
    }
}
