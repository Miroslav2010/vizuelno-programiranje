using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ProjectVizuelno
{
    public partial class leaderboard : Form
    {
        string ime;
        public leaderboard(string ime)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.ime = ime;
            updateLeaderBoard();
        }

        private void updateLeaderBoard() // read leaderboard from csv file
        {
            var lines = File.ReadAllLines("../../leaderboard.csv").Select(x => x.Split(',').ToArray()).OrderByDescending(x => Int32.Parse(x[1])).ThenBy(x => x[0]).Select(x => string.Join(",", x));
            int i = 1;
            foreach (String line in lines)
            {
                var x = line.Split(',').ToArray();
                if (!(line.Equals("")))
                {
                    ListViewItem lvi = new ListViewItem(i.ToString());
                    listView1.FullRowSelect = true;
                    if (this.ime.Equals(x[0]))
                        lvi.BackColor = Color.Yellow;
                    lvi.SubItems.Add(x[0]);
                    lvi.SubItems.Add(x[1]);
                    listView1.HideSelection = false;
                    listView1.Items.Add(lvi);
                }
                i++;
            } 

        }

        private void button3_Click(object sender, EventArgs e) // nazad button
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) //reset button
        {
            if (listView1.Items.Count == 0) // proveri dali listata e prazna, ako e prikazi messagebox, ako ne resetiraj ja
            {
                MessageBox.Show("Листата е празна!", "Грешка", MessageBoxButtons.OK);
            }
            else
            {
                DialogResult result = MessageBox.Show("Дали сте сигурни дека сакате да ја избришете листата?", "Избриши листа", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    File.Delete("../../leaderboard.csv");
                    var newFile = File.Create("../../leaderboard.csv"); 
                    newFile.Close();
                    listView1.Items.Clear();
                    updateLeaderBoard();
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e) // izbrisi button
        {
            if (listView1.Items.Count == 0) // proveri dali listata e prazna
            {
                MessageBox.Show("Листата е празна!", "Грешка", MessageBoxButtons.OK);
            }
            else if (listView1.SelectedItems.Count != 0) // ako ima izbrano sto da se izbrise, izbrisi go
            {
                string del = listView1.SelectedItems[0].SubItems[0].Text.ToString()+ ". " + listView1.SelectedItems[0].SubItems[1].Text.ToString() + " " + listView1.SelectedItems[0].SubItems[2].Text.ToString();
                listView1.Items.Clear();
                var lines = File.ReadAllLines("../../leaderboard.csv").Select(x => x.Split(',').ToArray()).OrderByDescending(x => Int32.Parse(x[1])).ThenBy(x => x[0]).Select(x => string.Join(",", x));
                File.Delete("../../leaderboard.csv");
                var newFile = File.Create("../../leaderboard.csv"); 
                newFile.Close();
                using (var output = new StreamWriter("../../leaderboard.csv")) 
                {
                    int i = 1;
                    foreach (string line in lines)
                    {
                        var x = line.Split(',');
                        var lineX = String.Format(i + ". " + x[0] + " " + x[1]);
                        if (!(lineX.Equals(del)) && !(line.Equals("")))
                        {
                            output.WriteLine(x[0] + "," + x[1]);
                        }
                        i++;
                    }
                }

                updateLeaderBoard();
            }
            else // ako nema izbrano sto da se izbrise, prikazi messagebox
            {
                MessageBox.Show("Изберете запис за бришење!", "Грешка", MessageBoxButtons.OK);
            }
        }

        private void leaderboard_Load(object sender, EventArgs e)
        {

        }
    }

}
