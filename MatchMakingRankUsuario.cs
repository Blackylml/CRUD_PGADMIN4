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
    public partial class MatchMakingRankUsuario : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM MatchMakingRankUsuario";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "MatchMakingRankUsuario");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["MatchMakingRankUsuario"];

        }
        public MatchMakingRankUsuario()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void MatchMakingRankUsuario_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idMatchMakingRankingUsuario = textBox1.Text;
            string idUsuario = textBox2.Text;



            consulta = "INSERT INTO MatchMakingRankUsuario (idMatchMakingRankingUsuario,,idUsuario) values " +
                "('" + idMatchMakingRankingUsuario + "','" + idUsuario +  "')";
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
            int idMatchMakingRankUsuario = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE MatchMakingRankUsuario SET ESTATUS = 0 WHERE idMatchMakingRankUsuario =" + idMatchMakingRankUsuario.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idMatchMakingRankingUsuario = textBox1.Text;
            string idUsuario = textBox2.Text;

            consulta = "UPDATE Idioma SET idMatchMakingRankingUsuario = '" + idMatchMakingRankingUsuario + "',idUsuario =  '" + idUsuario;
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
