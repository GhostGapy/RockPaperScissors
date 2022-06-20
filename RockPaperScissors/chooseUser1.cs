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
    public partial class chooseUser1 : Form
    {

        private Form1 form1;

        public chooseUser1(Form1 form11)
        {
            InitializeComponent();

            highScore();

            form1 = form11;
        }

        private void highScore()
        {
            using (SQLiteConnection conn = new SQLiteConnection("data source = database-PC.db"))
            {
                conn.Open();


                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "SELECT * FROM scoreboard_PvC;";

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
                    label1.Text = "Highest score is: " + highScore.ToString();
                    cmd.Dispose();
                }
                conn.Close();
            }
        }

        private void chooseUser1_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Show();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection("data source = database-PC.db"))
            {
                conn.Open();

                int ID = 0;
                string user = "";
                int check = 0;

                if (textBox1.Text != "")
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = "SELECT * FROM users;";

                        //cmd.ExecuteNonQuery();

                        SQLiteDataReader reader = cmd.ExecuteReader();

                        while (reader.Read() && check == 0)
                        {
                            ID = reader.GetInt32(0);
                            user = reader.GetString(1);

                            if (textBox1.Text == user)
                            {
                                check = 1;
                            }
                        }
                        if (check == 0)
                        {
                            reader.Close();
                            user = textBox1.Text;

                            cmd.CommandText = "INSERT INTO users  VALUES (NULL, '" + user + "');";
                            cmd.ExecuteNonQuery();
                        }
                        cmd.Dispose();
                    } 
                    check = 0;
                }
                else
                {
                    MessageBox.Show("Insert player name!");
                    textBox1.Text = "";
                    check = 1;
                }
                conn.Close();

                if (check==0)
                {
                    playerVsComputer nov = new playerVsComputer(user, ID, form1);
                    nov.Show();

                    this.Hide(); 
                }
            }
        }
    }
}
