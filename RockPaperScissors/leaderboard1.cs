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

            top5();
        }

        private void leaderboard1_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void top5()
        {
            using (SQLiteConnection conn = new SQLiteConnection("data source = database-PC.db"))
            {
                conn.Open();


                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "SELECT * FROM scoreboard_PvC;";

                    //cmd.ExecuteNonQuery();

                    SQLiteDataReader reader = cmd.ExecuteReader();
                    int biggestID = 0;

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
                    label1.Text = "Highest score is: " + biggestID.ToString();


                    for (int i = 5; i > 0; i--)
                    {
                        cmd.CommandText = "SELECT * FROM scoreboard_PvC WHERE ID=" + biggestID + ";";

                        //cmd.ExecuteNonQuery();

                        SQLiteDataReader reader2 = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            int ID = reader2.GetInt32(0);
                            int user_id = reader2.GetInt32(1);
                            int wins = reader2.GetInt32(2);
                            int loses = reader2.GetInt32(3);
                            int score = reader2.GetInt32(4);

                            
                        }
                        biggestID--;
                    }
                    
                    cmd.Dispose();
                }
                conn.Close();
            }
        }
    }
}
