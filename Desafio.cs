using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace CRUD_SQLME
{
    public partial class Desafio : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Desafio";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Desafio");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Desafio"];

        }
        public Desafio()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void Desafio_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            string descripcion = textBox2.Text;
            string rango = textBox3.Text;
            string porcentaje = textBox4.Text;
            string rama = textBox5.Text;
            string idUsuario = textBox6.Text;

            consulta = "INSERT INTO Desafio (nombre,descripcion,rango,porcentaje,rama,idUsuario) values " +
                "('" + nombre + "','" + descripcion + "','" + rango + "','" + porcentaje + "','" + rama + "','" + idUsuario +
                "')";
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
            int idDesafio = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Desafio SET ESTATUS = 0 WHERE idDesafio =" + idDesafio.ToString();
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

        }
    }
}
