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
    public partial class playerVsPlayer : Form
    {
        private Form1 form1;
        string user1 = "";
        string user2 = "";
        int choose1 = 0;
        int choose2 = 0;
        int close = 0;

        int sec = 3;
        int user1_wins = 0;
        int user2_wins = 0;
        int draw = 0;
        int score = 0;

        public playerVsPlayer(string userName1, string userName2, Form1 form11)
        {
            InitializeComponent();

            user1 = userName1;
            user2 = userName2;

            label1.Text = user1 + " pick: ";
            label2.Text = user2 + " pick: ";

            label7.Text = user1 + "        VS        " + user2;

            form1 = form11;
        }

        private void playerVsPlayer_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    {
                        choose1 = 3;
                        break;
                    }
                case Keys.S:
                    {
                        choose1 = 2;
                        break;
                    }
                case Keys.A:
                    {
                        choose1 = 1;
                        break;
                    }
                case Keys.L:
                    {
                        choose2 = 3;
                        break;
                    }
                case Keys.K:
                    {
                        choose2 = 2;
                        break;
                    }
                case Keys.J:
                    {
                        choose2 = 1;
                        break;
                    }
            }
        }

        private void playerVsPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close == 0)
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    if (MessageBox.Show("Do you want to save data of this game",
                                   "Rock, Paper, Scissors",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        if (user1_wins == 0 && user2_wins == 0)
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
                                    cmd.CommandText = "INSERT INTO scoreboard_PvP VALUES (NULL, (SELECT id FROM users WHERE user='" + user1 + "'), (SELECT id FROM users WHERE user='" + user2 + "'), " + user1_wins + ", " + user2_wins + ", " + score + ");";

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sec == 0)
            {
                timer1.Stop();

                timeLeft.Text = "Seconds left: " + sec;

                if (choose1 == 1)
                {
                    if (choose2 == 1)
                    {
                        pictureBox1.BackColor = Color.Silver;
                        pictureBox6.BackColor = Color.Silver;
                        label6.Text = "DRAW";
                        label6.ForeColor = Color.Gray;
                        draw++;
                    }
                    else if (choose2 == 2)
                    {
                        pictureBox1.BackColor = Color.Red;
                        pictureBox5.BackColor = Color.Lime;
                        label6.Text = user2 + " WON!";
                        label6.ForeColor = Color.Red;
                        user2_wins++;
                    }
                    else if (choose2 == 3)
                    {
                        pictureBox1.BackColor = Color.Lime;
                        pictureBox4.BackColor = Color.Red;
                        label6.Text = user1 + " WON!";
                        label6.ForeColor = Color.Lime;
                        user1_wins++;
                    }
                    else
                    {
                        MessageBox.Show(user2 + " didn't pick anything!");
                    }
                }
                else if (choose1 == 2)
                {
                    if (choose2 == 1)
                    {
                        pictureBox2.BackColor = Color.Lime;
                        pictureBox6.BackColor = Color.Red;
                        label6.Text = user1 + " WON!";
                        label6.ForeColor = Color.Lime;
                        user1_wins++;
                    }
                    else if (choose2 == 2)
                    {
                        pictureBox2.BackColor = Color.Silver;
                        pictureBox5.BackColor = Color.Silver;
                        label6.Text = "DRAW";
                        label6.ForeColor = Color.Gray;
                        draw++;
                    }
                    else if (choose2 == 3)
                    {
                        pictureBox2.BackColor = Color.Red;
                        pictureBox4.BackColor = Color.Lime;
                        label6.Text = user2 + " WON!";
                        label6.ForeColor = Color.Lime;
                        user2_wins++;
                    }
                    else
                    {
                        MessageBox.Show(user2 + " didn't pick anything!");
                    }
                }
                else if (choose1 == 3)
                {
                    if (choose2 == 1)
                    {
                        pictureBox3.BackColor = Color.Red;
                        pictureBox6.BackColor = Color.Lime;
                        label6.Text = user2 + " WON!";
                        label6.ForeColor = Color.Red;
                        user2_wins++;
                    }
                    else if (choose2 == 2)
                    {
                        pictureBox3.BackColor = Color.Lime;
                        pictureBox5.BackColor = Color.Red;
                        label6.Text = user1 + " WON!";
                        label6.ForeColor = Color.Lime;
                        user1_wins++;
                    }
                    else if (choose2 == 3)
                    {
                        pictureBox3.BackColor = Color.Silver;
                        pictureBox4.BackColor = Color.Silver;
                        label6.Text = "DRAW";
                        label6.ForeColor = Color.Gray;
                        draw++;
                    }
                    else
                    {
                        MessageBox.Show(user2 + " didn't pick anything!");
                    }
                }
                else
                {
                    MessageBox.Show(user1 + " didn't pick anything!");
                }

                label8.Text = user1_wins + "           -             " + user2_wins;

                score = Math.Abs(user1_wins - user2_wins);

                label9.Text = "Score: " + score.ToString();
                button1.Enabled = true;
                button2.Enabled = true;
            }
            else
            {
                timeLeft.Text = "Seconds left: " + sec;

                sec = sec - 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();

            choose1 = 0;
            choose2 = 0;

            sec = 3;

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
            if (user1_wins == 0 && user2_wins == 0)
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
                        cmd.CommandText = "INSERT INTO scoreboard_PvP VALUES (NULL, (SELECT id FROM users WHERE user='" + user1 + "'), (SELECT id FROM users WHERE user='" + user2 + "'), " + user1_wins + ", " + user2_wins + ", " + score + ");";

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
