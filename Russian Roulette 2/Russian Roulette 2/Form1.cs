using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Russian_Roulette_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dsgHighscores.SortCompare += DsgHighscores_SortCompare;
        }

        private void DsgHighscores_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if(e.Column.Index == 1)
            {
                e.SortResult = int.Parse(e.CellValue1.ToString()).CompareTo(int.Parse(e.CellValue2.ToString()));
                e.Handled = true;//pass by the default sorting
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Setup Page, Hide Scores and make heading background invisible
            this.label1.BackColor = System.Drawing.Color.Transparent;
            dsgHighscores.Visible = false;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //Close this Form Load instructions Form
            this.Hide();
            Instructions g = new Instructions();
            g.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //Exit Game
            this.Close();
        }

        private void btnPLAY_Click(object sender, EventArgs e)
        {
            // Close this Form load game Form
            this.Hide();
            Form2 g = new Form2();
            g.ShowDialog();
        }

        private void btnHighscore_Click(object sender, EventArgs e)
        {
            // Reset scores and toggles scores box
            dsgHighscores.Rows.Clear();

            if (dsgHighscores.Visible == true)
                dsgHighscores.Visible = false;
            else
                dsgHighscores.Visible = true;

            // Populate Scores box
            string path = @"Russian Roulette 2.Resources.PlayerScore.csv";
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] split = line.Split(',');
                        dsgHighscores.Rows.Add(split[0], split[1]);
                    }
                }
            }

            dsgHighscores.Sort(dsgHighscores.Columns[1], ListSortDirection.Descending);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
