using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace CRUD_SQLME
{
    public partial class Musica : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Musica";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Musica");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Musica"];

        }
        public Musica()
        {
            InitializeComponent();
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void Musica_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            string duracion = textBox2.Text;
            string album = textBox3.Text;
            string idPartida = textBox4.Text;
            string idWorlds = textBox3.Text;



            consulta = "INSERT INTO Musica (nombre,duracion,album,idPartida,idWorlds) values " +
                "('" + nombre + "','" + duracion + "','" + album + "','" + idPartida + "','" + idWorlds +  "')";
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
            int idMusica = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Musica SET ESTATUS = 0 WHERE idMusica =" + idMusica.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            string duracion = textBox2.Text;
            string album = textBox3.Text;
            string idPartida = textBox4.Text;
            string idWorlds = textBox3.Text;
            consulta = "UPDATE Idioma SET nombre = '" + nombre + "',duracion =  '" + duracion + "',album = '" +
                album + "', idPartida = '" + idPartida + "', idWorlds = '" + idWorlds;
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
