using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class SpecialBurger:Burger
    {

        public SpecialBurger(Random rand, PictureBox mapsize) :base(rand,mapsize,"BurgerKILL.png") {
            Tag = "Special";
        }

    }
}
