using Proyecto_Simulacion_Cocina.Entitdades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Simulacion_Cocina
{
    public partial class Simulador : Form
    {
        int i = 0;
        public Simulador()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Timer.Enabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Ejecucion();
        }
        private void Ejecucion()
        {
            if(i > 0 && i < 5)
            {
                Perilla1pictureBox.Visible = true;
            }


            if(i > 5 && i < 10)
            {

                Perilla1pictureBox.Visible = false;
                Perilla3pictureBox.Visible = false;
                Perilla4pictureBox.Visible = false;
                Perilla5pictureBox.Visible = false;
                Perilla6pictureBox.Visible = false;
                Perilla7pictureBox.Visible = false;
                Perilla2pictureBox.Visible = true;

            }

            if (i > 10 && i < 15)
            {
                Perilla1pictureBox.Visible = false;
                Perilla2pictureBox.Visible = false;
                Perilla4pictureBox.Visible = false;
                Perilla5pictureBox.Visible = false;
                Perilla6pictureBox.Visible = false;
                Perilla7pictureBox.Visible = false;
                Perilla3pictureBox.Visible = true;
            }


            if (i > 15 && i < 20)
            {
                Perilla1pictureBox.Visible = false;
                Perilla2pictureBox.Visible = false;
                Perilla3pictureBox.Visible = false;
                Perilla5pictureBox.Visible = false;
                Perilla6pictureBox.Visible = false;
                Perilla7pictureBox.Visible = false;
                Perilla4pictureBox.Visible = true;

            }

            if (i > 20 && i < 35)
            {
                Perilla1pictureBox.Visible = false;
                Perilla2pictureBox.Visible = false;
                Perilla3pictureBox.Visible = false;
                Perilla4pictureBox.Visible = false;
                Perilla6pictureBox.Visible = false;
                Perilla7pictureBox.Visible = false;
                Perilla5pictureBox.Visible = true;
            }


            if (i > 35 && i < 40)
            {
                Perilla1pictureBox.Visible = false;
                Perilla2pictureBox.Visible = false;
                Perilla3pictureBox.Visible = false;
                Perilla4pictureBox.Visible = false;
                Perilla5pictureBox.Visible = false;
                Perilla7pictureBox.Visible = false;
                Perilla6pictureBox.Visible = true;
            }

            if (i > 40 && i < 45)
            {
                Perilla1pictureBox.Visible = false;
                Perilla2pictureBox.Visible = false;
                Perilla3pictureBox.Visible = false;
                Perilla4pictureBox.Visible = false;
                Perilla5pictureBox.Visible = false;
                Perilla6pictureBox.Visible = false;
                Perilla7pictureBox.Visible = true;
            }


            i++;
        }

    }
}
