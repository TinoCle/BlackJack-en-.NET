using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack
{
    public partial class Form1 : Form
    {
        Mazo mazo;
        public Form1()
        {
            InitializeComponent();
            mazo = new Mazo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Carta carta = mazo.SacarCarta();
            if (carta != null)
            {
                textBox1.Text = carta.Nombre;
            }
            else
            {
                textBox1.Text = "Mazo vacío.";
            }
        }
    }
}
