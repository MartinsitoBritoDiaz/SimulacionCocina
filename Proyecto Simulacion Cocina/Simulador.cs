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
        int kcalLena=4650;
        int kcalHojas=4800;
        int kcalCascaraArroz = 0; //por hora

        double kcalActual=0; //para saber el nivel de kcal que se esta quemando en el momento
        int NumeroActual = 0; //Para verificar en que numero esta el boton

        double CalPechugaPollo = 1.45;
        double CalBistec = 2.71;
        double CalChuletaCerdo = 2.31; //por gramo

        double CalActual = 0; //calorias de la porcion actual
        double tiempoestimado = 0;

        double CaloriasTotal = 0;

        double KcaloriasPorQuemar = 0;
        double kcaloriasQuemadas = 0;



        int seg = 0;
        int min = 0;
        int hor = 0;
                    
        bool paso = true; //creo que se puede eliminar

        public Simulador()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Ejecucion();
        }

        public void VerificarKcal()
        {
            if (LenaradioButton.Checked == true)
                kcalActual = ((kcalLena / 60) / NumeroActual); //Kcal/hora de la Leña dividido entre 60 para darlo por minuto
            else
               if (HojasradioButton.Checked == true)
                kcalActual = (kcalHojas / 60) / NumeroActual;
            else
                   if (CascaraArrozradioButton.Checked == true)
                kcalActual = (kcalCascaraArroz / 60) / NumeroActual;

        }

        public void Validar()
        {
            if (LenaradioButton.Checked == false && HojasradioButton.Checked == false && CascaraArrozradioButton.Checked == false)
            {

                paso = false;
                timer.Stop();
                MessageBox.Show("Debe Seleccionar un combustible");
            }
            else
            
                if (PechugaPolloradioButton.Checked == false && BeefSteakradioButton.Checked == false && ChuletaCerdoradioButton.Checked == false)
                {
                    paso = false;
                    timer.Stop();
                    MessageBox.Show("Debe Seleccionar un alimento");
                }
                else
                    if (CantidadACocinarnumericUpDown.Value == 0)
                    {
                        paso = false;
                        timer.Stop();
                        MessageBox.Show("Debe digitar una cantidad a cocinar");
                    }
                    else
                        paso = true;
                
        }

        

        private void Ejecucion()
        {
            Validar();

            if (paso)
            {

                tiempoestimado = (CalActual / kcalActual);
                TiempoEstimadonumericUpDown.Value = Convert.ToDecimal(tiempoestimado/10);


                if(min == 60)
                {
                    hor += 1;
                    min = 0;
                }
                if (seg == 61)
                {
                    min += 1;
                    seg = 0;
                }
                seg += 1;
                Relojlabel.Text = hor.ToString() + ":" + min.ToString() + ":" + seg.ToString();
                //TiemponumericUpDown.Value += Convert.ToDecimal(0.01); //no hace lo que debe, corregir, para que de 0.60 salte a 1.00



                KcaloriasPorQuemar -= kcalActual;
                kcaloriasQuemadas += kcalActual;
                KcalQuemadasnumericUpDown.Value = Convert.ToDecimal(kcaloriasQuemadas);

                if (KcaloriasPorQuemar <= 0)
                {
                    timer.Stop();
                    MessageBox.Show("Se ha terminado de cocinar", "Aviso!");
                    kcaloriasQuemadas = 0;
                    KcaloriasPorQuemar = 0;
                    CantidadACocinarnumericUpDown.Value = 0;
                    

                    Estado1RadioButton.Checked = true;
                }
                else
                {
                    if (Estado1RadioButton.Checked == true)
                    {
                        timer.Stop();
                        if (KcaloriasPorQuemar <= (CalActual / 2))
                        {
                            DialogResult dialogResult = MessageBox.Show("La carne ha quedado a termino medio, Desea seguir cocinando la carne?", "Aviso!", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.No)
                            {
                                kcaloriasQuemadas = 0;
                                KcaloriasPorQuemar = 0;
                                CantidadACocinarnumericUpDown.Value = 0;
                            }
                        }

                    }

                    int aux = 20;
                        

                }

















                i++;
            }
            

        }

        

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            LenaradioButton.Checked = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            HojasradioButton.Checked = true;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            CascaraArrozradioButton.Checked = true;
        }

        private void Estado1RadioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            timer.Stop();
            Perilla2pictureBox.Visible = false;
            Perilla3pictureBox.Visible = false;
            Perilla4pictureBox.Visible = false;
            Perilla5pictureBox.Visible = false;
            Perilla6pictureBox.Visible = false;

            Perilla1pictureBox.Visible = true;

            Fuego1pictureBox.Visible = false;
            Fuego2pictureBox.Visible = false;
            Fuego3pictureBox.Visible = false;
            Fuego4pictureBox.Visible = false;
            Fuego5pictureBox.Visible = false;

            Fuego0pictureBox.Visible = true;

            kcalActual = 0;
            NumeroActual = 0;
            tiempoestimado = 0;
            
        }

       
        private void Estado2RadioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            //Boton en 1
            timer.Stop();
            Perilla1pictureBox.Visible = false;
            Perilla3pictureBox.Visible = false;
            Perilla4pictureBox.Visible = false;
            Perilla5pictureBox.Visible = false;
            Perilla6pictureBox.Visible = false;
            Perilla2pictureBox.Visible = true;

            Fuego0pictureBox.Visible = false;
            Fuego2pictureBox.Visible = false;
            Fuego3pictureBox.Visible = false;
            Fuego4pictureBox.Visible = false;
            Fuego5pictureBox.Visible = false;

            Fuego1pictureBox.Visible = true;

            NumeroActual = 5; //se dividiran las Kcal en 5 para reducir la temperatura
            VerificarKcal();
            
            timer.Start();

        }

        private void Estado3RadioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            //Boton en 2
            Perilla1pictureBox.Visible = false;
            Perilla2pictureBox.Visible = false;
            Perilla4pictureBox.Visible = false;
            Perilla5pictureBox.Visible = false;
            Perilla6pictureBox.Visible = false;
            Perilla3pictureBox.Visible = true;

            Fuego1pictureBox.Visible = false;
            Fuego0pictureBox.Visible = false;
            Fuego3pictureBox.Visible = false;
            Fuego4pictureBox.Visible = false;
            Fuego5pictureBox.Visible = false;

            Fuego2pictureBox.Visible = true;

            NumeroActual = 4;
            VerificarKcal();
            timer.Start();
        }

        private void Estado4RadioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            //Boton en 3
            timer.Stop();
            Perilla1pictureBox.Visible = false;
            Perilla2pictureBox.Visible = false;
            Perilla3pictureBox.Visible = false;
            Perilla5pictureBox.Visible = false;
            Perilla6pictureBox.Visible = false;
            Perilla4pictureBox.Visible = true;

            Fuego1pictureBox.Visible = false;
            Fuego2pictureBox.Visible = false;
            Fuego0pictureBox.Visible = false;
            Fuego4pictureBox.Visible = false;
            Fuego5pictureBox.Visible = false;

            Fuego3pictureBox.Visible = true;

            NumeroActual = 3;
            VerificarKcal();
            timer.Start();
        }

        private void Estado5RadioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            //Boton en 4
            timer.Stop();
            Perilla1pictureBox.Visible = false;
            Perilla2pictureBox.Visible = false;
            Perilla3pictureBox.Visible = false;
            Perilla4pictureBox.Visible = false;
            Perilla6pictureBox.Visible = false;
            Perilla5pictureBox.Visible = true;


            Fuego1pictureBox.Visible = false;
            Fuego2pictureBox.Visible = false;
            Fuego3pictureBox.Visible = false;
            Fuego0pictureBox.Visible = false;
            Fuego5pictureBox.Visible = false;

            Fuego4pictureBox.Visible = true;

            NumeroActual = 2;
            VerificarKcal();
            timer.Start();
        }

        private void Estado6RadioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            //Boton en 5
            timer.Stop();
            Perilla1pictureBox.Visible = false;
            Perilla2pictureBox.Visible = false;
            Perilla3pictureBox.Visible = false;
            Perilla4pictureBox.Visible = false;
            Perilla5pictureBox.Visible = false;
            Perilla6pictureBox.Visible = true;

            Fuego1pictureBox.Visible = false;
            Fuego2pictureBox.Visible = false;
            Fuego3pictureBox.Visible = false;
            Fuego4pictureBox.Visible = false;
            Fuego0pictureBox.Visible = false;

            Fuego5pictureBox.Visible = true;

            NumeroActual = 1;
            VerificarKcal();
            timer.Start();
        }

        private void LenaradioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (i != 0)
                MessageBox.Show("Cambiando Combustible...");
            timer.Stop();
            KcalnumericUpDown.Value = kcalLena;
        }

        private void HojasradioButton_CheckedChanged(object sender, EventArgs e)
        {
            Validar();
            if (i!=0)
                MessageBox.Show("Cambiando Combustible...");
            timer.Stop();
            KcalnumericUpDown.Value = kcalHojas;
        }

        private void CascaraArrozradioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (i != 0)
                MessageBox.Show("Cambiando Combustible...");
            timer.Stop();
            KcalnumericUpDown.Value = kcalCascaraArroz;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void PechugaPolloradioButton_CheckedChanged(object sender, EventArgs e)
        {
            timer.Stop();
            CaloriasnumericUpDown.Value = (CantidadACocinarnumericUpDown.Value * Convert.ToDecimal(CalPechugaPollo));
            CalActual = Convert.ToDouble(CaloriasnumericUpDown.Value);
            KcaloriasPorQuemar = CalActual;//revisar necesidad, posiblemente solo se necesite una de las 2
        }
       
        private void CantidadACocinarnumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            timer.Stop();
            if (PechugaPolloradioButton.Checked==true)//luego puede cambiarse por lo que se vaya a poner
                CaloriasTotal = (Convert.ToDouble(CantidadACocinarnumericUpDown.Value) * CalPechugaPollo);
            else
                if(BeefSteakradioButton.Checked==true)
                CaloriasTotal = (Convert.ToDouble(CantidadACocinarnumericUpDown.Value) * CalBistec);
                else
                    if(ChuletaCerdoradioButton.Checked==true)
                        CaloriasTotal = (Convert.ToDouble(CantidadACocinarnumericUpDown.Value) * CalChuletaCerdo);

            CaloriasnumericUpDown.Value = Convert.ToDecimal(CaloriasTotal);
            CalActual = Convert.ToDouble(CaloriasnumericUpDown.Value);
            KcaloriasPorQuemar = CalActual;//revisar necesidad, posiblemente solo se necesite una de las 2
        }

        private void BeefSteakradioButton_CheckedChanged(object sender, EventArgs e)
        {
            timer.Stop();
            CaloriasnumericUpDown.Value = (CantidadACocinarnumericUpDown.Value * Convert.ToDecimal(CalBistec));
            CalActual = Convert.ToDouble(CaloriasnumericUpDown.Value);
            KcaloriasPorQuemar = CalActual;//revisar necesidad, posiblemente solo se necesite una de las 2
        }


        private void ChuletaCerdoradioButton_CheckedChanged(object sender, EventArgs e)
        {
            timer.Stop();
            CaloriasnumericUpDown.Value = (CantidadACocinarnumericUpDown.Value * Convert.ToDecimal(CalChuletaCerdo));
            CalActual = Convert.ToDouble(CaloriasnumericUpDown.Value);
            KcaloriasPorQuemar = CalActual;//revisar necesidad, posiblemente solo se necesite una de las 2
        }

        private void CaloriasnumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void TiemponumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Simulador_Load(object sender, EventArgs e)
        {

        }
    }
}








