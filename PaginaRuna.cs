using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace CRUD_SQLME
{
    public partial class PaginaRuna : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM PaginaRuna";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "PaginaRuna");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["PaginaRuna"];

        }
        public PaginaRuna()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void PaginaRuna_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string principal = textBox1.Text;
            string secundaria = textBox2.Text;
            string adaptables = textBox3.Text;
            string nombre = textBox4.Text;
            string idUsuario = textBox3.Text;
            string idRunas = textBox4.Text;


            consulta = "INSERT INTO PaginaRuna (principal,secundaria,adaptables,nombre,idUsuario,idRunas) values " +
                "('" + principal + "','" + secundaria + "','" + adaptables + "','" + nombre + "','" + idUsuario + "','" + idRunas + "')";
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
            int idPaginaRuna = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE PaginaRuna SET ESTATUS = 0 WHERE idPaginaRuna =" + idPaginaRuna.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string principal = textBox1.Text;
            string secundaria = textBox2.Text;
            string adaptables = textBox3.Text;
            string nombre = textBox4.Text;
            string idUsuario = textBox3.Text;
            string idRunas = textBox4.Text;

            consulta = "UPDATE Idioma SET principal = '" + principal + "',secundaria =  '" + secundaria + "',adaptables = '" +
                adaptables + "', nombre = '" + nombre + "', idUsuario = '" + idUsuario + "', idRunas = '" + idRunas;
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
