using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectVizuelno
{
    
    public partial class Form2 : Form
    {
        int counter;
        string ime;
        int level;
        PictureBox zaAnimiranje;
        PictureBox zaAnimiranje1;
        PictureBox zaAnimiranje2;
        PictureBox box1;
        PictureBox box2;
        Boolean flag;
        Boolean prvSelektiran;
        string firstSelectedValue;
        string secondSelectedValue;

        public Form2(int level,string ime)
        {
            this.CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.counter = 0;
            this.ime = ime;
            this.level = level;
            InitializeComponent();
            zaAnimiranje = null;
            zaAnimiranje1 = null;
            zaAnimiranje2 = null;
            box1 = null;
            box2 = null;
            prvSelektiran = false;
            flag = false;
            GC.Collect();
           
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            if(level == 3)
            {
                timerMin.Text = "2";
                timerSec.Text = "00";
                levell.Text = "Level: " + level.ToString();
                levelname.Text = "Hard";
            }
            if(level == 4)
            {
                timerMin.Text = "1";
                timerSec.Text = "30";
                levell.Text = "Level: " + level.ToString();
                levelname.Text = "Impossible";
            }
            timer1.Stop();
            timer2.Stop();
            box1 = null;
            box2 = null;
            flag = false;
            prvSelektiran = false;
            zaAnimiranje = null;
            zaAnimiranje2 = null;
            timer3.Start();
            List<PictureBox> listaCover = new List<PictureBox>(24);
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
            listaCover.Add(cover17);
            listaCover.Add(cover18);
            listaCover.Add(cover19);
            listaCover.Add(cover20);
            listaCover.Add(cover21);
            listaCover.Add(cover22);
            listaCover.Add(cover23);
            listaCover.Add(cover24);
            List<PictureBox> lista = new List<PictureBox>(24);
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
            lista.Add(pictureBox17);
            lista.Add(pictureBox18);
            lista.Add(pictureBox19);
            lista.Add(pictureBox20);
            lista.Add(pictureBox21);
            lista.Add(pictureBox22);
            lista.Add(pictureBox23);
            lista.Add(pictureBox24);
            int[] niza = new int[24]; //za odreduvanje koja slika odi na koja pozicija
                                      //x = Math.ceil(Math.random() * 16) % 8;
            int[] pomosna = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}; //za proverka dali sekoja slika ima samo 2 pojavuvanja
            Random random = new Random();

            for (int i = 0; i < 24; i++)
            {
                int x = random.Next(0, 48) % 12; // generiranje random broj od 0 do 11
                if (pomosna[x] < 2)
                {
                    pomosna[x]++; //se zabelezuva pojavuvanje
                    niza[i] = x; //odreduvanje slika za taa pozicija
                }
                else
                {
                    i--; //vo slucaj da se pojavi treto pojavuvanje na broj da probame pak za istata pozicija
                    continue;
                }
                listaCover.ElementAt(i).Load("../../Images/Cover-min.png");
                listaCover.ElementAt(i).Height = 50;
                switch (niza[i])
                {
                    case 0:
                        lista.ElementAt(i).Load("../../Images/reddit-min.png");
                        listaCover.ElementAt(i).Tag = "0"; //Tag atributot na cover-ot ke go koristime za proverka dali ima pogodok na 2 isti sliki
                        break;
                    case 1:
                        lista.ElementAt(i).Load("../../Images/android-min.png");
                        listaCover.ElementAt(i).Tag = "1";
                        break;
                    case 2:
                        lista.ElementAt(i).Load("../../Images/firefox-min.png");
                        listaCover.ElementAt(i).Tag = "2";
                        break;
                    case 3:
                        lista.ElementAt(i).Load("../../Images/ubuntu-min.png");
                        listaCover.ElementAt(i).Tag = "3";
                        break;
                    case 4:
                        lista.ElementAt(i).Load("../../Images/macOS-min.png");
                        listaCover.ElementAt(i).Tag = "4";
                        break;
                    case 5:
                        lista.ElementAt(i).Load("../../Images/github-min.png");
                        listaCover.ElementAt(i).Tag = "5";
                        break;
                    case 6:
                        lista.ElementAt(i).Load("../../Images/chrome-min.png");
                        listaCover.ElementAt(i).Tag = "6";
                        break;
                    case 7:
                        lista.ElementAt(i).Load("../../Images/windows-min.png");
                        listaCover.ElementAt(i).Tag = "7";
                        break;
                    case 8:
                        lista.ElementAt(i).Load("../../Images/pinterest-min.png");
                        listaCover.ElementAt(i).Tag = "8";
                        break;
                    case 9:
                        lista.ElementAt(i).Load("../../Images/9gag-min.png");
                        listaCover.ElementAt(i).Tag = "9";
                        break;
                    case 10:
                        lista.ElementAt(i).Load("../../Images/twitch-min.png");
                        listaCover.ElementAt(i).Tag = "10";
                        break;
                    case 11:
                        lista.ElementAt(i).Load("../../Images/facebook-min.png");
                        listaCover.ElementAt(i).Tag = "11";
                        break;

                }
                lista.ElementAt(i).SizeMode = PictureBoxSizeMode.StretchImage;
                listaCover.ElementAt(i).SizeMode = PictureBoxSizeMode.StretchImage;
            }
            GC.Collect();
        }




        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Дали сте сигурни дека сакате да ресетирате?", "Reset",MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                counter = 0;
                Form1_Load(sender, e);
            }
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
                secondSelectedValue = box2.Tag.ToString();
                if (firstSelectedValue.Equals(secondSelectedValue))
                {
                    
                    SoundPlayer sound = new SoundPlayer(Properties.Resources.success);
                    sound.Play();
                    flag = false;
                    prvSelektiran = false;
                    firstSelectedValue = "";
                    secondSelectedValue = "";
                    counter++;
                    if (counter == 12)
                    {
                        timer3.Stop();
                        int min = Int32.Parse(timerMin.Text);
                        int sec = Int32.Parse(timerSec.Text);
                        var poeni = this.level * ((min * 60) + sec);
                        MessageBox.Show("Честитки " + this.ime + ", победивте! Освоивте " + poeni + " поени.", "Победа");
                        var lines = File.ReadAllLines("../../leaderboard.txt").Select(x => x.Split(' ').ToArray()).OrderByDescending(x => Int32.Parse(x[1])).ThenBy(x => x[0]).Select(x => string.Join(" ", x));
                        bool exists = false;
                        bool higher = false;
                        foreach (String line in lines)
                        {
                            var x = line.Split(' ').ToArray();
                            if (x[0].Equals(this.ime))
                            {
                                if (Int32.Parse(x[1]) < poeni)
                                    higher = true;
                                exists = true;
                                break;
                            }
                        }
                        if (exists == true)
                        {
                            if (higher == true)
                            {
                                File.Delete("../../leaderboard.txt");
                                var newFile = File.Create("../../leaderboard.txt");
                                newFile.Close();
                                using (var output = new StreamWriter("../../leaderboard.txt"))
                                {
                                    foreach (string line in lines)
                                    {
                                        var x = line.Split(' ');
                                        if (!(x[0].Equals(this.ime)) && !(line.Equals("")))
                                        {
                                            output.WriteLine(line);
                                        }
                                    }
                                    output.WriteLine(this.ime + " " + poeni);
                                }
                            }
                            else
                            {
                                //do nothing
                            }
                        }
                        else
                        {
                            using (StreamWriter sw = File.AppendText("../../leaderboard.txt"))
                            {
                                sw.WriteLine(this.ime + " " + poeni);
                            }
                        }
                        this.Dispose();
                    }
                    return;
                }
                else
                {
                    SoundPlayer sound = new SoundPlayer(Properties.Resources.beep);
                    sound.Play();
                    firstSelectedValue = "";
                    secondSelectedValue = "";
                    zaAnimiranje1 = box1;
                    zaAnimiranje2 = box2;
                    var w = new Form() { Size = new Size(0, 0) }; 
                    w.WindowState = FormWindowState.Minimized;
                    Task.Delay(TimeSpan.FromSeconds(1)).ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());
                    w.ShowDialog();
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
            if (zaAnimiranje.Height == 0)
            {
                timer1.Stop();
                timer1.Dispose();
                timer1.Enabled = false;
            }
            else
            {
                zaAnimiranje.Height -= 10;
            }
        }





        private void timer2_Tick(object sender, EventArgs e)
        {

            if (zaAnimiranje1.Height >= 100 && zaAnimiranje2.Height >= 100)
            {
                timer2.Stop();
                timer2.Dispose();
                timer2.Enabled = false;
            }
            else
            {
                zaAnimiranje1.Height += 10;
                zaAnimiranje2.Height += 10;
            }
        }




        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Дали сте сигурни дека сакате да излезете од моменталната игра?", "Назад", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
                this.Dispose();
        }




        private void izgubiGame()
        {
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("Обиди се повторно?","", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
                button1_Click(null, null);
            else if (dr == DialogResult.No)
                this.Dispose();
        }



        private void timer3_Tick(object sender, EventArgs e)
        {
            int min = Int32.Parse(timerMin.Text);
            int sec = Int32.Parse(timerSec.Text);
            sec--;
            if(sec == -1 && min != 0)
            {
                min--;
                sec = 59;
            }
            if (sec < 10)
            {
                timerSec.Text = "0" + sec.ToString();
            }
            else
            {
                timerSec.Text = sec.ToString();
            }
            timerMin.Text = min.ToString();
            
            if (sec == 0 && min == 0 && this.Visible == true)
            {
                timer3.Stop();
                timer3.Dispose();
                timer3.Enabled = false;
                izgubiGame();
            }
            else if (sec == 0 && min == 0)
            {
                timer3.Stop();
                timer3.Dispose();
                timer3.Enabled = false;
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer3.Stop();
            timer3.Dispose();
            GC.Collect();
            this.Dispose();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer3.Stop();
            timer3.Dispose();
            GC.Collect();
            this.Dispose();
        }
    }
}
