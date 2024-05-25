using System.Media;
using System.Timers;
using System.Windows.Forms.Design;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using System.Net.Http.Json;
using System.Xml;
using Microsoft.VisualBasic.Devices;

namespace test
{
    [Serializable]
    public partial class Form1 : Form
    {
        //PARENT REFERENCE: -------------
        StartingScreen myParent;

        //OBJECT COLLECTIONS: SNAKE AND FRUITS: ---------------
        List<Snake> player = new List<Snake>();
        List<Burger> Food = new List<Burger>();
        public static int[]? HighscoreArr;

        //GENERAL SPECIFICATIONS OF GAME: ---------------
        int mapWidth, mapHeight;

        int settingScale = 16;


        //BOOLEAN FACTORS OF GAME: -----------------
        int score { get; set; }
        bool isGameOver { get; set; }
        bool DidStart { set; get; }

        static int BadBurgerTimerVal = 1;

        //DIRECTION/CONTROL VARIABLE: ---------------
        enum Direction { STOP = 0, LEFT, RIGHT, UP, DOWN };
        Direction dir;

        //RANDOMIZER: -----------------
        Random rand = new Random();

        // GAME MUSIC SECTION:-----------------
        SoundPlayer Main_Music;

        string CurrentDirectory;


        public Form1(StartingScreen myParent)
        {
            InitializeComponent();

            this.Focus();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.myParent = myParent;

            mapHeight = map.Height / settingScale;
            mapWidth = map.Width / settingScale;

            CurrentDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\");
            Main_Music = new SoundPlayer(Path.Combine(CurrentDirectory, @"resources\GameMusic.wav"));



            gameSetup();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pause_btn.BackColor = Color.Transparent;

            X_btn.BackColor = Color.Transparent;

            Score_Label.BackColor = Color.Transparent;
            Score_Label.Parent = this;

            instructionPanel.Visible = false;
            instructionPanel.BackColor = Color.FromArgb(100, 39, 87, 31);
            instructionPanel.Parent = map;
            instructionPanel.Top = (this.Height / 2) - (instructionPanel.Height / 2) - (instructionPanel.Height / 4);
            instructionPanel.Left = (this.Width / 2) - (instructionPanel.Width / 2);

            lbl_Controls.BackColor = Color.Transparent;
            lbl_Controls_Desc.BackColor = Color.Transparent;
            lbl_HowToPlay.BackColor = Color.Transparent;
            lbl_How_Desc.BackColor = Color.Transparent;
            lbl_Instructions.BackColor = Color.Transparent;
        }

        private void gameSetup()
        {
            /*Initialzing game values*/
            dir = 0;
            score = 0;
            isGameOver = false;
            DidStart = false;
            player.Clear();
            Food.Clear();
            map.Parent = this;
            gameTimer.Interval = 30;

            /*Adding player and food to the screen*/
            player.Add(new Snake(map, settingScale));
            Controls.Add(player[0].renderMe);

            player[0].renderMe.BackColor = Color.Transparent;
            player[0].renderMe.Parent = map;
            player[0].renderMe.BringToFront();

            Burger GarryBurger = new Burger(rand, map);
            Food.Add(GarryBurger);
            Controls.Add(GarryBurger.renderMe);
            GarryBurger.renderMe.BackColor = Color.Transparent;
            GarryBurger.renderMe.Parent = map;
            GarryBurger.renderMe.BringToFront();


            /*Deserialzing data -- highscore chart*/

            string ReadjsonString; 
            try
            {
                ReadjsonString = File.ReadAllText(Path.Combine(CurrentDirectory, "Saves\\Highscores.json"));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
                SerializeNow(true);
                ReadjsonString = File.ReadAllText(Path.Combine(CurrentDirectory, "Saves\\Highscores.json"));
            }
            HighscoreArr = JsonSerializer.Deserialize<int[]>(ReadjsonString);
        }

        private void startGame()
        {
            gameTimer.Start();
            Main_Music.PlayLooping();
        }

        private void updateGraphics(object sender, PaintEventArgs e)
        {

            Graphics map = e.Graphics;
            Brush colorSnake;
            Brush colorFruit = Brushes.DarkSeaGreen;

            /*Painting the snake on the map*/
            for (int i = 0; i < player.Count(); i++)
            {
                if (i == 0)
                {
                    colorSnake = Brushes.DarkSeaGreen;
                    map.FillEllipse(colorSnake, new Rectangle(
                        ((player[i].x) * settingScale),
                        ((player[i].y) * settingScale),
                        settingScale,
                        settingScale
                        ));
                }
                else
                {
                    colorSnake = Brushes.IndianRed;
                    map.FillEllipse(Brushes.Black, new Rectangle(
                      ((player[i].x) * settingScale),
                      ((player[i].y) * settingScale),
                      settingScale + 16,
                      settingScale + 1
                      ));
                    map.FillEllipse(colorSnake, new Rectangle(
                       ((player[i].x) * settingScale),
                       ((player[i].y) * settingScale),
                       settingScale + 15,
                       settingScale
                       ));

                }

            }

            /*Painting the fruits on the map*/
            for (int i = 0; i < Food.Count(); i++)
            {

                map.FillEllipse(colorFruit, new Rectangle(
                    ((Food[i].x) * settingScale),
                    ((Food[i].y) * settingScale),
                    settingScale,
                    settingScale
                    ));
            }

        }

