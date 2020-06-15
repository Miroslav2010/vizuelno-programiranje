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
        PictureBox zaAnimiranje;
        PictureBox zaAnimiranje1;
        PictureBox zaAnimiranje2;
        PictureBox box1;
        PictureBox box2;
        Boolean flag;
        Boolean prvSelektiran;
        string firstSelectedValue;
        string secondSelectedValue;
        public Form1()
        {
            InitializeComponent();
            zaAnimiranje = null;
            zaAnimiranje1 = null;
            zaAnimiranje2 = null;
            box1 = null;
            box2 = null;
            prvSelektiran = false;
            flag = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            box1 = null;
            box2 = null;
            flag = false;
            prvSelektiran = false;
            zaAnimiranje = null;
            zaAnimiranje2 = null;
            cover1.Load("../../Images/back.jpg");
            cover2.Load("../../Images/back.jpg");
            cover3.Load("../../Images/back.jpg");
            cover4.Load("../../Images/back.jpg");
            cover5.Load("../../Images/back.jpg");
            cover6.Load("../../Images/back.jpg");
            cover7.Load("../../Images/back.jpg");
            cover8.Load("../../Images/back.jpg");
            cover9.Load("../../Images/back.jpg");
            cover10.Load("../../Images/back.jpg");
            cover11.Load("../../Images/back.jpg");
            cover12.Load("../../Images/back.jpg");
            cover13.Load("../../Images/back.jpg");
            cover14.Load("../../Images/back.jpg");
            cover15.Load("../../Images/back.jpg");
            cover16.Load("../../Images/back.jpg");
            List<PictureBox> listaCover = new List<PictureBox>(16);
            listaCover.Add(cover1);
            listaCover.Add(cover2);
            listaCover.Add(cover3);
            listaCover.Add(cover4);
            listaCover.Add(cover5);
            listaCover.Add(cover6);
            listaCover.Add(cover7);
            listaCover.Add(cover8);
            listaCover.Add(cover9);
            listaCover.Add(cover10);
            listaCover.Add(cover11); 
            listaCover.Add(cover12);
            listaCover.Add(cover13);
            listaCover.Add(cover14);
            listaCover.Add(cover15);
            listaCover.Add(cover16);
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
            foreach(var i in listaCover)
            {
                i.Height = 100;
            }
            int[] niza = new int[16]; //za odreduvanje koja slika odi na koja pozicija
            //x = Math.ceil(Math.random() * 16) % 8;
            
            int[] pomosna = { 0, 0, 0, 0, 0, 0, 0, 0 }; //za proverka dali sekoja slika ima samo 2 pojavuvanja
            Random random = new Random();
            //pictureBox1.Load("../../Images/back.jpg");
            for(int i = 0; i < 16; i++)
            {
                int x = random.Next(0,16) % 8; // generiranje random broj od 0 do 7
                if(pomosna[x] < 2)
                {
                    pomosna[x]++; //se zabelezuva pojavuvanje
                    niza[i] = x; //odreduvanje slika za taa pozicija
                }
                else
                {
                    i--; //vo slucaj da se pojavi treto pojavuvanje na broj da probame pak za istata pozicija
                }
            }
            label3.Text = "";
            for(int i = 0; i < 16; i++)
            {
                label3.Text += niza[i].ToString() + " ";
            }
            for(int i = 0; i < 16; i++)
            {
                switch (niza[i])
                {
                    case 0:
                        lista.ElementAt(i).Load("../../Images/facebook.png");
                        listaCover.ElementAt(i).Tag = "0"; //Tag atributot na cover-ot ke go koristime za proverka dali ima pogodok na 2 isti sliki
                        break;
                    case 1:
                        lista.ElementAt(i).Load("../../Images/android.jpg");
                        listaCover.ElementAt(i).Tag = "1";
                        break;
                    case 2:
                        lista.ElementAt(i).Load("../../Images/firefox.png");
                        listaCover.ElementAt(i).Tag = "2";
                        break;
                    case 3:
                        lista.ElementAt(i).Load("../../Images/linux.png");
                        listaCover.ElementAt(i).Tag = "3";
                        break;
                    case 4:
                        lista.ElementAt(i).Load("../../Images/macOS.png");
                        listaCover.ElementAt(i).Tag = "4";
                        break;
                    case 5:
                        lista.ElementAt(i).Load("../../Images/thunderbird.png");
                        listaCover.ElementAt(i).Tag = "5";
                        break;
                    case 6:
                        lista.ElementAt(i).Load("../../Images/chrome.png");
                        listaCover.ElementAt(i).Tag = "6";
                        break;
                    case 7:
                        lista.ElementAt(i).Load("../../Images/windows.jpg");
                        listaCover.ElementAt(i).Tag = "7";
                        break;
                }
                lista.ElementAt(i).SizeMode = PictureBoxSizeMode.StretchImage;
                listaCover.ElementAt(i).SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }
        private void pictureBox17_Click(object sender, EventArgs e)
        {
            
            if (!prvSelektiran) //prvicno e false
            {
                prvSelektiran = true;
                box1 = (PictureBox)sender;
                clicked(box1);
            }
            else
            {
                box2 = (PictureBox)sender;
                clicked(box2);
            }
        }
        private void clicked(PictureBox box)
        {
            zaAnimiranje = box;
            timer1.Start();
            if (flag)
            {
                label1.Text = firstSelectedValue;
                secondSelectedValue = box2.Tag.ToString();
                label2.Text = secondSelectedValue;
                if (firstSelectedValue.Equals(secondSelectedValue))
                {
                    flag = false;
                    prvSelektiran = false;
                    firstSelectedValue = "";
                    secondSelectedValue = "";
                    return;
                }
                else
                {
                    firstSelectedValue = "";
                    secondSelectedValue = "";
                    zaAnimiranje1 = box1;
                    zaAnimiranje2 = box2;
                    zaAnimiranje.Height = 0;
                    zaAnimiranje2.Height = 0;
                    System.Threading.Thread.Sleep(500);
                    timer2.Start();
                    flag = false;
                    prvSelektiran = false;
                    return;
                }
            }
            flag = true;
            firstSelectedValue = box1.Tag.ToString();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (zaAnimiranje.Height <= 0)
            {
                timer1.Stop();
                timer1.Dispose();
            }
            else
            {
                zaAnimiranje.Height -= 10;
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            
            if (zaAnimiranje1.Height == 100 && zaAnimiranje2.Height == 100)
            {
                timer2.Stop();
                return;
            }
            else
            {
                zaAnimiranje1.Height += 10;
                zaAnimiranje2.Height += 10;
            }
        }
    }
}
