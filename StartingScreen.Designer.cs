namespace test
{
    partial class StartingScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartingScreen));
            Main_pic = new PictureBox();
            play_btn = new Panel();
            ((System.ComponentModel.ISupportInitialize)Main_pic).BeginInit();
            SuspendLayout();
            // 
            // Main_pic
            // 
            Main_pic.Dock = DockStyle.Fill;
            Main_pic.Image = (Image)resources.GetObject("Main_pic.Image");
            Main_pic.Location = new Point(0, 0);
            Main_pic.Name = "Main_pic";
            Main_pic.Size = new Size(409, 516);
            Main_pic.SizeMode = PictureBoxSizeMode.StretchImage;
            Main_pic.TabIndex = 0;
            Main_pic.TabStop = false;
            // 
            // play_btn
            // 
            play_btn.BackColor = SystemColors.Control;
            play_btn.Location = new Point(138, 314);
            play_btn.Name = "play_btn";
            play_btn.Size = new Size(131, 69);
            play_btn.TabIndex = 1;
            play_btn.Click += play_btn_clicked;
            // 
            // StartingScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(409, 516);
            Controls.Add(play_btn);
            Controls.Add(Main_pic);
            Name = "StartingScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StartingScreen";
            Load += StartingScreen_Load;
            ((System.ComponentModel.ISupportInitialize)Main_pic).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox Main_pic;
        private Panel play_btn;
    }
}