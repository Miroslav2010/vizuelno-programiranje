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
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
           /* button3.CanSelect = false;
            button4.CanSelect = false;
            button5.CanSelect = false;
            button6.CanSelect = false;
            button7.CanSelect = false; */
        }

        private void reEnableButtons(Button skip)
        {
            Button[] buttons = { button3, button4, button5, button6};
            foreach(Button bttn in buttons)
            {
                if (!(bttn == skip) && bttn.Enabled == false)
                    bttn.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet!", "Implementation Error", MessageBoxButtons.OK);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0)
                MessageBox.Show("Мора да го внесете вашето име!", "Грешка", MessageBoxButtons.OK);
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

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            reEnableButtons(button3);
            button3.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
            reEnableButtons(button4);
            this.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Enabled = false;
            reEnableButtons(button5);
            this.Focus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Enabled = false;
            reEnableButtons(button6);
            this.Focus();
        }

    }
}
