using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ClassLibrary1
{
    public class Class1
    {
        public Rectangle rect = new Rectangle();
        public Class1(int x , int y, int w, int h)
        {
            rect.X = x;
            rect.Y = y;
            rect.Width = w;
            rect.Height = h;

        }
    }
}
