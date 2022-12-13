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
    public partial class Regalo : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Regalo";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Regalo");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Regalo"];

        }
        public Regalo()
        {
      
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void Regalo_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string destinatario = textBox1.Text;
            string remitente = textBox2.Text;
            string contenido = textBox3.Text;
            string nota = textBox4.Text;
            string idUsuario = textBox5.Text;
            string idAmigo = textBox6.Text;


            consulta = "INSERT INTO Regalo (destinatario,remitente,contenido,nota,idUsuario,idAmigo) values " +
                "('" + destinatario + "','" + remitente + "','" + contenido + "','" + nota + "','" + idUsuario + "','" + idAmigo  + "')";
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
            int idRegalo = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Regalo SET ESTATUS = 0 WHERE idRegalo =" + idRegalo.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string destinatario = textBox1.Text;
            string remitente = textBox2.Text;
            string contenido = textBox3.Text;
            string nota = textBox4.Text;
            string idUsuario = textBox5.Text;
            string idAmigo = textBox6.Text;
            consulta = "UPDATE Regalo SET destinatario = '" + destinatario + "',remitente =  '" + remitente + "',contenido = '" +
                contenido + "', nota = '" + nota + "', idUsuario = '" + idUsuario + "', idAmigo = '" + idAmigo;
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
