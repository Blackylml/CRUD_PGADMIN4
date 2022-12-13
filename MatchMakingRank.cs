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
    public partial class MatchMakingRank : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM MatchMakingRank";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "MatchMakingRank");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["MatchMakingRank"];

        }
        public MatchMakingRank()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void MatchMakingRank_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string puntosLiga = textBox1.Text;
            string tipo = textBox2.Text;



            consulta = "INSERT INTO MatchMakingRank (puntosLiga,tipo) values " +
                "('" + puntosLiga + "','" + tipo +  "')";
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
            int idMatchMakingRank = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE MatchMakingRank SET ESTATUS = 0 WHERE idMatchMakingRank =" + idMatchMakingRank.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string puntosLiga = textBox1.Text;
            string tipo = textBox2.Text;

            consulta = "UPDATE Idioma SET puntosLiga = '" + puntosLiga + "',puntosLiga =  '" + tipo + "',tipo = '" +
                tipo;
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
