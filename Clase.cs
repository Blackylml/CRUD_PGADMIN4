using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace CRUD_SQLME
{
    public partial class Clase : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Campeon";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Campeon");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Campeon"];

        }
        public Clase()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void Clase_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            string habilidadQ = textBox2.Text;
            string habilidadW = textBox3.Text;
            string habilidadE = textBox4.Text;
            string habilidadR = textBox3.Text;
            string rol = textBox4.Text;
            string posicion = textBox5.Text;
            string idMaestria = textBox6.Text;
            string idCofre = textBox7.Text;
            string idEterno = textBox8.Text;

            consulta = "INSERT INTO Campeon (nombre,habilidadQ,habilidadW,habilidadE,habilidadR,rol,posicion,idMaestria,idCofre,idEterno) values " +
                "('" + nombre + "','" + habilidadQ + "','" + habilidadW + "','" + habilidadE + "','" + habilidadR + "','" + rol +
                "','" + posicion + "','"+idMaestria+"'.'"+idCofre+"','"+idEterno+"')";
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
            textBox7.Clear();
            textBox8.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idCampeon = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Campeon SET ESTATUS = 0 WHERE idCampeon =" + idCampeon.ToString();
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
