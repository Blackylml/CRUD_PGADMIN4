using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_SQLME
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void btnAmigo_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bolsa bolsa = new Bolsa();
            bolsa.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Botin botin = new Botin();
            botin.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Buff buff = new Buff();
            buff.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Build build = new Build();
            build.Show();
            Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BuildObjeto buildObjeto = new BuildObjeto();
            buildObjeto.Show();
            Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CampeonBuild campeonBuild = new CampeonBuild();
            campeonBuild.Show();
            Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            CampeonObjeto campeonObjeto = new CampeonObjeto();
            campeonObjeto.Show();
            Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Centinela centinela = new Centinela();
            centinela.Show();
            Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Chroma chroma = new Chroma();
            chroma.Show();
            Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Clash clash = new Clash();
            clash.Show();
            Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Cofre cofre = new Cofre();
            cofre.Show();
            Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Configuracion configuracion = new Configuracion();
            configuracion.Show();
            Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Desafio desafio = new Desafio();
            desafio.Show();
            Hide();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Dragon dragon = new Dragon();
            dragon.Show();
            Hide();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Equipo equipo = new Equipo();
            equipo.Show();
            Hide();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            EquipoTorneo equipoTorneo = new EquipoTorneo();
            equipoTorneo.Show();
            Hide();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Estadistica estadistica = new Estadistica();
            estadistica.Show();
            Hide();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Eterno eterno = new Eterno();
            eterno.Show();
            Hide();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Gesto geste = new Gesto();
            geste.Show();
            Hide ();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Habilidad habilidad = new Habilidad();
            habilidad.Show();
            Hide();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Hechizo hechizo = new Hechizo();
            hechizo.Show();
            Hide();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Historial historial = new Historial();
            historial.Show();
            Hide();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            inhibidor inhibidoor = new inhibidor();
            inhibidoor.Show();
            Hide();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Jugador jugador = new Jugador();
            jugador.Show();
            Hide();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Maestria maestria = new Maestria();
            maestria.Show();
            Hide();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Mapa mapa = new Mapa();
            mapa.Show();
            Hide();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            MatchMakingRank matchMakingRank = new MatchMakingRank();
            matchMakingRank.Show();
            Hide();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            MatchMakingRankHistorial matchMakingRankHistorial = new MatchMakingRankHistorial();
            matchMakingRankHistorial.Show();
            Hide();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            MatchMakingRankUsuario matchMakingRankUsuari = new MatchMakingRankUsuario();
            matchMakingRankUsuari.Show();
            Hide();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            Mision mision = new Mision();
            mision.Show();
            Hide();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            ModoJuego mision = new ModoJuego();
            mision.Show();
            Hide();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            MounstroKG mision = new MounstroKG();
            mision.Show();
            Hide();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            MounstroVacio mision = new MounstroVacio();
            mision.Show();
            Hide();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            Musica mision = new Musica();
            mision.Show();
            Hide();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            Objeto mision = new Objeto();
            mision.Show();
            Hide();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            Partida mision = new Partida();
            mision.Show();
            Hide();
        }

        private void button40_Click(object sender, EventArgs e)
        {
            PartidaMatchMakingRank mision = new PartidaMatchMakingRank();
            mision.Show();
            Hide();
        }

        private void button41_Click(object sender, EventArgs e)
        {
            PaseBatalla mision = new PaseBatalla();
            mision.Show();
            Hide();
        }

        private void button43_Click(object sender, EventArgs e)
        {
            RangoSeason mision = new RangoSeason();
            mision.Show();
            Hide();
        }

        private void button44_Click(object sender, EventArgs e)
        {
            Regalo mision = new Regalo();
            mision.Show();
            Hide();
        }
        private void button45_Click(object sender, EventArgs e)
        {
            Region mision = new Region();
            mision.Show();
            Hide();
        }
        private void button46_Click(object sender, EventArgs e)
        {
            Rol mision = new Rol();
            mision.Show();
            Hide();
        }

  
    }
}
