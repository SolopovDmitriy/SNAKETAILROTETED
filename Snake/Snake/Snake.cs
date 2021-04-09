using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake : ISegmentBehavior
    {
        private ArrayList _snake;
        private HeadSnake _headSnake;
        private bool _canIMoove = true;
        public ArrayList Segments
        {
            get
            {
                return _snake;
            }
        }
        public Snake()
        {
            _snake = new ArrayList();
            _headSnake = new HeadSnake(300, 300, 15, Color.Red, Direction.RIGHT);
            _snake.Add(_headSnake);
            _snake.Add(new SegmentSnake(_headSnake.X - _headSnake.Radius * 2, _headSnake.Y, 15, Color.Green));
            _snake.Add(new TailSnake(
                _headSnake.X - (_headSnake.Radius * 4), _headSnake.Y, 15, Color.Green, Direction.RIGHT)
            );
   
        }
        public HeadSnake Head
        {
            get
            {
                return _headSnake;
            }
        }
        public void Draw(Graphics graphics)
        {
            foreach (var item in _snake)
            {
                if (item is HeadSnake)
                {
                    ((HeadSnake)item).Draw(graphics);
                }
                else if (item is SegmentSnake)
                {
                    ((SegmentSnake)item).Draw(graphics);
                }
                else if (item is TailSnake)
                {
                    ((TailSnake)item).Draw(graphics);
                }
            }
        }



        // my code
        public void Move()
        {
            //int oldHeadX = Head.X; //координаты головы до перемещения по оси x
            //int oldHeadY = Head.Y; //координаты головы до перемещения по оси y

            if (_canIMoove)
            {
                //((SegmentSnake)_snake[1]).X = oldHeadX;//Х координаты - первый сегмент туловища, тот кто идет сразу после головы
                //((SegmentSnake)_snake[1]).Y = oldHeadY;

                for (int i = _snake.Count - 1; i > 0; i--)
                {
                    ((Segment)_snake[i]).X = ((Segment)_snake[i - 1]).X;
                    ((Segment)_snake[i]).Y = ((Segment)_snake[i - 1]).Y;
                }

            }

            // move head
            switch (Head.Direction)
            {
                case Direction.UP:
                    Head.Direction = Direction.UP;
                    Head.Y -= Head.Radius * 2;
                    break;
                case Direction.DOWN:
                    Head.Direction = Direction.DOWN;
                    Head.Y += Head.Radius * 2;
                    break;
                case Direction.LEFT:
                    Head.Direction = Direction.LEFT;
                    Head.X -= Head.Radius * 2;
                    break;
                case Direction.RIGHT:
                    Head.Direction = Direction.RIGHT;
                    Head.X += Head.Radius * 2;
                    break;
            }

            // rotate tail
            TailSnake tail = (TailSnake)_snake[_snake.Count - 1];
            Segment beforeTail = (Segment)_snake[_snake.Count - 2];
            if (tail.X < beforeTail.X) // tail RIGHT from previous segment
            {
                tail.Direction = Direction.RIGHT;
            }
            else if (tail.X > beforeTail.X) 
            {
                tail.Direction = Direction.LEFT;
            }
            else if(tail.Y < beforeTail.Y) 
            {
                tail.Direction = Direction.DOWN;
            }
            else if(tail.Y > beforeTail.Y) 
            {
                tail.Direction = Direction.UP;
            }


        }

        public void Grow(Food food)
        {
            //_snake.Insert(1, new SegmentSnake());

            // my code
            _snake.Insert(1, new SegmentSnake(Head.X, Head.Y, Head.Radius, Color.Green));
            switch (Head.Direction)
            {
                case Direction.UP:
                    Head.Direction = Direction.UP;
                    Head.Y -= Head.Radius * 2;
                    break;
                case Direction.DOWN:
                    Head.Direction = Direction.DOWN;
                    Head.Y += Head.Radius * 2;
                    break;
                case Direction.LEFT:
                    Head.Direction = Direction.LEFT;
                    Head.X -= Head.Radius * 2;
                    break;
                case Direction.RIGHT:
                    Head.Direction = Direction.RIGHT;
                    Head.X += Head.Radius * 2;
                    break;
            }
          
        }
        public static bool canIEath(Segment segment, int food_x, int food_y)
        {
            if (segment.X == food_x && segment.Y == food_y)
            {
                return true;
            }
            else
            {
                return false;
            }
        } 
    }
}