        private void Input(object sender, KeyEventArgs e)
        {
           

            /*Starting the game and directional input*/

            if (DidStart == false)
            {
                DidStart = true;
                startGame();
                return;
            }
            else
            {
                if ((e.KeyCode == Keys.W || e.KeyCode == Keys.Up) && (dir != Direction.DOWN)) dir = Direction.UP;
                if ((e.KeyCode == Keys.S || e.KeyCode == Keys.Down) && (dir != Direction.UP)) dir = Direction.DOWN;
                if ((e.KeyCode == Keys.A || e.KeyCode == Keys.Left) && (dir != Direction.RIGHT)) dir = Direction.LEFT;
                if ((e.KeyCode == Keys.D || e.KeyCode == Keys.Right) && (dir != Direction.LEFT)) dir = Direction.RIGHT;
                if (e.KeyCode == Keys.Escape) { myParent.Close(); this.Close(); }

            }

            if (e.KeyCode == Keys.F8) GameOver();
        }

        private void GameTime(object sender, EventArgs e)
        {
            for (int i = 0; i < player.Count(); i++)
            {//-----------------------------------:Snake movement
                {
                    if (i == 0) //-------Head movement & logic:
                    {
                        switch (dir)
                        {
                            case Direction.UP:
                                player[i].prevY = player[i].y;
                                player[i].prevX = player[i].x;
                                player[i].y--;
                                break;
                            case Direction.DOWN:
                                player[i].prevY = player[i].y;
                                player[i].prevX = player[i].x;
                                player[i].y++;
                                break;
                            case Direction.LEFT:
                                player[i].prevY = player[i].y;
                                player[i].prevX = player[i].x;
                                player[i].x--;
                                break;
                            case Direction.RIGHT:
                                player[i].prevY = player[i].y;
                                player[i].prevX = player[i].x;
                                player[i].x++;
                                break;
                        }

                        // Updating picture element location associated with object:
                        player[i].renderMe.Location = new Point(player[i].x * settingScale - (player[i].renderMe.Size.Width / 4), player[i].y * settingScale - (player[i].renderMe.Size.Width / 4));

                        // Out ouf bounds:

                        if (player[0].y <= 0) player[0].y = mapHeight - 1;
                        if (player[0].x >= mapWidth) player[0].x = 1;
                        if (player[0].x <= 0) player[0].x = mapWidth - 1;
                        if (player[0].y >= mapHeight) player[0].y = 1;
                        //

                        //Did we just eat food?
                        for (int j = 0; j < Food.Count(); j++)
                        {
                            if (Food[j].isInHitbox(player[0].x, player[0].y) && (Food[j].Tag is "Regular" or "Blue" or "Red")) eatFruit(Food[j]);
                            else if (Food[j].isInHitbox(player[0].x, player[0].y) && (Food[j].Tag == "Special"))
                            {
                                GameOver();
                            }


                        }
                        //Crashing!
                        for (int j = 1; j < player.Count; j++)
                            if (player[i].x == player[j].x && player[i].y == player[j].y)
                                GameOver();
                    }
                    else
                    {// Following the leader... Body movement:
                        player[i].prevX = player[i].x;
                        player[i].prevY = player[i].y;
                        player[i].x = player[i - 1].prevX;
                        player[i].y = player[i - 1].prevY;
                    }
                }

            }
            if (score >= 5)
            {
                special.Start();
            }

            if (score >= 20 && score < 50) // Making the game a little harder...
            {
                gameTimer.Interval = 20;
                special.Interval = 5000;
            }

            if (score >= 50) // Making the game A LOT harder...
            {
                gameTimer.Interval = 15;
                special.Interval = 1000;
            }

            map.Invalidate();

            if (isGameOver == true) GameOver();

            // Making sure map size is appropriate to resizing the screen.
            mapHeight = map.Height / settingScale;
            mapWidth = map.Width / settingScale;


        }

        private void GameOver()
        {
            gameTimer.Stop();
            UpdateRecord();
            SerializeNow();
            if (HighscoreArr != null)
            {
                EndingScreen temp = new EndingScreen(HighscoreArr, myParent, score);
                temp.Visible = true;
            }
            this.Close();
        }

