using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace CRUD_SQLME
{
    public partial class PaseBatalla : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM PaseBatalla";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "PaseBatalla");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["PaseBatalla"];

        }
        public PaseBatalla()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void PaseBatalla_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            string recompensa = textBox2.Text;
            string cantidadNiveles = textBox3.Text;
            string fechaInicio = textBox4.Text;
            string fechaFinal = textBox5.Text;
            string precio = textBox6.Text;
            string idUsuario = textBox7.Text;
            string idSeason = textBox8.Text;


            consulta = "INSERT INTO PaseBatalla (nombre,recompensa,cantidadNiveles,fechaInicio,fechaFinal,precio,idUsuario,idSeason) values " +
                "('" + nombre + "','" + recompensa + "','" + cantidadNiveles + "','" + fechaInicio + "','" + fechaFinal + "','" + precio +
                "','" + idUsuario + "','" + idSeason + "')";
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
            int idPaseBatalla = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE PaseBatalla SET ESTATUS = 0 WHERE idPaseBatalla =" + idPaseBatalla.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            string recompensa = textBox2.Text;
            string cantidadNiveles = textBox3.Text;
            string fechaInicio = textBox4.Text;
            string fechaFinal = textBox5.Text;
            string precio = textBox6.Text;
            string idUsuario = textBox7.Text;
            string idSeason = textBox8.Text;
            consulta = "UPDATE Idioma SET nombre = '" + nombre + "',recompensa =  '" + recompensa + "',cantidadNiveles = '" +
                cantidadNiveles + "', fechaInicio = '" + fechaInicio + "', fechaFinal = '" + fechaFinal + "', precio = '" + precio
                 + "', idUsuario = '" + idUsuario + "', idSeason = '" + idSeason;
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
