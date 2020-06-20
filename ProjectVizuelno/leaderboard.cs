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
            this.MinimizeBox = false;
            updateLeaderBoard("");
        }

        private void updateLeaderBoard(string skip) // read leaderboard from txt file
        {

            var lines = File.ReadAllLines("../../leaderboard.txt").Select(x => x.Split(' ').ToArray()).OrderByDescending(x => x[1]).ThenBy(x => x[0]).Select(x => string.Join(" ", x));
            int i = 1;
            foreach (String line in lines)
            {
                var x = line.Split(' ').ToArray();
                if (!(line.Equals(skip)) && !(line.Equals("")))
                {
                    /*int bigL = 0;
                    char[] charArr = x[0].ToCharArray();
                    foreach(char ch in charArr)
                    {
                        if (Char.IsUpper(ch))
                            bigL++;
                    } */
                    listBox1.Items.Add(String.Format("{0} {1} {2}", i + ".\t", x[0].ToLower() + "\t\t\t", x[1]));
                    //listBox1.Items.Add(i + ".\t" + x[0] + "\t\t\t" + x[1]);
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
            if (listBox1.Items.Count == 0) // proveri dali listata e prazna, ako e prikazi messagebox, ako ne resetiraj ja
            {
                MessageBox.Show("Листата е празна!", "Грешка", MessageBoxButtons.OK);
            }
            else
            {
                DialogResult result = MessageBox.Show("Дали сте сигурни дека сакате да ресетирате?", "Reset", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    File.Delete("../../leaderboard.txt"); // REMOVE (../../) FROM PATH WHEN EVERYTHING ELSE IS DONE
                    var newFile = File.Create("../../leaderboard.txt"); // REMOVE (../../) FROM PATH WHEN EVERYTHING ELSE IS DONE
                    newFile.Close();
                    listBox1.Items.Clear();
                    updateLeaderBoard("");
                }
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
                //Console.WriteLine(del);
                listBox1.Items.Clear();
                var lines = File.ReadAllLines("../../leaderboard.txt").Select(x => x.Split(' ').ToArray()).OrderByDescending(x => x[1]).ThenBy(x => x[0]).Select(x => string.Join(" ", x)); // REMOVE (../../) FROM PATH WHEN EVERYTHING ELSE IS DONE
                File.Delete("../../leaderboard.txt"); // REMOVE (../../) FROM PATH WHEN EVERYTHING ELSE IS DONE
                var newFile = File.Create("../../leaderboard.txt"); // REMOVE (../../) FROM PATH WHEN EVERYTHING ELSE IS DONE
                newFile.Close();
                using (var output = new StreamWriter("../../leaderboard.txt")) 
                {
                    int i = 1;
                    foreach (string line in lines)
                    {
                        var x = line.Split(' ');
                        var lineX = String.Format("{0} {1} {2}", i + ".\t", x[0].ToLower() + "\t\t\t", x[1]);
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

    }
}
