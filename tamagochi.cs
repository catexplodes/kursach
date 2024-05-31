using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursach
{
    public partial class tamagochi : Form
    {
        int sleep = 0;
        int life = 1;

        public tamagochi()
        {
            InitializeComponent();
            pictureBox1.Image = imageList1.Images[0]; //начальный спрайт
        }

        private void button1_Click(object sender, EventArgs e) //кормить
        { 
            if(life!=0){
                sleep = 0;
                pictureBox1.Image = imageList1.Images[1];
                if (progressBar1.Value > progressBar1.Minimum + 200)
                    progressBar1.Value -= 200;
                else progressBar1.Value = 0;
            }

        }

        private void button2_Click(object sender, EventArgs e) //спать
        {
            if (life != 0)
            {
                pictureBox1.Image = imageList1.Images[3];
                sleep = 1;
            }
        }

        private void button3_Click(object sender, EventArgs e) //играть
        {
            if (life != 0)
            {
                sleep = 0;
                pictureBox1.Image = imageList1.Images[5];
                if (progressBar3.Value < progressBar3.Maximum - 200)
                    progressBar3.Value += 200;
                else progressBar3.Value = progressBar3.Maximum;
            }
        }

        private void button4_Click(object sender, EventArgs e) //разбудить
        {
            if (life != 0)
            {
                pictureBox1.Image = imageList1.Images[0];
                sleep = 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(progressBar1.Value<progressBar1.Maximum)
                progressBar1.Value++; //голод
            if (sleep == 1) //усталость
            {
                if (progressBar2.Value > progressBar2.Minimum + 10)
                {
                    progressBar2.Value -= 10;

                }
                else
                {
                    progressBar2.Value = progressBar2.Minimum; //просыпается сам когда усталость на нуле
                    pictureBox1.Image = imageList1.Images[0];
                    sleep = 0;
                }
            }
            else {
                if (progressBar2.Value < progressBar2.Maximum)
                    progressBar2.Value++;
            }
            if(progressBar3.Value>progressBar3.Minimum)
                progressBar3.Value--; //счастье
            if(progressBar1.Value==progressBar1.Maximum && sleep == 0)
                pictureBox1.Image = imageList1.Images[8];
            if(progressBar2.Value==progressBar2.Maximum && sleep == 0)
                pictureBox1.Image = imageList1.Images[4];
            if(progressBar3.Value==progressBar3.Minimum && sleep == 0)
                pictureBox1.Image = imageList1.Images[2];
            if(progressBar1.Value == progressBar1.Maximum && progressBar2.Value == progressBar2.Maximum && progressBar3.Value == progressBar3.Minimum)
            {
                life = 0;
                pictureBox1.Image = imageList1.Images[9];
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(sleep==0 && progressBar1.Value != progressBar1.Maximum && progressBar2.Value != progressBar2.Maximum && progressBar3.Value != progressBar3.Minimum && life!=0)
                pictureBox1.Image = imageList1.Images[0]; //меняет спрайт на нейтральный после того как покормили/поиграли
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images[0];
            progressBar1.Value = 0;
            progressBar2.Value = 0;
            progressBar3.Value = 10000;
            life = 1;
        }

        private void tamagochi_Load(object sender, EventArgs e)
        {

        }
    }
}
