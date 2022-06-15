using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RockPaperScissors
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void play_Click(object sender, EventArgs e)
        {
            chooseUser1 nov = new chooseUser1(this);
            nov.Show();

            this.Hide();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("You really wanna close this game?",
                               "Rock, Paper, Scissors",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Information) == DialogResult.OK)
                    Application.Exit();
                else
                    e.Cancel = true; // to don't close form is user change his mind
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chooseUser2 nov = new chooseUser2(this);
            nov.Show();

            this.Hide();
        }

        private void leaderboard1_Click(object sender, EventArgs e)
        {
            leaderboard1 nov = new leaderboard1(this);
            nov.Show();

            this.Hide();
        }

        private void leaderboard2_Click(object sender, EventArgs e)
        {
            leaderboard2 nov = new leaderboard2(this);
            nov.Show();

            this.Hide();
        }
    }
}
