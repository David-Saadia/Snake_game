using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class GeneralObject
    {
        public int x { set; get; }
        public int y { set; get; }

        string CurrentDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Resources\");

        public PictureBox renderMe { set; get; }

        public GeneralObject(string SpecificFile,int _x=0, int _y=0, int pSize=16, string _Name="generic")
        {
            x = _x; y = _y;
            renderMe = new PictureBox();
            renderMe.Name = _Name;
            renderMe.Size = new Size(pSize,pSize);
            renderMe.SizeMode = PictureBoxSizeMode.Zoom;
            renderMe.ImageLocation = Path.Combine(CurrentDirectory,SpecificFile);
            renderMe.Location = new Point(x * 16 - (renderMe.Size.Width/3), y * 16 - (renderMe.Size.Height/3));
        }

        public GeneralObject() {
            renderMe = default!;
        }
    }
}
