using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class StartingScreen : Form
    {
        SoundPlayer NiniMusic;
        public StartingScreen()
        {
            InitializeComponent();
            play_btn.BackColor = Color.Transparent;
            play_btn.Parent = Main_pic;
            NiniMusic = new SoundPlayer(Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"),@"resources\Nini.wav"));
            NiniMusic.Play();
        }

        private void StartingScreen_Load(object sender, EventArgs e)
        {

        }

        private void play_btn_clicked(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 myGameForm = new Form1(this);
            NiniMusic.Stop();
            myGameForm.Visible = true;
        }
    }
}