        private void eatFruit(Burger removeMe)
        {

            switch (removeMe.Tag) // Deciding which score to reward the player based off which burger he eaten.
            {
                case "Regular":
                    score++;
                    break;
                case "Red":
                    score -= 5;
                    break;
                case "Blue":
                    score += 5;
                    break;
            }


            player.Add(new Snake(player[player.Count() - 1].prevX, player[player.Count() - 1].prevY)); //Adding to the body of the snake

            /* -- Removing the food that was eaten from the screen and from memory. */
            removeMe.renderMe.Dispose();
            Controls.Remove(removeMe.renderMe);
            Food.Remove(removeMe);

            if (score < 0) score = 0; // No negative scores!
            Score_Label.Text = "Score: " + score;
            CreateBurger();


        }

        private void CreateBurger(bool Special = false)
        {
            Burger newHamburger;
            int BonusOrRegular = rand.Next(0, 6); //Pulling a random value to decide rather the new burger is bonus, or regular.
            bool dont_add = false;

            /*Making sure not to create a new regular burger, in case regular burgers exist on the screen already.*/
            for (int i = 0; i < Food.Count(); i++)
                if (Food[i].Tag == "Regular")
                    dont_add = true;

            if (BonusOrRegular == 3 && Special == false)
            {
                bool decision = rand.Next(0, 2) == 0 ? true : false; //Randomizing the kind of bonus fruit.
                newHamburger = new BonusBurger(rand, map, Controls, decision);


                Food.Add(newHamburger);
                Controls.Add(newHamburger.renderMe);
                newHamburger.renderMe.BackColor = Color.Transparent;
                newHamburger.renderMe.Parent = map;
                newHamburger.renderMe.BringToFront();
            }
            else
            {
                if (!dont_add)
                    newHamburger = Special ? new SpecialBurger(rand, map) : new Burger(rand, map);
                else
                    newHamburger = new SpecialBurger(rand, map);


                Food.Add(newHamburger);
                Controls.Add(newHamburger.renderMe);
                newHamburger.renderMe.BackColor = Color.Transparent;
                newHamburger.renderMe.Parent = map;
                newHamburger.renderMe.BringToFront();
            }

        }

        private void Pause_click(object sender, EventArgs e)
        {
            if (gameTimer.Enabled == false)
            {
                gameTimer.Enabled = true;
                special.Enabled = true;
                instructionPanel.Visible = false;
                instructionPanel.SendToBack();
                this.Focus();
            }
            else
            {
                gameTimer.Enabled = false;
                special.Enabled = false;
                instructionPanel.Visible = true;
                instructionPanel.BringToFront();
            }
        }

        private void X_Click(object sender, EventArgs e)
        {
            myParent.Close();
            this.Close();
        }

        private void SpecialBurgerTimer(object sender, EventArgs e)
        {
            int HowManyBurgers = 0;
            BadBurgerTimerVal--;
            for (int i = 0; i < Food.Count; i++)
            {
                if (Food[i].Tag is "Special")
                {
                    HowManyBurgers++;
                    if (HowManyBurgers >= 7)
                    {
                        Food[i].renderMe.Dispose();
                        Controls.Remove(Food[i].renderMe);
                        Food.Remove(Food[i]);
                    }

                }


            }


            if (BadBurgerTimerVal <= 0)
            {
                BadBurgerTimerVal = 1;
                special.Stop();
                CreateBurger(true);

            }
        }

        private void UpdateRecord()
        {
            /*Pushing least significant values to the bottom (or out)*/
            if (HighscoreArr != null)
            {
                int j = 4;

                for (int i = 0; i < 5; i++)
                    if (score > HighscoreArr[i])
                    {
                        while (j > i)
                        {
                            HighscoreArr[j] = HighscoreArr[j - 1];
                            j--;
                        }
                        HighscoreArr[i] = score;
                        i = 6;
                    }
            }
        }

        public void SerializeNow(bool newFile=false)
        {

            var options = new JsonSerializerOptions { WriteIndented = true }; //-Options Var-
            options.WriteIndented = true; // --- Readable ---

            string jsonString;
            if (newFile == false) //If we have a high score file already
            {
                jsonString = JsonSerializer.Serialize(HighscoreArr, options);//Producing Json string
            }
            else //Else, create a new one intializied with zeros.
            {
                int[] arr = new int[5];
                jsonString = JsonSerializer.Serialize(arr, options);
            }
            File.WriteAllText(Path.Combine(CurrentDirectory, "Saves\\Highscores.json"), jsonString);
            //Writing to file.
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btn_Continue_Click(object sender, EventArgs e)
        {
            Pause_click(sender, e);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            bool AddBurger = true;

            /*Decreasing decay on each bonus fruit on the screen on any input from the user.*/
            for (int i = 0; i < Food.Count(); i++)
            {
                if (Food[i].Tag is "Regular")
                    AddBurger = false;
                if (Food[i].Tag is "Red" or "Blue")
                {
                    BonusBurger tempCatch = (BonusBurger)Food[i];
                    if (tempCatch.decay == 0)
                    {
                        Food.Remove(tempCatch);
                        tempCatch.KillMe();

                        if (AddBurger == true)
                            CreateBurger();

                    }
                    else tempCatch.decay--;
                }
            }
        }
    }
}