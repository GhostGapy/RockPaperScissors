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
    public partial class leaderboard2 : Form
    {
        private Form1 form1;
        public leaderboard2(Form1 form11)
        {
            InitializeComponent();
            form1 = form11;

            int bestScore=getBestScore();
            getTop5(bestScore);

            int biggestID = getBiggestID();
            latest5info(biggestID);
        }

        private int getBiggestID()
        {
            int biggestID = 0;
            using (SQLiteConnection conn = new SQLiteConnection("data source = database-PC.db"))
            {
                conn.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "SELECT * FROM scoreboard_PvP;";


                    //cmd.ExecuteNonQuery();

                    SQLiteDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int ID = reader.GetInt32(0);
                        int user_id = reader.GetInt32(1);
                        int wins = reader.GetInt32(2);
                        int loses = reader.GetInt32(3);
                        int score = reader.GetInt32(4);

                        if (ID > biggestID)
                        {
                            biggestID = ID;
                        }
                    }

                    cmd.Dispose();
                }
                conn.Close();
            }
            return biggestID;
        }

        private void latest5info(int biggestID)
        {
            string username1 = "";
            string username2 = "";
            using (SQLiteConnection conn = new SQLiteConnection("data source = database-PC.db"))
            {
                conn.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    for (int i = 5; i > 0; i--)
                    {
                        cmd.CommandText = "SELECT * FROM scoreboard_PvP WHERE ID=" + biggestID + ";";

                        SQLiteDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            int ID = reader.GetInt32(0);
                            int user1_id = reader.GetInt32(1);
                            int user2_id = reader.GetInt32(2);
                            int user1_wins = reader.GetInt32(3);
                            int user2_wins = reader.GetInt32(4);


                            if (i == 5)
                            {
                                username1 = getUser(user1_id);
                                latest1_user1.Text = username1;

                                username2 = getUser(user2_id);
                                latest1_user2.Text = username2;

                                label19.Text = "      " + user1_wins + "                                     -                                     " + user2_wins + "         ";
                            }
                            else if (i == 4)
                            {
                                username1 = getUser(user1_id);
                                latest2_user1.Text = username1;

                                username2 = getUser(user2_id);
                                latest2_user2.Text = username2;

                                label18.Text = "      " + user1_wins + "                                     -                                     " + user2_wins + "         ";
                            }
                            else if (i == 3)
                            {
                                username1 = getUser(user1_id);
                                latest3_user1.Text = username1;

                                username2 = getUser(user2_id);
                                latest3_user2.Text = username2;

                                label17.Text = "      " + user1_wins + "                                     -                                     " + user2_wins + "         ";
                            }
                            else if (i == 2)
                            {
                                username1 = getUser(user1_id);
                                latest4_user1.Text = username1;

                                username2 = getUser(user2_id);
                                latest4_user2.Text = username2;

                                label16.Text = "      " + user1_wins + "                                     -                                     " + user2_wins + "         ";
                            }
                            else if (i == 1)
                            {
                                username1 = getUser(user1_id);
                                latest5_user1.Text = username1;

                                username2 = getUser(user2_id);
                                latest5_user2.Text = username2;

                                label15.Text = "      " + user1_wins + "                                     -                                     " + user2_wins + "         ";
                            }
                        }
                        biggestID--;
                        reader.Close();
                    }
                    cmd.Dispose();
                }
                conn.Close();
            }

        }

        private string getUser(int user_id)
        {
            string username = "";

            using (SQLiteConnection conn = new SQLiteConnection("data source = database-PC.db"))
            {
                conn.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {

                    cmd.CommandText = "SELECT * FROM users WHERE ID=" + user_id + ";";

                    SQLiteDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        username = reader.GetString(1);
                    }
                    cmd.Dispose();
                }
                conn.Close();
            }
            return username;
        }

        private void leaderboard2_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private int getBestScore()
        {
            int bestScore = 0;
            using (SQLiteConnection conn = new SQLiteConnection("data source = database-PC.db"))
            {
                conn.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "SELECT * FROM scoreboard_PvP;";

                    //cmd.ExecuteNonQuery();

                    SQLiteDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int ID = reader.GetInt32(0);
                        int score = reader.GetInt32(5);

                        if (score > bestScore)
                        {
                            bestScore = score;
                        }
                    }

                    cmd.Dispose();
                }
                conn.Close();
            }
            return bestScore;
        }

        private void getTop5(int bestScore)
        {
            string username1 = "";
            string username2 = "";

            using (SQLiteConnection conn = new SQLiteConnection("data source = database-PC.db"))
            {
                conn.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    for (int i = 5; i > 0; i--)
                    {
                        cmd.CommandText = "SELECT * FROM scoreboard_PvP WHERE score=" + bestScore + ";";

                        SQLiteDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            int ID = reader.GetInt32(0);
                            int user1_id = reader.GetInt32(1);
                            int user2_id = reader.GetInt32(2);
                            int user1_wins = reader.GetInt32(3);
                            int user2_wins = reader.GetInt32(4);

                            if (i == 5)
                            {
                                username1 = getUser(user1_id);
                                top1_user1.Text = username1;

                                username2 = getUser(user2_id);
                                top1_user2.Text = username2;

                                top1.Text = "      " + user1_wins + "                                     -                                     " + user2_wins + "         ";
                            }
                            else if (i == 4)
                            {
                                username1 = getUser(user1_id);
                                top2_user1.Text = username1;

                                username2 = getUser(user2_id);
                                top2_user2.Text = username2;

                                top2.Text = "      " + user1_wins + "                                     -                                     " + user2_wins + "         ";
                            }
                            else if (i == 3)
                            {
                                username1 = getUser(user1_id);
                                top3_user1.Text = username1;

                                username2 = getUser(user2_id);
                                top3_user2.Text = username2;

                                top3.Text = "      " + user1_wins + "                                     -                                     " + user2_wins + "         ";
                            }
                            else if (i == 2)
                            {
                                username1 = getUser(user1_id);
                                top4_user1.Text = username1;

                                username2 = getUser(user2_id);
                                top4_user2.Text = username2;

                                top4.Text = "      " + user1_wins + "                                     -                                     " + user2_wins + "         ";
                            }
                            else if (i == 1)
                            {
                                username1 = getUser(user1_id);
                                top5_user1.Text = username1;

                                username2 = getUser(user2_id);
                                top5_user2.Text = username2;

                                top5.Text = "      " + user1_wins + "                                     -                                     " + user2_wins + "         ";
                            }
                            bestScore++;
                        }
                        else
                        {
                            i++;
                        }
                        bestScore--;
                        cmd.Dispose();
                    }
                }
                conn.Close();
            }
        }
    }
}
