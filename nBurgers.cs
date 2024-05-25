using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class Burger:GeneralObject
    {

        public string Tag;


        public Burger(Random rand, PictureBox mapsize, string BurgerType="Burger.png"):base(BurgerType, rand.Next(2, (mapsize.Width - 2) / 16), rand.Next(2, (mapsize.Height - 2) / 16),16*3,"BURGER"){
            Tag = "Regular";
        }

        public bool isInHitbox(int _x, int _y) // Checking X and Y value of player coordinates against burger position
        {
            bool flagX = false;
            bool flagY = false;
            if (_x >= x - 2 && _x <= x + 2) flagX = true;
            if (_y >= y - 2 && _y <= y + 2) flagY = true;
            return flagX && flagY;
        }

      
    }
}
