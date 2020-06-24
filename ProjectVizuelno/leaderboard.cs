using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ProjectVizuelno
{
    public partial class leaderboard : Form
    {
        public leaderboard()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            updateLeaderBoard("");
        }

        private void updateLeaderBoard(string skip) // read leaderboard from txt file
        {
            var lines = File.ReadAllLines("../../leaderboard.txt").Select(x => x.Split(' ').ToArray()).OrderByDescending(x => Int32.Parse(x[1])).ThenBy(x => x[0]).Select(x => string.Join(" ", x));
            int i = 1;
            foreach (String line in lines)
            {
                var x = line.Split(' ').ToArray();
                if (!(line.Equals(skip)) && !(line.Equals("")))
                {
                    ListViewItem lvi = new ListViewItem(i.ToString());
                    listView1.FullRowSelect = true;
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) //reset button
        {
            if (listView1.Items.Count == 0) // proveri dali listata e prazna, ako e prikazi messagebox, ako ne resetiraj ja
            {
                MessageBox.Show("Листата е празна!", "Грешка", MessageBoxButtons.OK);
            }
            else
            {
                DialogResult result = MessageBox.Show("Дали сте сигурни дека сакате да ресетирате?", "Reset", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    File.Delete("../../leaderboard.txt");
                    var newFile = File.Create("../../leaderboard.txt"); 
                    newFile.Close();
                    listView1.Items.Clear();
                    updateLeaderBoard("");
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
                var lines = File.ReadAllLines("../../leaderboard.txt").Select(x => x.Split(' ').ToArray()).OrderByDescending(x => Int32.Parse(x[1])).ThenBy(x => x[0]).Select(x => string.Join(" ", x));
                File.Delete("../../leaderboard.txt");
                var newFile = File.Create("../../leaderboard.txt"); 
                newFile.Close();
                using (var output = new StreamWriter("../../leaderboard.txt")) 
                {
                    int i = 1;
                    foreach (string line in lines)
                    {
                        var x = line.Split(' ');
                        var lineX = String.Format(i + ". " + x[0] + " " + x[1]);
                        if (!(lineX.Equals(del)) && !(line.Equals("")))
                        {
                            output.WriteLine(line);
                        }
                        i++;
                    }
                }

                updateLeaderBoard(del);
            }
            else // ako nema izbrano sto da se izbrise, prikazi messagebox
            {
                MessageBox.Show("Изберете линија да се избрише!", "Грешка", MessageBoxButtons.OK);
            }
        }

        private void leaderboard_Load(object sender, EventArgs e)
        {

        }
    }
}
