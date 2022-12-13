using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace CRUD_SQLME
{
    public partial class Cofre : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Cofre";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Cofre");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Cofre"];

        }
        public Cofre()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Cofre_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string objetoEspecial = textBox1.Text;
            string objetoNormal = textBox2.Text;
            string tipo = textBox3.Text;
            string precio = textBox4.Text;
            string idBotin = textBox5.Text;
            string idBolsa = textBox6.Text;

            consulta = "INSERT INTO Cofre (objetoEspecial,objetoNormal,tipo,precio,idBotin,idBolsa) values " +
                "('" + objetoEspecial + "','" + objetoNormal + "','" + tipo + "','" + precio + "','" + idBotin + "','" + idBolsa +
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
            int idCofre = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Cofre SET ESTATUS = 0 WHERE idCofre =" + idCofre.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string cantidadCampeones = textBox1.Text;
            string cantidadGestos = textBox2.Text;
            string cantidadHechizos = textBox3.Text;
            string cantidadCentinelas = textBox4.Text;
            int idCofre = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE Cofre SET cantidadCampeones ='" + cantidadCampeones + "','" + "',cantidadGestos = '" + cantidadGestos +
                "',cantidadHechizos = '" + cantidadHechizos + "',cantidadHechizos = '" + cantidadHechizos + "'" + "'WHERE idCofre = " + idCofre.ToString();
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
