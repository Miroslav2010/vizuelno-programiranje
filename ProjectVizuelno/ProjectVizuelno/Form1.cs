using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectVizuelno
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox17.Load("../../Images/back.jpg");
            List<PictureBox> lista = new List<PictureBox>(16);
            lista.Add(pictureBox1);
            lista.Add(pictureBox2);
            lista.Add(pictureBox3);
            lista.Add(pictureBox4);
            lista.Add(pictureBox5);
            lista.Add(pictureBox6);
            lista.Add(pictureBox7);
            lista.Add(pictureBox8);
            lista.Add(pictureBox9);
            lista.Add(pictureBox10);
            lista.Add(pictureBox11);
            lista.Add(pictureBox12);
            lista.Add(pictureBox13);
            lista.Add(pictureBox14);
            lista.Add(pictureBox15);
            lista.Add(pictureBox16);
            int[] niza = new int[16];
            //x = Math.ceil(Math.random() * 16) % 8;
            
            int[] pomosna = { 0, 0, 0, 0, 0, 0, 0, 0 };
            Random random = new Random();
            var broj = random.NextDouble();
            //pictureBox1.Load("../../Images/back.jpg");
            for(int i = 0; i < 16; i++)
            {
                int x = random.Next(0,132) % 8;
                if(pomosna[x] < 2)
                {
                    pomosna[x]++;
                    niza[i] = x;
                }
                else
                {
                    i--;
                }
            }
            for(int i = 0; i < 16; i++)
            {
                switch (niza[i])
                {
                    case 0:
                        lista.ElementAt(i).Load("../../Images/facebook.png");
                        lista.ElementAt(i).Tag = "0";
                        break;
                    case 1:
                        lista.ElementAt(i).Load("../../Images/android.jpg");
                        break;
                    case 2:
                        lista.ElementAt(i).Load("../../Images/firefox.png");
                        break;
                    case 3:
                        lista.ElementAt(i).Load("../../Images/linux.png");
                        break;
                    case 4:
                        lista.ElementAt(i).Load("../../Images/macOS.png");
                        break;
                    case 5:
                        lista.ElementAt(i).Load("../../Images/thunderbird.png");
                        break;
                    case 6:
                        lista.ElementAt(i).Load("../../Images/chrome.png");
                        break;
                    case 7:
                        lista.ElementAt(i).Load("../../Images/windows.jpg");
                        break;
                }
                lista.ElementAt(i).SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }
        private void func(PictureBox box)
        {
            timer1.Start();
        }
        private void pictureBox17_Click(object sender, EventArgs e)
        {
            
            func(pictureBox17);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox17.Height <= 0)
            {

                timer1.Stop();
            }
            else {
                pictureBox17.Height -= 2;
          }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
