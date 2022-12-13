using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace CRUD_SQLME
{
    public partial class Form1 : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Amigo";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Amigo");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Amigo"];

        }
        public Form1()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            string apodo = textBox2.Text;
            string tipo = textBox3.Text;

            consulta = "INSERT INTO Amigo (nombre,apodo,tipo) values ('" + nombre + "','" + apodo + "','" + tipo + "')";
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
            int idAmigo = (int) dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Amigo SET ESTATUS = 0 WHERE idAmigo =" + idAmigo.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            string apodo = textBox2.Text;
            string tipo = textBox3.Text;
            int idAmigo = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE Amigo SET nombre ='" + nombre + "','" + apodo + "','" + tipo + "' WHERE idAmigo = " + idAmigo.ToString();
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
            
            Menu regresar = new Menu();
            regresar.Show();

        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            consulta = "SELECT * FROM Amigo";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Amigo");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Amigo"];
        }
    }

}