//TODO: Codigo por si habia que disminuir la perilla sola.
//if (i > 0 && i < 5)
//{
//    Perilla1pictureBox.Visible = true;
//}


//if (i > 5 && i < 10)
//{

//    Perilla1pictureBox.Visible = false;
//    Perilla2pictureBox.Visible = false;
//    Perilla3pictureBox.Visible = false;
//    Perilla4pictureBox.Visible = false;
//    Perilla5pictureBox.Visible = false;
//    Perilla6pictureBox.Visible = false;
//    PerillapictureBox.Visible = true;

//}

//if (i > 10 && i < 15)
//{
//    Perilla1pictureBox.Visible = false;
//    Perilla2pictureBox.Visible = false;
//    Perilla4pictureBox.Visible = false;
//    Perilla5pictureBox.Visible = false;
//    Perilla6pictureBox.Visible = false;
//    Perilla7pictureBox.Visible = false;
//    Perilla3pictureBox.Visible = true;
//}


//if (i > 15 && i < 20)
//{
//    Perilla1pictureBox.Visible = false;
//    Perilla2pictureBox.Visible = false;
//    Perilla3pictureBox.Visible = false;
//    Perilla5pictureBox.Visible = false;
//    Perilla6pictureBox.Visible = false;
//    Perilla7pictureBox.Visible = false;
//    Perilla4pictureBox.Visible = true;

//}

//if (i > 20 && i < 35)
//{
//    Perilla1pictureBox.Visible = false;
//    Perilla2pictureBox.Visible = false;
//    Perilla3pictureBox.Visible = false;
//    Perilla4pictureBox.Visible = false;
//    Perilla6pictureBox.Visible = false;
//    Perilla7pictureBox.Visible = false;
//    Perilla5pictureBox.Visible = true;
//}


//if (i > 35 && i < 40)
//{
//    Perilla1pictureBox.Visible = false;
//    Perilla2pictureBox.Visible = false;
//    Perilla3pictureBox.Visible = false;
//    Perilla4pictureBox.Visible = false;
//    Perilla5pictureBox.Visible = false;
//    Perilla7pictureBox.Visible = false;
//    Perilla6pictureBox.Visible = true;
//}

//if (i > 40 && i < 45)
//{
//    Perilla1pictureBox.Visible = false;
//    Perilla2pictureBox.Visible = false;
//    Perilla3pictureBox.Visible = false;
//    Perilla4pictureBox.Visible = false;
//    Perilla5pictureBox.Visible = false;
//    Perilla6pictureBox.Visible = false;
//    Perilla7pictureBox.Visible = true;
//}
