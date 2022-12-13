using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace CRUD_SQLME
{
    public partial class MounstroKG : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM MounstrosJg";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "MounstrosJg");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["MounstrosJg"];

        }
        public MounstroKG()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void MounstroKG_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            string nombre = textBox1.Text;
            string cantidad = textBox2.Text;
            string oroEntregado = textBox3.Text;
            string daño = textBox4.Text;
            string idPartida = textBox5.Text;



            consulta = "INSERT INTO MounstrosJg (nombre,cantidad,oroEntregado,daño,idPartida) values " +
                "('" + nombre + "','" + cantidad + "','" + oroEntregado + "','" + daño + "','" + idPartida + "')";
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
            int idMounstrosJg = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE MounstrosJg SET ESTATUS = 0 WHERE idMounstrosJg =" + idMounstrosJg.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            string cantidad = textBox2.Text;
            string oroEntregado = textBox3.Text;
            string daño = textBox4.Text;
            string idPartida = textBox5.Text;
            consulta = "UPDATE Idioma SET nombre = '" + nombre + "',cantidad =  '" + cantidad + "',oroEntregado = '" +
                oroEntregado + "', daño = '" + daño + "', idPartida = '" + idPartida;
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
