using System;
using System.Collections.Generic;
//using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
//using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectVizuelno
{
    public partial class Form1 : Form
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
        Boolean won;
        Boolean prvSelektiran;
        string firstSelectedValue;
        string secondSelectedValue;

        public Form1(int level,string ime) // prateni level i ime od Start forma-ta
        {

            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.counter = 0;
            this.ime = ime;
            this.level = level;
            
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
            if(level == 1)
            {
                timerMin.Text = "2";
                timerSec.Text = "00";
                levell.Text = "Level: " + level.ToString();
                levelname.Text = "Easy";
            }
            if(level == 2)
            {
                timerMin.Text = "1";
                timerSec.Text = "30";
                levell.Text = "Level: " + level.ToString();
                levelname.Text = "Medium";
            }

            this.Text = "Меморија - ниво " + level + " - " + levelname.Text;
            timer1.Stop();
            timer2.Stop();
            box1 = null;
            box2 = null;
            flag = false;
            prvSelektiran = false;
            zaAnimiranje = null;
            zaAnimiranje2 = null;
            timer3.Start();

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
            
            int[] niza = new int[16]; //za odreduvanje koja slika odi na koja pozicija
                                    
            int[] pomosna = { 0, 0, 0, 0, 0, 0, 0, 0 }; //za proverka dali sekoja slika ima samo 2 pojavuvanja
            Random random = new Random();

            for (int i = 0; i < 16; i++)
            {
                int x = random.Next(0, 64) % 8; // generiranje random broj od 0 do 7
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
                listaCover.ElementAt(i).Height = 100;
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
                }
                lista.ElementAt(i).SizeMode = PictureBoxSizeMode.StretchImage;
                listaCover.ElementAt(i).SizeMode = PictureBoxSizeMode.StretchImage;
            }
            GC.Collect();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer3.Enabled = false;
            DialogResult result = MessageBox.Show("Дали сте сигурни дека сакате да ресетирате?", "Reset", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                counter = 0;
                Form1_Load(sender, e);
            }
            else
            {
                timer3.Enabled = true;
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
                    if (counter == 8)
                    {
                        timer3.Stop();
                        int min = Int32.Parse(timerMin.Text);
                        int sec = Int32.Parse(timerSec.Text);
                        var poeni = this.level * ((min * 60) + sec);
                        MessageBox.Show("Честитки " + this.ime + ", победивте! Освоивте " + poeni + " поени.", "Победа");
                        var lines = File.ReadAllLines("../../leaderboard.csv").Select(x => x.Split(',').ToArray()).OrderByDescending(x => Int32.Parse(x[1])).ThenBy(x => x[0]).Select(x => string.Join(" ", x));
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
                                File.Delete("../../leaderboard.csv");
                                var newFile = File.Create("../../leaderboard.csv");
                                newFile.Close();
                                using (var output = new StreamWriter("../../leaderboard.csv"))
                                {
                                    foreach (string line in lines)
                                    {
                                        var x = line.Split(' ');
                                        if (!(x[0].Equals(this.ime)) && !(line.Equals("")))
                                        {
                                            output.WriteLine(x[0] + "," + x[1]);
                                        }
                                    }
                                    output.WriteLine(this.ime + "," + poeni);
                                }
                            }
                            else
                            {
                                //do nothing
                            }
                        }
                        else
                        {
                            using (StreamWriter sw = File.AppendText("../../leaderboard.csv"))
                            {
                                sw.WriteLine(this.ime + "," + poeni);
                            }
                        }
                        won = true;
                        this.Dispose();
                    }
                    return;
                }
                else
                {
                    firstSelectedValue = "";
                    secondSelectedValue = "";
                    zaAnimiranje1 = box1;
                    zaAnimiranje2 = box2;
                    SoundPlayer sound = new SoundPlayer(Properties.Resources.beep);
                    sound.Play();
                    var w = new Form() {  }; 
                    w.WindowState = FormWindowState.Minimized;
                    Task.Delay(TimeSpan.FromSeconds(1)).ContinueWith((t) => w.Dispose(), TaskScheduler.FromCurrentSynchronizationContext());
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
            this.Close();
        }

        private void izgubiGame()
        {
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("Обиди се повторно?","", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
                Form1_Load(null, null);
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

            if (sec <= 0 && min <= 0)
            {
                timer3.Stop();
                timer3.Dispose();
                timer3.Enabled = false;
                izgubiGame();
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!won)
            {
                timer3.Enabled = false;
                DialogResult dr = MessageBox.Show("Дали сте сигурни дека сакате да излезете од моменталната игра?", "Назад", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    timer3.Stop();
                    timer3.Dispose();
                    GC.Collect();
                    this.Dispose();
                }
                else
                {
                    timer3.Enabled = true;
                    e.Cancel = true;
                }
            }
            else
                won = false;
        }
    }
}
