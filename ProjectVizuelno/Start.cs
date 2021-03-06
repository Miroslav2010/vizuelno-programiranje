﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectVizuelno
{

    public partial class Start : Form
    {
        string ime;
        public static int level;
        Form1 game1;
        Form2 game2;
        public Start()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            GC.Collect();
            Form1 game1 = new Form1(0,"");
            Form2 game2 = new Form2(0,"");
            if (!(File.Exists("../../leaderboard.csv"))) 
            {
                var newFile = File.Create("../../leaderboard.csv");
                newFile.Close();
            } 
        }

        private bool tezina = false; // bool promenliva za dali e stisnato na edna od tezinite

        private void reEnableButtons(Button skip) // dokolku se stisne edno kopce za difficulty, gi enable-nuva ostanatite
        {
            Button[] buttons = { button3, button4, button5, button6};
            foreach(Button bttn in buttons)
            {
                if (!(bttn == skip) && bttn.Enabled == false)
                    bttn.Enabled = true;
            }
            
        }

        private void button2_Click(object sender, EventArgs e) // leaderboards button
        {
            if (textBox1.Text != null)
            {
                leaderboard lb = new leaderboard(textBox1.Text);
                this.Hide();
                lb.ShowDialog();
                this.Show();
            }
            else
            {
                leaderboard lb = new leaderboard(" ");
                this.Hide();
                lb.ShowDialog();
                this.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e) // "zapocni" button
        {
            if (textBox1.TextLength == 0 && tezina == false) 
            {
                MessageBox.Show("Внесете име и тежина!", "Грешка", MessageBoxButtons.OK);
            }
            else if (textBox1.TextLength == 0)
                MessageBox.Show("Мора да го внесете вашето име!", "Грешка", MessageBoxButtons.OK);
            else if (tezina == false)
            {
                MessageBox.Show("Изберете тежина!", "Грешка", MessageBoxButtons.OK);
            }
            else if (textBox1.TextLength <=2)
            {
                MessageBox.Show("Вашето име е прекратко!", "Грешка", MessageBoxButtons.OK);
            }
            else if (textBox1.TextLength > 20)
            {
                MessageBox.Show("Вашето име е предолго! (Максимум 20 карактери)", "Грешка", MessageBoxButtons.OK);
            }
            else if (textBox1.Text.Contains(","))
            {
                MessageBox.Show("Не смее да има запирка во вашето име!", "Грешка", MessageBoxButtons.OK);
            }
            else if(level==1 || level==2)
            {
                ime = textBox1.Text;
                try
                {
                    this.Hide();
                    game1 = new Form1(level, ime);
                    game1.ShowDialog();
                }

                finally
                {
                    if (game1 != null)
                    {
                        game1.Dispose();
                        game1 = null;
                        this.Show();
                    }
                    GC.Collect();
                }

            }
            else if (level == 3 || level == 4)
            {
                ime = textBox1.Text;
                try
                {
                    this.game2 = new Form2(level, ime);
                    this.Hide();
                    game2.ShowDialog();
                }
                finally
                {
                    if (game2 != null) { 
                    game2.Dispose();
                    game2 = null;
                    this.Show();
                    }
                    GC.Collect();
                }
                this.Show();


            }

        }

        private void button3_Click(object sender, EventArgs e) //difficulty button 1
        {
            level = 1;
            tezina = true;
            button3.Enabled = false;
            reEnableButtons(button3);
            button3.Focus();
        }

        private void button4_Click(object sender, EventArgs e) //difficulty button 2
        {
            level = 2;
            tezina = true;
            button4.Enabled = false;
            reEnableButtons(button4);
            this.Focus();
        }

        private void button5_Click(object sender, EventArgs e) //difficulty button 3
        {
            level = 3;
            tezina = true;
            button5.Enabled = false;
            reEnableButtons(button5);
            this.Focus();
        }

        private void button6_Click(object sender, EventArgs e) //difficulty button 4
        {
            level = 4;
            tezina = true;
            button6.Enabled = false;
            reEnableButtons(button6);
            this.Focus();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Start_Load(object sender, EventArgs e)
        {
            GC.Collect();
        }

    }

    class NoSelectButton : Button // klasa za kopcinja sto ne moze da se selektiraat (select fix)
    {
        public NoSelectButton()
        {
            SetStyle(ControlStyles.Selectable, false);
        }
    }
}
