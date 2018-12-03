using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BJ_Cliente
{
    public partial class Instrucciones : Form
    {
        public Instrucciones()
        {
            InitializeComponent();
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            panelSalir.Parent = fondoInstrucciones;
            panelSalir.BackColor = Color.Transparent;
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile("..\\..\\Resources\\Comfortaa-Bold.ttf");
            txtInstrucciones.BackColor = Color.White;
            txtInstrucciones.Font = new Font(pfc.Families[0], 12, FontStyle.Bold);
            txtInstrucciones.Text =
                "En BlackJack, dentro de su turno cada jugador puede optar por pedir una carta aleatoria del mazo " +
                "para sumarla a sus puntos o plantarse y pasar el turno. " +
                "\r\n\r\nEl objetivo del juego es conseguir sumar 21 puntos o al menos conseguir, " +
                "sin pasarse, un valor más cercano a 21 que el otro jugador. \r\n\r\nLos valores de las " +
                "cartas en el BlackJack son los siguientes: \r\n las cartas del 2 al 10 valen su número, " +
                "las figuras valen 10 y el AS vale 1 o 10 dependiendo de lo que le convenga al jugador.\n\n" +
                "Al comenzar una partida por primera vez, se le etregarán al jugador $500. Luego de finalizar cada partida, " +
                "el ganador recibirá $100, los cuales serán quitados del perdedor. Si hay empate, los montos de cada jugador " +
                "no se modifican.";
        }

        private void panelSalir_Click(object sender, EventArgs e)
        {
            Close();
        }


        #region Para arrastrar la ventana
        bool drag;
        int mousex;
        int mousey;
        private void fondoInstrucciones_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mousex = Cursor.Position.X - Left;
            mousey = Cursor.Position.Y - Top;
        }
        private void fondoInstrucciones_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Left = Cursor.Position.X - mousex;
                Top = Cursor.Position.Y - mousey;
            }
        }

        private void fondoInstrucciones_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
        #endregion
    }
}
