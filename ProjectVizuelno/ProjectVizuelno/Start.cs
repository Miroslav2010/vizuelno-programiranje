using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectVizuelno
{

    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
            /*if (!(File.Exists("leaderboard.txt")))  // ENABLE THIS WHEN EVERYTHING ELSE IS DONE
            {
                var newFile = File.Create("leaderboard.txt");
                newFile.Close();
            } */
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
            //MessageBox.Show("Not implemented yet!", "Implementation Error", MessageBoxButtons.OK);
            leaderboard lb = new leaderboard();
            this.Hide();
            lb.ShowDialog();
            this.Show();

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
            else
            {
                Form1 game = new Form1();
                this.Hide();
                game.ShowDialog();
                this.Show();
            }

        }

        private void button3_Click(object sender, EventArgs e) //difficulty button 1
        {
            tezina = true;
            button3.Enabled = false;
            reEnableButtons(button3);
            button3.Focus();
        }

        private void button4_Click(object sender, EventArgs e) //difficulty button 2
        {
            tezina = true;
            button4.Enabled = false;
            reEnableButtons(button4);
            this.Focus();
        }

        private void button5_Click(object sender, EventArgs e) //difficulty button 3
        {
            tezina = true;
            button5.Enabled = false;
            reEnableButtons(button5);
            this.Focus();
        }

        private void button6_Click(object sender, EventArgs e) //difficulty button 4
        {
            tezina = true;
            button6.Enabled = false;
            reEnableButtons(button6);
            this.Focus();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
