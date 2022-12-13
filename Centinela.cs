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
    public partial class Centinela : Form
    {

        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Centinela";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Centinela");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Centinela"];

        }
        public Centinela()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            string precio = textBox2.Text;
            string tipo = textBox3.Text;
            string idCofre = textBox4.Text;
            string idTienda = textBox5.Text;


            consulta = "INSERT INTO Centinela (nombre,precio,tipo,idCofre,idTienda) values " +
                "('" + nombre + "','" + precio + "','" + tipo + "','" + idCofre + "','" + idTienda + "')";
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
            int idCentinela = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Centinela SET ESTATUS = 0 WHERE idCentinela =" + idCentinela.ToString();
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

        private void Centinela_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
    }
}
