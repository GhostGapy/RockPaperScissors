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
        int win = 0;
        int lose = 0;
        int draw = 0;
        int score = 0;

        public playerVsPlayer(string userName1, string userName2, Form1 form11)
        {
            InitializeComponent();

            user1 = userName1;
            user2 = userName2;

            label1.Text = user1 + " pick: ";
            label2.Text = user2 + " pick: ";

            form1 = form11;
        }

        private void playerVsComputer_FormClosing(object sender, FormClosingEventArgs e)
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
                                    cmd.CommandText = "INSERT INTO scoreboard_PvC VALUES (NULL, (SELECT id FROM users WHERE user='" + user1 + "'), " + win + ", " + lose + ", " + score + ");";

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

            if (choose1 == 1)
            {
                //Player1 ROCK
                label4.Text = "ROCK";
            }
            else if(choose1 == 2)
            {
                //Player1 PAPER
                label4.Text = "PAPER";
            }
            else if (choose1 == 3)
            {
                //Player1 SCISSORS
                label4.Text = "SCISSORS";
            }
            

            if (choose2 == 1)
            {
                //Player2 ROCK
                label5.Text = "rock";
            }
            else if (choose2 == 2)
            {
                //Player2 PAPER
                label5.Text = "paper";
            }
            else if (choose2 == 3)
            {
                //Player1 SCISSORS
                label5.Text = "scissors";
            }
        }
    }
}
