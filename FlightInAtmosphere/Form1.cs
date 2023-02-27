using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightInAtmosphere
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int i = 0;
        const double g = 9.81;
        const double C = 0.15;
        const double rho = 1.29;

        double height, angle, speed, size, weight;
        double t, x, y, vx, vy, dt;
        double cosa, sina, beta, k;
        double maxHeight;

        private void vivod(double distance, double maxHeight, double root)
        {
            switch (i)
            {
                case 0: 
                    stepTextBox0.Text = dt.ToString();
                    distanceTextBox0.Text = distance.ToString();
                    heightTextBox0.Text = maxHeight.ToString();
                    speedTextBox0.Text = root.ToString();
                    break;
                case 1: 
                    stepTextBox1.Text = dt.ToString();
                    distanceTextBox1.Text = distance.ToString();
                    heightTextBox1.Text = maxHeight.ToString();
                    speedTextBox1.Text = root.ToString();
                    break;
                case 2:
                    stepTextBox2.Text = dt.ToString();
                    distanceTextBox2.Text = distance.ToString();
                    heightTextBox2.Text = maxHeight.ToString();
                    speedTextBox2.Text = root.ToString();
                    break;
                case 3:
                    stepTextBox3.Text = dt.ToString();
                    distanceTextBox3.Text = distance.ToString();
                    heightTextBox3.Text = maxHeight.ToString();
                    speedTextBox3.Text = root.ToString();
                    break;
                case 4:
                    stepTextBox4.Text = dt.ToString();
                    distanceTextBox4.Text = distance.ToString();
                    heightTextBox4.Text = maxHeight.ToString();
                    speedTextBox4.Text = root.ToString();
                    break;
                case 5:
                    stepTextBox5.Text = dt.ToString();
                    distanceTextBox5.Text = distance.ToString();
                    heightTextBox5.Text = maxHeight.ToString();
                    speedTextBox5.Text = root.ToString();
                    break;
            }
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            height = (double)edHeight.Value;
            angle = (double)edAngle.Value * Math.PI / 180;
            speed = (double)edSpeed.Value;
            size = (double)edSize.Value;
            weight = (double)edWeight.Value;
            dt = (double)edStep.Value;

            cosa = Math.Cos(angle);
            sina = Math.Sin(angle); 
            beta = 0.5 * C * size * rho;
            k = beta / weight;

            t = 0;
            x = 0;
            y = height;
            maxHeight = y;
            vx = speed * cosa;
            vy = speed * sina;

            chart1.Series[i].Points.AddXY(x, y);
            
            timer1.Start();
            
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {   
            double root = Math.Sqrt(vx * vx + vy * vy);
            
            t += dt;

            vx = vx - k * vx * root * dt;
            vy = vy - (g + k * vy * root) * dt;

            x = x + vx * dt;
            y = y + vy * dt;

            if(maxHeight < y) maxHeight = y;

            chart1.Series[i].Points.AddXY(x, y);
            if (y <= 0) {              
                root = Math.Sqrt(vx * vx + vy * vy);
                vivod(x, maxHeight, root);
                timer1.Stop();
                i++;
            }
        }
    }
}
