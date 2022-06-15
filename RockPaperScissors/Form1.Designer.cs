namespace RockPaperScissors
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.play = new System.Windows.Forms.Button();
            this.leaderboard1 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.leaderboard2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(41, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(530, 57);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rock, Paper, Scissors";
            // 
            // play
            // 
            this.play.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.play.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.play.Location = new System.Drawing.Point(78, 189);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(215, 46);
            this.play.TabIndex = 2;
            this.play.Text = "Player VS Computer";
            this.play.UseVisualStyleBackColor = true;
            this.play.Click += new System.EventHandler(this.play_Click);
            // 
            // leaderboard1
            // 
            this.leaderboard1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.leaderboard1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leaderboard1.Location = new System.Drawing.Point(112, 241);
            this.leaderboard1.Name = "leaderboard1";
            this.leaderboard1.Size = new System.Drawing.Size(151, 46);
            this.leaderboard1.TabIndex = 4;
            this.leaderboard1.Text = "Leaderboard";
            this.leaderboard1.UseVisualStyleBackColor = true;
            this.leaderboard1.Click += new System.EventHandler(this.leaderboard1_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(315, 189);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(215, 46);
            this.button1.TabIndex = 6;
            this.button1.Text = "Player VS Player";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // leaderboard2
            // 
            this.leaderboard2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.leaderboard2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leaderboard2.Location = new System.Drawing.Point(344, 241);
            this.leaderboard2.Name = "leaderboard2";
            this.leaderboard2.Size = new System.Drawing.Size(151, 46);
            this.leaderboard2.TabIndex = 7;
            this.leaderboard2.Text = "Leaderboard";
            this.leaderboard2.UseVisualStyleBackColor = true;
            this.leaderboard2.Click += new System.EventHandler(this.leaderboard2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::RockPaperScissors.Properties.Resources.BackgroundImage2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(607, 440);
            this.Controls.Add(this.leaderboard2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.leaderboard1);
            this.Controls.Add(this.play);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = " Kamen, Škarje, Papir";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button play;
        private System.Windows.Forms.Button leaderboard1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button leaderboard2;
    }
}

