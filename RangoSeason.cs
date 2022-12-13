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
    public partial class RangoSeason : Form
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
        public RangoSeason()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void RangoSeason_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idRango = textBox1.Text;
            string idSeason = textBox2.Text;
            string rangoSoloq = textBox3.Text;
            string rangoFlex = textBox4.Text;



            consulta = "INSERT INTO Build (idRango,idSeason,rangoSoloq,rangoFlex) values " +
                "('" + idRango + "','" + idSeason + "','" + rangoSoloq + "','" + rangoFlex +  "')";
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
            string idRango = textBox1.Text;
            string idSeason = textBox2.Text;
            string rangoSoloq = textBox3.Text;
            string rangoFlex = textBox4.Text;
            consulta = "UPDATE Idioma SET idRango = '" + idRango + "',idSeason =  '" + idSeason + "',rangoSoloq = '" +
                rangoSoloq + "', rangoFlex = '" + rangoFlex;
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
