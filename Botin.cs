using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace CRUD_SQLME
{
    public partial class Botin : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Botin";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Botin");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Botin"];

        }
        public Botin()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void Botin_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombreMaterial = textBox1.Text;
            string descripcionMaterial = textBox2.Text;
            string recompensaMaterial = textBox3.Text;
            string precio = textBox4.Text;

            consulta = "INSERT INTO Botin (nombreMaterial,descripcionMaterial,recompensaMaterial,precio) values " +
                "('" + nombreMaterial + "','" + descripcionMaterial + "','" + recompensaMaterial + "','" + precio + "')";
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
            int idBotin = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Botin SET ESTATUS = 0 WHERE idBotin =" + idBotin.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string nombreMaterial = textBox1.Text;
            string descripcionMaterial = textBox2.Text;
            string recompensaMaterial = textBox3.Text;
            string precio = textBox4.Text;
            int idBotin = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE Botin SET nombreMaterial ='" + nombreMaterial + "','" + "',descripcionMaterial = '" + descripcionMaterial +
                "',recompensaMaterial = '" + recompensaMaterial + "',preico = '" + precio + "'" + "'WHERE idBotin = " + idBotin.ToString();
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
