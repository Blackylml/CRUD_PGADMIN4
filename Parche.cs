using System;
using System.Collections.Generic;
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
    public partial class Parche : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Parche";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Parche");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Parche"];

        }
        public Parche()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void Parche_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string numero = textBox1.Text;
            string tipo = textBox2.Text;
            string descripcion = textBox3.Text;
            string idSeason = textBox4.Text;



            consulta = "INSERT INTO Parche (numero,tipo,descripcion,idSeason) values " +
                "('" + numero + "','" + tipo + "','" + descripcion + "','" + idSeason +"')";
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
            int idParche = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Parche SET ESTATUS = 0 WHERE idParche =" + idParche.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string numero = textBox1.Text;
            string tipo = textBox2.Text;
            string descripcion = textBox3.Text;
            string idSeason = textBox4.Text;
            consulta = "UPDATE Idioma SET numero = '" + numero + "',tipo =  '" + tipo + "',descripcion = '" +
                descripcion + "', idSeason = '" + idSeason;
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
