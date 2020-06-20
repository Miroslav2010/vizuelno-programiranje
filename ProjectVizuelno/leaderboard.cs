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
using System.Xml;

namespace ProjectVizuelno
{
    public partial class leaderboard : Form
    {
        public leaderboard()
        {
            InitializeComponent();
            updateLeaderBoard("");
        }

        private void updateLeaderBoard(string skip) // read leaderboard from txt file
        {
            var lines = File.ReadAllLines("../../leaderboard.txt").Select(x => x.Split(' ').ToArray()).OrderByDescending(x => x[1]).ThenBy(x => x[0]).Select(x => string.Join(" ", x));
            foreach (String line in lines)
            {
                if(!(line.Equals(skip)))
                listBox1.Items.Add(line);
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
            if (listBox1.Items.Count == 0) // proveri dali listata e prazna, ako e prikazi messagebox, ako ne resetiraj ja
            {
                MessageBox.Show("Листата е празна!", "Грешка", MessageBoxButtons.OK);
            }
            else
            {
                File.Delete("../../leaderboard.txt"); // REMOVE (../../) FROM PATH WHEN EVERYTHING ELSE IS DONE
                var newFile = File.Create("../../leaderboard.txt"); // REMOVE (../../) FROM PATH WHEN EVERYTHING ELSE IS DONE
                newFile.Close();
                listBox1.Items.Clear();
                updateLeaderBoard("");
            }
            
        }

        private void button1_Click(object sender, EventArgs e) // izbrisi button
        {
            if (listBox1.Items.Count == 0) // proveri dali listata e prazna
            {
                MessageBox.Show("Листата е празна!", "Грешка", MessageBoxButtons.OK);
            }
            else if (listBox1.SelectedIndex != -1) // ako ima izbrano sto da se izbrise, izbrisi go
            {
                string del = listBox1.SelectedItem.ToString();
                listBox1.Items.Clear();
                string[] lines = File.ReadAllLines("../../leaderboard.txt"); // REMOVE (../../) FROM PATH WHEN EVERYTHING ELSE IS DONE
                File.Delete("../../leaderboard.txt"); // REMOVE (../../) FROM PATH WHEN EVERYTHING ELSE IS DONE
                var newFile = File.Create("../../leaderboard.txt"); // REMOVE (../../) FROM PATH WHEN EVERYTHING ELSE IS DONE
                newFile.Close();
                using (var output = new StreamWriter("../../leaderboard.txt")) 
                {
                    foreach (string line in lines)
                    {
                        if (!(line.Equals(del)))
                        {
                            output.WriteLine(line);
                        }
                    }
                }

                updateLeaderBoard(del);
            }
            else // ako nema izbrano sto da se izbrise, prikazi messagebox
            {
                MessageBox.Show("Изберете линија да се избрише!", "Грешка", MessageBoxButtons.OK);
            }
        }
    }
}
