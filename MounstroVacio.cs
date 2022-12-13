using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace CRUD_SQLME
{
    public partial class MounstroVacio : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM MounstroVacio";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "MounstroVacio");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["MounstroVacio"];

        }
        public MounstroVacio()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void MounstroVacio_Load(object sender, EventArgs e)
        {

            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string tipo = textBox1.Text;
            string efecto = textBox2.Text;
            string beneficio = textBox3.Text;
            string duracionBeneficio = textBox4.Text;
            string idMounstrosJG = textBox5.Text;


            consulta = "INSERT INTO MounstroVacio (tipo,efecto,beneficio,duracionBeneficio,idMounstrosJG) values " +
                "('" + tipo + "','" + efecto + "','" + beneficio + "','" + duracionBeneficio + "','" + idMounstrosJG + "','" +  "')";
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
            int idMounstroVacio = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE MounstroVacio SET ESTATUS = 0 WHERE idMounstroVacio =" + idMounstroVacio.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string tipo = textBox1.Text;
            string efecto = textBox2.Text;
            string beneficio = textBox3.Text;
            string duracionBeneficio = textBox4.Text;
            string idMounstrosJG = textBox5.Text;
            consulta = "UPDATE Idioma SET tipo = '" + tipo + "',efecto =  '" + efecto + "',beneficio = '" +
                beneficio + "', duracionBeneficio = '" + duracionBeneficio + "', idMounstrosJG = '" + idMounstrosJG;
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
