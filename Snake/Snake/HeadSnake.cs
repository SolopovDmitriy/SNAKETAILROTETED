using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class HeadSnake : Segment, ISegmentBehavior
    {
        private Direction _direction;
        public HeadSnake() : base()
        {
            _direction = Direction.DOWN;
        }
        public HeadSnake(int x, int y, int radius, Color color, Direction dir) : base(x, y, radius, color)
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
                //валидация - нельзя поворачивать назад
                _direction = ((int)value % 2 != (int)_direction % 2) ? value : _direction;
            }
        }
        public void Draw(Graphics graphics)
        {
            Bitmap myBitmap = new Bitmap(Resource.snake);

            myBitmap.MakeTransparent(myBitmap.GetPixel(3, 3));

            switch (_direction)
            {
                case Direction.UP:
                    myBitmap = RotateHead(myBitmap, 180);
                    break;
                case Direction.DOWN:
                    myBitmap = RotateHead(myBitmap, 0);
                    break;
                case Direction.LEFT:
                    myBitmap = RotateHead(myBitmap, 90);
                    break;
                case Direction.RIGHT:
                    myBitmap = RotateHead(myBitmap, 270);
                    break;
            }
            graphics.DrawImage(myBitmap, new Rectangle(X - Radius, Y - Radius - 7, Radius * 2, Radius * 2 + 15));
        }
        public override string ToString()
        {
            return base.ToString() + $"Direction {Direction}";
        }
        private Bitmap RotateHead(Bitmap bitmap, int angle)
        {
            Bitmap rotateImage = new Bitmap(bitmap.Width, bitmap.Height);
            
            //Set the resolution for the rotation image
            rotateImage.SetResolution(bitmap.HorizontalResolution, bitmap.VerticalResolution);
            //Create a graphics object
            using (Graphics gdi = Graphics.FromImage(rotateImage))
            {
                //Rotate the image
                gdi.TranslateTransform(bitmap.Width / 2, bitmap.Height / 2);
                gdi.RotateTransform(angle);
                gdi.TranslateTransform(-bitmap.Width / 2, -bitmap.Height / 2);
                gdi.DrawImage(bitmap, new System.Drawing.Point(0, 0));
            }
            return rotateImage;
        }
    }
}
