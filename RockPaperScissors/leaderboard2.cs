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
        }

        private void leaderboard2_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
