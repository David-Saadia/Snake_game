using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class Snake:GeneralObject
    {
        public int prevX { get; set; }
        public int prevY { get; set; }

        public Snake(PictureBox mapSize, int settingScale):base("NEWHEAD.png", (mapSize.Width / settingScale / 2), (mapSize.Height / settingScale / 2), settingScale*3,"Head")
        {
            prevX = 0; prevY = 0;
        }

        public Snake(int _x, int _y):base()
        {
            x = _x; y = _y;
        }
    }
}
