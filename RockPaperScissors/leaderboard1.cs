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
    public partial class leaderboard1 : Form
    {
        private Form1 form1;
        public leaderboard1(Form1 form11)
        {
            InitializeComponent();
            form1 = form11;

            int bestScore = getBestScore();
            getTop5(bestScore);

            int biggestID= getBiggestID();
            latest5info(biggestID);
        }

        private void leaderboard1_FormClosing(object sender, FormClosingEventArgs e)
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
                    cmd.CommandText = "SELECT * FROM scoreboard_PvC;";


                    //cmd.ExecuteNonQuery();

                    SQLiteDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int ID = reader.GetInt32(0);
                        int user_id = reader.GetInt32(1);
                        int wins = reader.GetInt32(2);
                        int loses = reader.GetInt32(3);
                        int score = reader.GetInt32(4);

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

        private int getBiggestID()
        {
            int biggestID = 0;
            using (SQLiteConnection conn = new SQLiteConnection("data source = database-PC.db"))
            {
                conn.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "SELECT * FROM scoreboard_PvC;";


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

        private void getTop5(int bestScore)
        {
            string username = "";

            using (SQLiteConnection conn = new SQLiteConnection("data source = database-PC.db"))
            {
                conn.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    for (int i = 5; i > 0; i--)
                    {
                        cmd.CommandText = "SELECT * FROM scoreboard_PvC WHERE score=" + bestScore + ";";

                        SQLiteDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            int ID = reader.GetInt32(0);
                            int user_id = reader.GetInt32(1);
                            int wins = reader.GetInt32(2);
                            int loses = reader.GetInt32(3);
                            int score = reader.GetInt32(4);

                            if (i == 5)
                            {
                                username = getUser(user_id);
                                top1_user1.Text = username;
                                top1.Text = "      " + wins + "                                     -                                     " + loses + "         ";
                            }
                            else if (i == 4)
                            {
                                username = getUser(user_id);
                                top2_user1.Text = username;
                                top2.Text = "      " + wins + "                                     -                                     " + loses + "         ";
                            }
                            else if (i == 3)
                            {
                                username = getUser(user_id);
                                top3_user1.Text = username;
                                top3.Text = "      " + wins + "                                     -                                     " + loses + "         ";
                            }
                            else if (i == 2)
                            {
                                username = getUser(user_id);
                                top4_user1.Text = username;
                                top4.Text = "      " + wins + "                                     -                                     " + loses + "         ";
                            }
                            else if (i == 1)
                            {
                                username = getUser(user_id);
                                top5_user1.Text = username;
                                top5.Text = "      " + wins + "                                     -                                     " + loses + "         ";
                            }
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

        private void latest5info(int biggestID)
        {
            using (SQLiteConnection conn = new SQLiteConnection("data source = database-PC.db"))
            {
                conn.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    for (int i = 5; i > 0; i--)
                    {
                        cmd.CommandText = "SELECT * FROM scoreboard_PvC WHERE ID=" + biggestID + ";";

                        SQLiteDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            int ID = reader.GetInt32(0);
                            int user_id = reader.GetInt32(1);
                            int wins = reader.GetInt32(2);
                            int loses = reader.GetInt32(3);
                            int score = reader.GetInt32(4);

                            string username = "";

                            if (i == 5)
                            {
                                username = getUser(user_id);
                                latest1_user.Text = username;
                                label19.Text = "      " + wins + "                                     -                                     " + loses + "         ";
                            }
                            else if (i == 4)
                            {
                                username = getUser(user_id);
                                latest2_user.Text = username;
                                label18.Text = "      " + wins + "                                     -                                     " + loses + "         ";
                            }
                            else if (i == 3)
                            {
                                username = getUser(user_id);
                                latest3_user.Text = username;
                                label17.Text = "      " + wins + "                                     -                                     " + loses + "         ";
                            }
                            else if (i == 2)
                            {
                                username = getUser(user_id);
                                latest4_user.Text = username;
                                label16.Text = "      " + wins + "                                     -                                     " + loses + "         ";
                            }
                            else if (i == 1)
                            {
                                username = getUser(user_id);
                                latest5_user.Text = username;
                                label15.Text = "      " + wins + "                                     -                                     " + loses + "         ";
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
    }
}
