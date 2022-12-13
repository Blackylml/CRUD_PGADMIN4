using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace CRUD_SQLME
{
    public partial class Mision : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Mision";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Mision");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Mision"];

        }
        public Mision()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void Mision_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string fechaInicio = textBox1.Text;
            string fechaFinal = textBox2.Text;
            string descripcion = textBox3.Text;
            string recompensa = textBox4.Text;
            string idUsuario = textBox5.Text;
            string idPaseBatalla = textBox6.Text;



            consulta = "INSERT INTO Mision (fechaInicio,fechaFinal,descripcion,recompensa,idUsuario,idPaseBatalla) values " +
                "('" + fechaInicio + "','" + fechaFinal + "','" + descripcion + "','" + recompensa + "','" + idUsuario + "','" + idPaseBatalla + "')";
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
            int idMision = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Mision SET ESTATUS = 0 WHERE idMision =" + idMision.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string fechaInicio = textBox1.Text;
            string fechaFinal = textBox2.Text;
            string descripcion = textBox3.Text;
            string recompensa = textBox4.Text;
            string idUsuario = textBox5.Text;
            string idPaseBatalla = textBox6.Text;
            consulta = "UPDATE Idioma SET fechaInicio = '" + fechaInicio + "',fechaFinal =  '" + fechaFinal + "',descripcion = '" +
                descripcion + "', recompensa = '" + recompensa;
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
