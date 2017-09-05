using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Russian_Roulette_2
{
    public partial class Form2 : Form
    {
        int bullet;
        int shot;
        int go = 7;
        int away = 1;
        string Player;
        int Score = 10;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Set form so only the correct  sections work and lables are transperent
            this.lbPlayerName.BackColor = System.Drawing.Color.Transparent;
            this.lbScore.BackColor = System.Drawing.Color.Transparent;
            this.lbShotsLeft.BackColor = System.Drawing.Color.Transparent;
            btnPlayer.Enabled = false;
            btnAway.Enabled = false;
            btnNewPlayer.Enabled = false;
            btnPlayAgain.Enabled = false;

            btnSpinChambers.Enabled = false;
            shot = go -1;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // If player name empty dont save score. If populated save score to csv
            Player = txtPlayerName.Text;
            Score = Convert.ToInt16(txtScore.Text);
            if (txtPlayerName.Text == "")
            {
                this.Close();
            }
            else try
            {
                string path = @"Russian Roulette 2.Resources.PlayerScore.csv";

                if (!File.Exists(path))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine(Player + "," + Score);
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(Player + "," + Score);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("File seems tp be missing. Please check path");
            }
            txtPlayerName.Clear();
            txtScore.Clear();

            this.Close();
            var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Form1);
            if (formToShow != null)
            {
                formToShow.Show();
            }
        }

        private void pbShot1_Click(object sender, EventArgs e)
        {

        }

        private void btnSpinChambers_Click(object sender, EventArgs e)
        {
            // Enable player and away
            btnPlayer.Enabled = true;
            btnAway.Enabled = true;

            // Random Bullet 1 - 6
            Random rnd = new Random();
            bullet = rnd.Next(1,7);

            // For Testing purposes
            //MessageBox.Show(bullet.ToString());

            // Play Revolution sound
            System.IO.Stream str = Properties.Resources.LoadChambers;
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
            snd.Play();

            //Disable Buttons not needed at this point.
            btnSpinChambers.Enabled = false;
        }

        private void btnLoadBullet_Click(object sender, EventArgs e)
        {
            // Display error if player name not present
            if (txtPlayerName.Text == "")
            {
                MessageBox.Show("Please enter Player Name");
                return;
            }
            else btnSpinChambers.Enabled = true;

            //Play Load bullet Sound
            System.IO.Stream str = Properties.Resources.LoadBullet;
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
            snd.Play();
            //Disable Buttons not needed at this point.
            btnLoadBullet.Enabled = false;
            txtPlayerName.Enabled = false;
        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            // Reset form for player to bea able to play again. Leave name and score.
            btnPlayer.Enabled = false;
            btnAway.Enabled = false;
            pbShot1.Visible = true;
            pbShot2.Visible = true;
            pbShot3.Visible = true;
            pbShot4.Visible = true;
            pbShot5.Visible = true;
            pbShot6.Visible = true;
            go = 7;
            away = 1;
            btnSpinChambers.Enabled = false;
            btnNewPlayer.Enabled = false;
            btnPlayAgain.Enabled = false;
            btnLoadBullet.Enabled = true;
        }

        private void btnPlayer_Click(object sender, EventArgs e)
        {
            //Score
            Score = Convert.ToInt16(txtScore.Text);

            //Play Gunshot Sound
            System.IO.Stream str = Properties.Resources.Gunshot;
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
            snd.Play();

            //Remove Bullet / Shot + add score
            if (go >= 1)
            {
                go = go - 1;
            }
            if (go == 6)
            {
                pbShot6.Visible = false;
                txtScore.Text = (Score + 100).ToString();
            }
            if (go == 5)
            {
                pbShot5.Visible = false;
                txtScore.Text = (Score + 100).ToString();
            }
            if (go == 4)
            {
                pbShot4.Visible = false;
                txtScore.Text = (Score + 100).ToString();
            }
            if (go == 3)
            {
                pbShot3.Visible = false;
                txtScore.Text = (Score + 100).ToString();
            }
            if (go == 2)
            {
                pbShot2.Visible = false;
                txtScore.Text = (Score + 100).ToString();
            }
            if (go == 1)
            {
                pbShot1.Visible = false;
                txtScore.Text = (Score + 100).ToString();
            }
            if (go == bullet)
            {
                txtScore.Text = (Score - 500).ToString();
                MessageBox.Show("YOU ARE DEAD!!");
                btnPlayer.Enabled = false;
                btnAway.Enabled = false;
                btnNewPlayer.Enabled = true;
                btnPlayAgain.Enabled = true;
            }
        }

        private void btnAway_Click(object sender, EventArgs e)
        {
            //Score
            Score = Convert.ToInt16(txtScore.Text);
            //Play Gunshot Sound
            System.IO.Stream str = Properties.Resources.Gunshot;
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
            snd.Play();

            //Remove Bullet / Shot + add score
            if (go >= 1)
            {
                go = go - 1;
            }
            if (go == 6)
            {
                pbShot6.Visible = false;
                txtScore.Text = (Score + 100).ToString();
            }
            if (go == 5)
            {
                pbShot5.Visible = false;
                txtScore.Text = (Score + 100).ToString();
            }
            if (go == 4)
            {
                pbShot4.Visible = false;
                txtScore.Text = (Score + 100).ToString();
            }
            if (go == 3)
            {
                pbShot3.Visible = false;
                txtScore.Text = (Score + 100).ToString();
            }
            if (go == 2)
            {
                pbShot2.Visible = false;
                txtScore.Text = (Score + 100).ToString();
            }
            if (go == 1)
            {
                pbShot1.Visible = false;
                txtScore.Text = (Score + 100).ToString();
            }
            if (go == bullet)
            {
                txtScore.Text = (Score + 1000).ToString();
                MessageBox.Show("***YOU BAGGED YOURSELF A STAG***");
                btnPlayer.Enabled = false;
                btnAway.Enabled = false;
                btnNewPlayer.Enabled = true;
                btnPlayAgain.Enabled = true;
            }
            // Set Away to 2 shots only
            if (away == 0)
            {
                btnAway.Enabled = false;
            }
            if (away >= 1)
            {
                away = away - 1;
            }
        }

        private void btnNewPlayer_Click(object sender, EventArgs e)
        {
            //Resetting form in sections.
            btnPlayer.Enabled = false;
            btnAway.Enabled = false;
            pbShot1.Visible = true;
            pbShot2.Visible = true;
            pbShot3.Visible = true;
            pbShot4.Visible = true;
            pbShot5.Visible = true;
            pbShot6.Visible = true;
            go = 7;
            away = 1;
            btnSpinChambers.Enabled = false;
            btnPlayAgain.Enabled = false;
            btnNewPlayer.Enabled = false;
            btnLoadBullet.Enabled = true;
            txtPlayerName.Enabled = true;
            // Save players score+name to csv
            Player = txtPlayerName.Text;
            Score = Convert.ToInt16(txtScore.Text);
            try
            {
                string path = @"Russian Roulette 2.Resources.PlayerScore.csv";

                if (!File.Exists(path))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine(Player + "," + Score);
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(Player + "," + Score);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("File seems tp be missing. Please check path");
            }
            // Set score to 0 and player name ready for next player.
            txtPlayerName.Clear();
            int KK;
            KK = 0;
            txtScore.Text = (KK).ToString();
        }

        private void pbShot6_Click(object sender, EventArgs e)
        {

        }

        private void lbPlayerName_Click(object sender, EventArgs e)
        {

        }

        private void txtScore_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPlayerName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
