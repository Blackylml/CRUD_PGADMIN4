﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace CRUD_SQLME
{
    public partial class PartidaMatchMakingRank : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM PartidaMatchMakingRank";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "PartidaMatchMakingRank");
            conexion.Close();
            dataGridView1.DataSource = ds.Tables["PartidaMatchMakingRank"];

        }
        public PartidaMatchMakingRank()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=LeagueOfLegends;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void PartidaMatchMakingRank_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idPartida = textBox1.Text;
            string idMatchMakingRank = textBox2.Text;
            string MatchMakingRankRojo = textBox3.Text;
            string MatchMakingRankAzul = textBox4.Text;


            consulta = "INSERT INTO PartidaMatchMakingRank (idPartida,idMatchMakingRank,MatchMakingRankRojo,MatchMakingRankAzul) values " +
                "('" + idPartida + "','" + idMatchMakingRank + "','" + MatchMakingRankRojo + "','" + MatchMakingRankAzul + "')";
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
            int idPartidaMatchMakingRank = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE PartidaMatchMakingRank SET ESTATUS = 0 WHERE idPartidaMatchMakingRank =" + idPartidaMatchMakingRank.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idPartida = textBox1.Text;
            string idMatchMakingRank = textBox2.Text;
            string MatchMakingRankRojo = textBox3.Text;
            string MatchMakingRankAzul = textBox4.Text;
            consulta = "UPDATE Idioma SET idPartida = '" + idPartida + "',idMatchMakingRank =  '" + idMatchMakingRank + "',MatchMakingRankRojo = '" +
                MatchMakingRankRojo + "', MatchMakingRankAzul = '" + MatchMakingRankAzul;
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
