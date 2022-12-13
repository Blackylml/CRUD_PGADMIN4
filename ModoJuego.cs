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
    public partial class ModoJuego : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM ModoJuego";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "ModoJuego");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["ModoJuego"];

        }
        public ModoJuego()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void ModoJuego_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            string descripcion = textBox2.Text;
            string tipoMapa = textBox3.Text;
            string fechaInicio = textBox4.Text;
            string fechaFinal = textBox5.Text;
            string idPartida = textBox6.Text;


            consulta = "INSERT INTO ModoJuego (mitico,bota,nombreObjeto1,nombreObjeto2,nombreObjeto3,nombreObjeto4,idTiendaJuego) values " +
                "('" + nombre + "','" + descripcion + "','" + tipoMapa + "','" + fechaInicio + "','" + fechaFinal + "','" + idPartida +
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
            int idModoJuego = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE ModoJuego SET ESTATUS = 0 WHERE idModoJuego =" + idModoJuego.ToString();
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
            string tipoMapa = textBox3.Text;
            string fechaInicio = textBox4.Text;
            string fechaFinal = textBox5.Text;
            string idPartida = textBox6.Text;
            consulta = "UPDATE Idioma SET nombre = '" + nombre + "',descripcion =  '" + descripcion + "',tipoMapa = '" +
                tipoMapa + "', fechaInicio = '" + fechaInicio + "', fechaFinal = '" + fechaFinal + "', idPartida = '" + idPartida;
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
