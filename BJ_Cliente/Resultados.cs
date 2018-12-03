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
    public partial class Resultados : Form
    {
        public Resultados(string j1, string j2, string p1, string p2, string res)
        {
            InitializeComponent();
            panelSalir.Parent = fondoResultados;
            panelSalir.BackColor = Color.Transparent;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            #region Seteo las fuentes privadas
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile("..\\..\\Resources\\Comfortaa-Bold.ttf");
            lblJugador1.Font = new Font(pfc.Families[0], 14, FontStyle.Bold);
            lblJugador2.Font = new Font(pfc.Families[0], 14, FontStyle.Bold);
            lblPuntos1.Font = new Font(pfc.Families[0], 14, FontStyle.Bold);
            lblPuntos2.Font = new Font(pfc.Families[0], 14, FontStyle.Bold);
            lblResultado.Font = new Font(pfc.Families[0], 22, FontStyle.Bold);
            #endregion
            lblJugador1.Text = j1;
            lblJugador2.Text = j2;
            lblPuntos1.Text = p1;
            lblPuntos2.Text = p2;
            lblResultado.Text = res;
        }

        

        private void panelSalir_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void Resultados_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }


        bool drag;
        int mousex;
        int mousey;
        private void fondoResultados_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mousex = Cursor.Position.X - Left;
            mousey = Cursor.Position.Y - Top;
        }

        private void fondoResultados_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Left = Cursor.Position.X - mousex;
                Top = Cursor.Position.Y - mousey;
            }
        }

        private void fondoResultados_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
    }
}
