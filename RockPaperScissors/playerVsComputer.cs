using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace RockPaperScissors
{
    public partial class playerVsComputer : Form
    {
        private Form1 form1;
        int choose = 0;
        string user = "";
        int close = 0;
        int userID = 0;


        public playerVsComputer(string userName, int ID, Form1 form11)
        {
            InitializeComponent();

            user = userName;
            userID = ID;

            highScore();

            label1.Text = "You are playing as: " + userName;

            label4.Text = "Nothing";

            label7.Text = user + "       VS      Computer";
            label8.Text = "0           -             0";

            form1 = form11;
        }

        private void highScore()
        {
            using (SQLiteConnection conn = new SQLiteConnection("data source = database-PC.db"))
            {
                conn.Open();


                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "SELECT * FROM scoreboard_PvC WHERE user_id=" + userID + ";";

                    //cmd.ExecuteNonQuery();

                    SQLiteDataReader reader = cmd.ExecuteReader();
                    int highScore = 0;

                    while (reader.Read())
                    {
                        int bestScore = reader.GetInt32(4);

                        if (highScore < bestScore)
                        {
                            highScore = bestScore;
                        }
                    }
                    label10.Text = "High score: " + highScore.ToString();
                    cmd.Dispose();
                }
                conn.Close();
            }
        }

        private void playerVsComputer_FormClosing(object sender, FormClosingEventArgs e)
        {

            if(close == 0)
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    if (MessageBox.Show("Do you want to save data of this game",
                                   "Rock, Paper, Scissors",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        if (win == 0 && lose == 0)
                        {
                            close = 1;

                            form1.Show();
                            this.Close();
                        }
                        else
                        {
                            using (SQLiteConnection conn = new SQLiteConnection("data source = database-PC.db"))
                            {
                                conn.Open();


                                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                                {
                                    cmd.CommandText = "INSERT INTO scoreboard_PvC VALUES (NULL, (SELECT id FROM users WHERE user='" + user + "'), " + win + ", " + lose + ", " + score + ");";

                                    cmd.ExecuteNonQuery();

                                    cmd.Dispose();
                                }
                                conn.Close();
                            }
                            close = 1;

                            form1.Show();
                            this.Close();
                        }
                    }
                    else
                    {
                        close = 1;
                        form1.Show();
                        this.Close();
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            choose = 1;
            label4.Text = "ROCK";
            pictureBox1.BackColor = Color.Lime;
            pictureBox2.BackColor = Color.White;
            pictureBox3.BackColor = Color.White;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Silver;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            if(choose == 1)
            {
                pictureBox1.BackColor = Color.Lime;
            }
            else
            {
                pictureBox1.BackColor = Color.White;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            choose = 2;
            label4.Text = "PAPER";
            pictureBox2.BackColor = Color.Lime;
            pictureBox1.BackColor = Color.White;
            pictureBox3.BackColor = Color.White;
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Silver;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            if (choose == 2)
            {
                pictureBox2.BackColor = Color.Lime;
            }
            else
            {
                pictureBox2.BackColor = Color.White;
            }
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            choose = 3;
            label4.Text = "SCISSORS";
            pictureBox3.BackColor = Color.Lime;
            pictureBox2.BackColor = Color.White;
            pictureBox1.BackColor = Color.White;
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.Silver;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            if (choose == 3)
            {
                pictureBox3.BackColor = Color.Lime;
            }
            else
            {
                pictureBox3.BackColor = Color.White;
            }
        }

        int sec = 3;
        int win = 0;
        int lose = 0;
        int draw = 0;
        int score = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(sec == 0)
            {
                timer1.Stop();

                timeLeft.Text = "Seconds left: " + sec;

                pictureBox1.Enabled = false;
                pictureBox2.Enabled = false;
                pictureBox3.Enabled = false;

                Random random = new Random();
                int rnum = random.Next(1, 4);

                if (rnum == 1)
                {
                    pictureBox5.BackColor = Color.White;
                    if (choose == 1)
                    {
                        pictureBox4.BackColor = Color.Red;
                        pictureBox1.BackColor = Color.Lime;
                        label6.Text = "YOU WON";
                        label6.ForeColor = Color.Lime;
                        win++;
                    }
                    else if (choose == 2)
                    {
                        pictureBox4.BackColor = Color.Lime;
                        pictureBox2.BackColor = Color.Red;
                        label6.Text = "YOU LOST";
                        label6.ForeColor = Color.Red;
                        lose++;
                    }
                    else if (choose == 3)
                    {
                        pictureBox4.BackColor = Color.Silver;
                        pictureBox3.BackColor = Color.Silver;
                        label6.Text = "DRAW";
                        label6.ForeColor = Color.Gray;
                        draw++;
                    }
                    else
                    {
                        MessageBox.Show("You didn't pick anything!");
                    }
                }
                else if (rnum == 2)
                {
                    pictureBox5.BackColor = Color.White;
                    if (choose == 1)
                    {
                        pictureBox5.BackColor = Color.Lime;
                        pictureBox1.BackColor = Color.Red;
                        label6.Text = "YOU LOST";
                        label6.ForeColor = Color.Red;
                        lose++;
                    }
                    else if (choose == 2)
                    {
                        pictureBox5.BackColor = Color.Silver;
                        pictureBox2.BackColor = Color.Silver;
                        label6.Text = "DRAW";
                        label6.ForeColor = Color.Gray;
                        draw++;
                    }
                    else if (choose == 3)
                    {
                        pictureBox5.BackColor = Color.Red;
                        pictureBox3.BackColor = Color.Lime;
                        label6.Text = "YOU WON";
                        label6.ForeColor = Color.Lime;
                        win++;
                    }
                    else
                    {
                        MessageBox.Show("You didn't pick anything!");
                    }
                }
                else if (rnum == 3)
                {
                    pictureBox5.BackColor = Color.White;
                    if (choose == 1)
                    {
                        pictureBox6.BackColor = Color.Silver;
                        pictureBox1.BackColor = Color.Silver;
                        label6.Text = "DRAW";
                        label6.ForeColor = Color.Gray;
                        draw++;
                    }
                    else if (choose == 2)
                    {
                        pictureBox6.BackColor = Color.Red;
                        pictureBox5.BackColor = Color.White;
                        pictureBox2.BackColor = Color.Lime;
                        label6.Text = "YOU WON";
                        label6.ForeColor = Color.Lime;
                        win++;
                    }
                    else if (choose == 3)
                    {
                        pictureBox6.BackColor = Color.Lime;
                        pictureBox3.BackColor = Color.Red;
                        label6.Text = "YOU LOST";
                        label6.ForeColor = Color.Red;
                        lose++;
                    }
                    else
                    {
                        pictureBox5.BackColor = Color.White;
                        MessageBox.Show("You didn't pick anything!");
                    }
                }

                label8.Text = win + "           -             " + lose;
                score = win - lose;
                label9.Text = "Score: " + score.ToString();
                button1.Enabled = true;
                button2.Enabled = true;
            }
            else
            {
                timeLeft.Text = "Seconds left: " + sec;

                if(sec == 3)
                {
                    pictureBox6.BackColor = Color.Silver;
                }
                else if(sec == 2)
                {
                    pictureBox4.BackColor = Color.Silver;
                    pictureBox6.BackColor = Color.White;
                }
                else if(sec == 1)
                {
                    pictureBox5.BackColor = Color.Silver;
                    pictureBox4.BackColor = Color.White;
                }
                
                sec = sec - 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();

            choose = 0;

            sec = 3;

            pictureBox1.Enabled = true;
            pictureBox2.Enabled = true;
            pictureBox3.Enabled = true;

            pictureBox1.BackColor = Color.White;
            pictureBox2.BackColor = Color.White;
            pictureBox3.BackColor = Color.White;
            pictureBox4.BackColor = Color.White;
            pictureBox5.BackColor = Color.White;
            pictureBox6.BackColor = Color.White;

            label6.Text = "";

            button1.Enabled = false;
            button2.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (win==0&&lose==0)
            {
                close = 1;

                form1.Show();
                this.Close(); 
            }
            else
            {
                using (SQLiteConnection conn = new SQLiteConnection("data source = database-PC.db"))
                {
                    conn.Open();


                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = "INSERT INTO scoreboard_PvC VALUES (NULL, (SELECT id FROM users WHERE user='" + user + "'), " + win + ", " + lose + ", " + score + ");";

                        cmd.ExecuteNonQuery();

                        cmd.Dispose();
                    }
                    conn.Close();
                }
                close = 1;

                form1.Show();
                this.Close();
            }

        }
    }
}
