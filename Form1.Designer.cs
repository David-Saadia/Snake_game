namespace test
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            map = new PictureBox();
            gameTimer = new System.Windows.Forms.Timer(components);
            X_btn = new PictureBox();
            pause_btn = new PictureBox();
            panel1 = new Panel();
            Score_Label = new Label();
            special = new System.Windows.Forms.Timer(components);
            instructionPanel = new Panel();
            btn_continue = new Button();
            lbl_How_Desc = new Label();
            lbl_HowToPlay = new Label();
            lbl_Controls_Desc = new Label();
            lbl_Controls = new Label();
            lbl_Instructions = new Label();
            ((System.ComponentModel.ISupportInitialize)map).BeginInit();
            ((System.ComponentModel.ISupportInitialize)X_btn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pause_btn).BeginInit();
            panel1.SuspendLayout();
            instructionPanel.SuspendLayout();
            SuspendLayout();
            // 
            // map
            // 
            map.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            map.BackColor = Color.DarkSeaGreen;
            map.Location = new Point(12, 60);
            map.Name = "map";
            map.Size = new Size(803, 385);
            map.SizeMode = PictureBoxSizeMode.StretchImage;
            map.TabIndex = 0;
            map.TabStop = false;
            map.Paint += updateGraphics;
            // 
            // gameTimer
            // 
            gameTimer.Interval = 30;
            gameTimer.Tick += GameTime;
            // 
            // X_btn
            // 
            X_btn.Image = (Image)resources.GetObject("X_btn.Image");
            X_btn.Location = new Point(67, 3);
            X_btn.Name = "X_btn";
            X_btn.Size = new Size(41, 41);
            X_btn.SizeMode = PictureBoxSizeMode.Zoom;
            X_btn.TabIndex = 1;
            X_btn.TabStop = false;
            X_btn.Click += X_Click;
            // 
            // pause_btn
            // 
            pause_btn.Image = (Image)resources.GetObject("pause_btn.Image");
            pause_btn.Location = new Point(20, 3);
            pause_btn.Name = "pause_btn";
            pause_btn.Size = new Size(41, 41);
            pause_btn.SizeMode = PictureBoxSizeMode.Zoom;
            pause_btn.TabIndex = 2;
            pause_btn.TabStop = false;
            pause_btn.Click += Pause_click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel1.Controls.Add(pause_btn);
            panel1.Controls.Add(X_btn);
            panel1.Location = new Point(714, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(119, 52);
            panel1.TabIndex = 3;
            // 
            // Score_Label
            // 
            Score_Label.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point);
            Score_Label.ForeColor = SystemColors.Control;
            Score_Label.Location = new Point(12, 9);
            Score_Label.Name = "Score_Label";
            Score_Label.Size = new Size(202, 45);
            Score_Label.TabIndex = 3;
            Score_Label.Text = "Score: 0";
            // 
            // special
            // 
            special.Interval = 10000;
            special.Tick += SpecialBurgerTimer;
            // 
            // instructionPanel
            // 
            instructionPanel.Anchor = AnchorStyles.None;
            instructionPanel.Controls.Add(btn_continue);
            instructionPanel.Controls.Add(lbl_How_Desc);
            instructionPanel.Controls.Add(lbl_HowToPlay);
            instructionPanel.Controls.Add(lbl_Controls_Desc);
            instructionPanel.Controls.Add(lbl_Controls);
            instructionPanel.Controls.Add(lbl_Instructions);
            instructionPanel.Location = new Point(106, 70);
            instructionPanel.Name = "instructionPanel";
            instructionPanel.Size = new Size(621, 335);
            instructionPanel.TabIndex = 4;
            // 
            // btn_continue
            // 
            btn_continue.BackColor = Color.ForestGreen;
            btn_continue.BackgroundImageLayout = ImageLayout.Center;
            btn_continue.FlatAppearance.BorderColor = Color.Black;
            btn_continue.FlatAppearance.BorderSize = 0;
            btn_continue.FlatStyle = FlatStyle.Popup;
            btn_continue.Font = new Font("Arial Black", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_continue.Location = new Point(233, 270);
            btn_continue.Name = "btn_continue";
            btn_continue.Size = new Size(147, 44);
            btn_continue.TabIndex = 2;
            btn_continue.Text = "Continue";
            btn_continue.UseVisualStyleBackColor = false;
            btn_continue.Click += btn_Continue_Click;
            // 
            // lbl_How_Desc
            // 
            lbl_How_Desc.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_How_Desc.ForeColor = SystemColors.Control;
            lbl_How_Desc.Location = new Point(88, 107);
            lbl_How_Desc.Name = "lbl_How_Desc";
            lbl_How_Desc.Size = new Size(200, 141);
            lbl_How_Desc.TabIndex = 1;
            lbl_How_Desc.Text = "Get as many points without crashing into your own body or eating a bad burger.\r\n\r\nBurger index:\r\nRegular — 1 point\r\nBlue burger — 5 points\r\nRed burger — (-5) points\r\nGrey burger — Game over.";
            lbl_How_Desc.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_HowToPlay
            // 
            lbl_HowToPlay.Font = new Font("Arial", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            lbl_HowToPlay.ForeColor = SystemColors.Control;
            lbl_HowToPlay.Location = new Point(134, 84);
            lbl_HowToPlay.Name = "lbl_HowToPlay";
            lbl_HowToPlay.Size = new Size(119, 23);
            lbl_HowToPlay.TabIndex = 1;
            lbl_HowToPlay.Text = "How to play:";
            // 
            // lbl_Controls_Desc
            // 
            lbl_Controls_Desc.FlatStyle = FlatStyle.Flat;
            lbl_Controls_Desc.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Controls_Desc.ForeColor = SystemColors.Control;
            lbl_Controls_Desc.Location = new Point(357, 107);
            lbl_Controls_Desc.Name = "lbl_Controls_Desc";
            lbl_Controls_Desc.Size = new Size(175, 122);
            lbl_Controls_Desc.TabIndex = 1;
            lbl_Controls_Desc.Text = "Up  ———— W or ↑\r\nDown ——— S or ↓\r\nLeft ———— A or ←\r\nRight  ——— D or →";
            lbl_Controls_Desc.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_Controls
            // 
            lbl_Controls.FlatStyle = FlatStyle.Flat;
            lbl_Controls.Font = new Font("Arial", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            lbl_Controls.ForeColor = SystemColors.Control;
            lbl_Controls.Location = new Point(391, 84);
            lbl_Controls.Name = "lbl_Controls";
            lbl_Controls.Size = new Size(87, 23);
            lbl_Controls.TabIndex = 1;
            lbl_Controls.Text = "Controls:";
            // 
            // lbl_Instructions
            // 
            lbl_Instructions.AutoSize = true;
            lbl_Instructions.Font = new Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Instructions.ForeColor = SystemColors.Control;
            lbl_Instructions.Location = new Point(211, 20);
            lbl_Instructions.Name = "lbl_Instructions";
            lbl_Instructions.Size = new Size(200, 37);
            lbl_Instructions.TabIndex = 0;
            lbl_Instructions.Text = "Instructions";
            lbl_Instructions.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 64, 0);
            ClientSize = new Size(827, 450);
            Controls.Add(instructionPanel);
            Controls.Add(Score_Label);
            Controls.Add(panel1);
            Controls.Add(map);
            Name = "Form1";
            Text = "Game Screen";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            KeyDown += Input;
            KeyUp += Form1_KeyUp;
            ((System.ComponentModel.ISupportInitialize)map).EndInit();
            ((System.ComponentModel.ISupportInitialize)X_btn).EndInit();
            ((System.ComponentModel.ISupportInitialize)pause_btn).EndInit();
            panel1.ResumeLayout(false);
            instructionPanel.ResumeLayout(false);
            instructionPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox map;
        private System.Windows.Forms.Timer gameTimer;
        private PictureBox X_btn;
        private PictureBox pause_btn;
        private Panel panel1;
        private Label Score_Label;
        private System.Windows.Forms.Timer special;
        private Panel instructionPanel;
        private Label lbl_Instructions;
        private Label lbl_Controls_Desc;
        private Label lbl_Controls;
        private Label lbl_How_Desc;
        private Label lbl_HowToPlay;
        private Button btn_continue;
    }
}