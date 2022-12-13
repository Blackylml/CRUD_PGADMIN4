using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace CRUD_SQLME
{
    public partial class Objeto : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM objeto";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "objeto");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["objeto"];

        }
        public Objeto()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void Objeto_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            string descripcion = textBox2.Text;
            string beneficios = textBox3.Text;
            string precio = textBox4.Text;
            string rareza = textBox3.Text;
            string idTiendaJuego = textBox5.Text;


            consulta = "INSERT INTO objeto (nombre,descripcion,beneficios,precio,rareza,idTiendaJuego) values " +
                "('" + nombre + "','" + descripcion + "','" + beneficios + "','" + precio + "','" + rareza + "','" + idTiendaJuego +"')";
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
            int idobjeto = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE objeto SET ESTATUS = 0 WHERE idobjeto =" + idobjeto.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            string descripcion = textBox2.Text;
            string beneficios = textBox3.Text;
            string precio = textBox4.Text;
            string rareza = textBox3.Text;
            string idTiendaJuego = textBox5.Text;
            consulta = "UPDATE Idioma SET nombre = '" + nombre + "',descripcion =  '" + descripcion + "',beneficios = '" +
                beneficios + "', precio = '" + precio + "', rareza = '" + rareza + "', idTiendaJuego = '" + idTiendaJuego;
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
