using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hurma
{
    public partial class Form1 : Form
    {

        double tim1, tim2, tim3, tim4;
        double x_real, y_real, z_real;
        double x, y, z;
        double time1, time2, time3, time4;
        double quad, start = 0, celsium, sonic;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Refresh();
            x_real = Double.Parse(textBox1.Text);
            y_real = Double.Parse(textBox2.Text);
            z_real = Double.Parse(textBox5.Text);

            celsium = Double.Parse(textBox3.Text);
            quad = Double.Parse(textBox4.Text);

            sonic = Math.Sqrt(1.4 * 287 * (celsium + 273.15));
            label15.Text = sonic.ToString();

            time1 = ((Math.Sqrt(Math.Pow(x_real, 2) + Math.Pow(y_real, 2) + Math.Pow(z_real, 2))) / sonic) * 1000000;
            time2 = ((Math.Sqrt(Math.Pow((quad - x_real), 2) + Math.Pow(y_real, 2) + Math.Pow(z_real, 2))) / sonic) * 1000000;
            time3 = ((Math.Sqrt(Math.Pow((quad - y_real), 2) + Math.Pow(x_real, 2) + Math.Pow(z_real, 2))) / sonic) * 1000000;
            time4 = ((Math.Sqrt(Math.Pow((quad - z_real), 2) + Math.Pow(x_real, 2) + Math.Pow(y_real, 2))) / sonic) * 1000000;

            if (start != 0)
            {
                time1 = time1 + start;
                time2 = time2 + start;
                time3 = time3 + start;
                time4 = time4 + start;
            }

            label8.Text = time1.ToString();
            label7.Text = time2.ToString();
            label4.Text = time3.ToString();
            label23.Text = time4.ToString();

            label19.Text = (time1/1000).ToString();
            label18.Text = (time2/1000).ToString();
            label17.Text = (time3/1000).ToString();
            label22.Text = (time4/1000).ToString();

            tim1 = ((double)(time1 - start)) / 1000000;
            tim2 = ((double)(time2 - start)) / 1000000;
            tim3 = ((double)(time3 - start)) / 1000000;
            tim4 = ((double)(time4 - start)) / 1000000;

            label1.Text = tim1.ToString();
            label2.Text = tim2.ToString();
            label3.Text = tim3.ToString();
            label24.Text = tim4.ToString();

            x = ( ( (Math.Pow(tim1, 2)) - (Math.Pow(tim2, 2)) ) * (Math.Pow(sonic, 2)) + (Math.Pow(quad, 2)) ) / (2 * quad);
            y = ( ( (Math.Pow(tim1, 2)) - (Math.Pow(tim3, 2)) ) * (Math.Pow(sonic, 2)) + (Math.Pow(quad, 2)) ) / (2 * quad);
            z = ( ( (Math.Pow(tim1, 2)) - (Math.Pow(tim4, 2)) ) * (Math.Pow(sonic, 2)) + (Math.Pow(quad, 2)) ) / (2 * quad);

            label5.Text = x.ToString();
            label6.Text = y.ToString();
            label21.Text = z.ToString();

            float a = (float)x;
            float b = (float)y;
            float c = 200 / (float)quad;

            Graphics graph = pictureBox1.CreateGraphics();
            Pen pen_red = new Pen(Brushes.Red, 1);
            Pen pen_green = new Pen(Brushes.Green, 1);
            Pen pen_blue = new Pen(Brushes.Blue, 1);
            Pen pen_black = new Pen(Brushes.Black, 3);

            graph.DrawLine(pen_green, 0, 0, (a * c), (200 - (b * c)) );
            graph.DrawLine(pen_red, 200, 200, (a * c), (200 - (b * c)));
            graph.DrawLine(pen_blue, 0, 200, (a * c), (200 - (b * c)));

            graph.DrawEllipse(pen_black, (a * c), (200 - (b * c)), 1, 1);
        }
    }
}
