using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class EndingScreen : Form
    {
        StartingScreen MainScreen;
        int[] ScoreArr;

        SoundPlayer llamaMusic;
        public EndingScreen(int[] ScoreArr, StartingScreen mainScreen, int myscore)
        {
            InitializeComponent();
            this.ScoreArr = ScoreArr;
            MainScreen = mainScreen;
            llamaMusic = new SoundPlayer(Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"), @"resources\Lama.wav"));
            yrscore.Text = "Your score: " + myscore;
            Dostuff();

        }

        private void EndingScreen_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EndingScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainScreen.Visible = true;
        }

        private void Dostuff()
        {

            yrscore.BackColor = Color.Transparent;
            yrscore.Parent = ending_pic;


            score_lbl1.Text = ScoreArr[0].ToString();
            score_lbl2.Text = ScoreArr[1].ToString();
            score_lbl3.Text = ScoreArr[2].ToString();
            score_lbl4.Text = ScoreArr[3].ToString();
            score_lbl5.Text = ScoreArr[4].ToString();
            score_lbl1.BackColor = Color.Transparent;
            score_lbl2.BackColor = Color.Transparent;
            score_lbl3.BackColor = Color.Transparent;
            score_lbl4.BackColor = Color.Transparent;
            score_lbl5.BackColor = Color.Transparent;

            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;
            label8.BackColor = Color.Transparent;

            score_lbl1.Parent = ScoreboardTable;
            score_lbl2.Parent = ScoreboardTable;
            score_lbl3.Parent = ScoreboardTable;
            score_lbl4.Parent = ScoreboardTable;
            score_lbl5.Parent = ScoreboardTable;

            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Parent = ending_pic;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Parent = ending_pic;


            ScoreboardTable.BackColor = Color.FromArgb(100, 255, 255, 255);
            ScoreboardTable.Parent = ending_pic;

            llamaMusic.Play();
        }
    }
}
