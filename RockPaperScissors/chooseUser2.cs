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
    public partial class chooseUser2 : Form
    {
        private Form1 form1;

        public chooseUser2(Form1 form11)
        {
            InitializeComponent();

            form1 = form11;

            textBox1.Text = "Gapy";
            textBox2.Text = "Lojze";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection("data source = database-PC.db"))
            {
                conn.Open();

                string user1 = "";
                string user2 = "";
                int check = 0;
                int x = 0;

                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Insert both player names!");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    check = 1;
                    x = 1;
                }
                if (textBox1.Text != textBox2.Text)
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = "SELECT * FROM users;";

                        //cmd.ExecuteNonQuery();

                        SQLiteDataReader reader = cmd.ExecuteReader();

                        int check1 = 0;
                        int check2 = 0;

                        while (reader.Read() && check1 == 0)
                        {
                            int ID1 = reader.GetInt32(0);
                            string userTry = reader.GetString(1);

                            if (textBox1.Text == userTry)
                            {
                                check1 = 1;
                                user1 = userTry;
                            }
                            if (textBox2.Text == userTry)
                            {
                                check2 = 1;
                                user2 = userTry;
                            }
                        }
                        if (check1 == 0 && check2 == 0)
                        {
                            reader.Close();

                            for (int i = 0; i < 2; i++)
                            {
                                user2 = textBox2.Text;
                                user1 = textBox1.Text;
                                if (i == 0)
                                {
                                    cmd.CommandText = "INSERT INTO users  VALUES (NULL, '" + user1 + "');";
                                    cmd.ExecuteNonQuery();
                                }
                                else if (i == 1)
                                {
                                    cmd.CommandText = "INSERT INTO users  VALUES (NULL, '" + user2 + "');";
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        else if (check1 == 0 && check2 == 1)
                        {
                            reader.Close();
                            user2 = textBox2.Text;
                            user1 = textBox1.Text;

                            cmd.CommandText = "INSERT INTO users  VALUES (NULL, '" + user1 + "');";
                            cmd.ExecuteNonQuery();
                        }
                        else if (check1 == 1 && check2 == 0)
                        {
                            reader.Close();
                            user1 = textBox1.Text;
                            user2 = textBox2.Text;

                            cmd.CommandText = "INSERT INTO users  VALUES (NULL, '" + user2 + "');";
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            user1 = textBox1.Text;
                            user2 = textBox2.Text;
                            reader.Close();
                        }
                        cmd.Dispose();
                    }
                    check = 0;
                }
                else
                {
                    if (x == 0)
                    {
                        MessageBox.Show("You can't have two same users playing the game!");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        check = 1; 
                    }
                }
                conn.Close();

                if (check == 0)
                {
                    playerVsPlayer nov1 = new playerVsPlayer(user1, user2, form1);
                    nov1.Show();

                    this.Hide();
                }
            }
        }
    }
}
