using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class TailSnake : Segment, ISegmentBehavior
    {
        private Direction _direction;
        public TailSnake(int x, int y, int r, Color snakeColor, Direction dir) : base(x, y, r, snakeColor)
        {
              _direction = dir;
        }

        public Direction Direction
        {
            get
            {
                return _direction;
            }
            set
            {               
                _direction = value;
            }
        }


        // my code
        public void Draw(Graphics graphics)
        {   
            SolidBrush tailBrush = new SolidBrush(this.Color);
            Point[] trianglePeaks= null;
            switch (_direction)
            {
                case Direction.UP:
                    trianglePeaks = new Point[]{
                                        new Point(X , Y + Radius),
                                        new Point(X - Radius, Y - Radius + 1),
                                        new Point(X + Radius, Y - Radius + 1)
                                    };
                    break;
                case Direction.DOWN:
                    trianglePeaks = new Point[]{
                                        new Point(X, Y - Radius),
                                        new Point(X - Radius, Y + Radius -1),
                                        new Point(X + Radius, Y + Radius - 1)
                                    };
                    break;
                case Direction.LEFT:
                    trianglePeaks = new Point[]{
                                        new Point(X + Radius, Y),
                                        new Point(X - Radius + 1, Y - Radius),
                                        new Point(X - Radius + 1, Y + Radius)
                                    };
                    break;
                case Direction.RIGHT:
                    trianglePeaks = new Point[]{
                                        new Point(X + Radius - 1, Y + Radius),
                                        new Point(X + Radius - 1, Y - Radius),
                                        new Point(X - Radius, Y)
                                    };
                    break;
            }          
            graphics.FillPolygon(tailBrush, trianglePeaks);
        }
    }
}
