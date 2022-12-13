using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace CRUD_SQLME
{
    public partial class Clash : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Clash";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Clash");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Clash"];

        }
        public Clash()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void Clash_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string fechaInicio = textBox1.Text;
            string fechaFinal = textBox2.Text;
            string nombre = textBox3.Text;
            string premio = textBox4.Text;
            string participantes = textBox5.Text;
            string idUsuario = textBox6.Text;


            consulta = "INSERT INTO Clash (fechaInicio,fechaFinal,nombre,premio,participantes,idUsuario) values " +
                "('" + fechaInicio + "','" + fechaFinal + "','" + nombre + "','" + premio + "','" + participantes + "','" + idUsuario +
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
            textBox6.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idClash = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Clash SET ESTATUS = 0 WHERE idClash =" + idClash.ToString();
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
