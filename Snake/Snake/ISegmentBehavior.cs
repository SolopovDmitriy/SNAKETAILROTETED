using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    interface ISegmentBehavior
    {
        void Draw(Graphics graphics);
    }
}
