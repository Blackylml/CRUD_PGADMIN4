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
    public partial class Region : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Region";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Region");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["Region"];

        }
        public Region()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void Region_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            string cantidadEquipos = textBox2.Text;
            string paises = textBox3.Text;
            string idWorlds = textBox4.Text;



            consulta = "INSERT INTO Region (nombre,cantidadEquipos,paises,idWorlds) values " +
                "('" + nombre + "','" + cantidadEquipos + "','" + paises + "','" + idWorlds + "')";
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
            int idRegion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Region SET ESTATUS = 0 WHERE idRegion =" + idRegion.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            string cantidadEquipos = textBox2.Text;
            string paises = textBox3.Text;
            string idWorlds = textBox4.Text;
            consulta = "UPDATE Region SET nombre = '" + nombre + "',cantidadEquipos =  '" + cantidadEquipos + "',paises = '" +
                paises + "', idWorlds = '" + idWorlds;
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
