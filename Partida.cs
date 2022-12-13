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
    public partial class Partida : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Partida";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Partida");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Partida"];

        }
        public Partida()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void Partida_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string fecha = textBox1.Text;
            string duracion = textBox2.Text;
            string tipo = textBox3.Text;
            string idMapa = textBox4.Text;



            consulta = "INSERT INTO Partida (fecha,duracion,tipo,idMapa) values " +
                "('" + fecha + "','" + duracion + "','" + tipo + "','" + idMapa +  "')";
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
            int idPartida = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Partida SET ESTATUS = 0 WHERE idPartida =" + idPartida.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string fecha = textBox1.Text;
            string duracion = textBox2.Text;
            string tipo = textBox3.Text;
            string idMapa = textBox4.Text; ;
            consulta = "UPDATE Idioma SET fecha = '" + fecha + "',duracion =  '" + duracion + "',tipo = '" +
                tipo + "', idMapa = '" + idMapa;
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
