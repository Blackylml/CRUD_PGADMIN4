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
    public partial class MatchMakingRankHistorial : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM MatchMakingRankHistorial";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "MatchMakingRankHistorial");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["MatchMakingRankHistorial"];

        }
        public MatchMakingRankHistorial()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void MatchMakingRankHistorial_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idMarchMakingRank = textBox1.Text;
            string idHistorial = textBox2.Text;



            consulta = "INSERT INTO MatchMakingRankHistorial (idMarchMakingRank,idHistorial) values " +
                "('" + idMarchMakingRank + "','" + idHistorial + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            textBox1.Clear();
            textBox2.Clear();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idMatchMakingRankHistorial = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE MatchMakingRankHistorial SET ESTATUS = 0 WHERE idMatchMakingRankHistorial =" + idMatchMakingRankHistorial.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idMarchMakingRank = textBox1.Text;
            string idHistorial = textBox2.Text;
            consulta = "UPDATE Idioma SET idMarchMakingRank = '" + idMarchMakingRank + "',idHistorial =  '" + idHistorial;
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            textBox1.Clear();
            textBox2.Clear();

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
            Menu regresar = new Menu();
            regresar.Show();
        }
    }
}
