using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class SegmentSnake : Segment, ISegmentBehavior
    {
        public SegmentSnake() : base()
        {
            Radius = Radius - 1;
        }
        public SegmentSnake(int x, int y, int radius, Color color) : base(x, y, radius-1, color)
        {

        }
        public void Draw(Graphics g) {
            Radius++;
             g.FillRectangle(new SolidBrush(this.Color), new Rectangle(X - Radius, Y - Radius, Radius * 2, Radius * 2));
            // my code
           // g.FillEllipse(new SolidBrush(this.Color), new Rectangle(X - Radius, Y - Radius, Radius * 2, Radius * 2));
        }
    }
}
