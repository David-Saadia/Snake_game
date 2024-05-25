using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class BonusBurger:Burger
    {
        public int decay = 3;

        Control.ControlCollection myControls;
        public BonusBurger(Random rand, PictureBox map, Control.ControlCollection Controls, bool decision = false) : base(rand, map, decision? "GoodBurger.png":"BadBurger.png"){
            Tag = decision ? "Blue" : "Red";
            myControls = Controls;
        }

        public void KillMe()
        {
            renderMe.Dispose();
            myControls.Remove(renderMe);
        }
    }
}
