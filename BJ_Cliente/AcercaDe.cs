using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BJ_Cliente
{
    public partial class AcercaDe : Form
    {
        public AcercaDe()
        {
            InitializeComponent();
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            panelSalir.Parent = fondoAcercaDe;
            panelSalir.BackColor = Color.Transparent;
        }

        private void panelSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Para arrastrar la ventana
        bool drag;
        int mousex;
        int mousey;
        private void fondoLogin_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mousex = Cursor.Position.X - Left;
            mousey = Cursor.Position.Y - Top;
        }

        private void fondoLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Left = Cursor.Position.X - mousex;
                Top = Cursor.Position.Y - mousey;
            }
        }

        private void fondoLogin_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
        #endregion
    }
}
