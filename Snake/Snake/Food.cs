using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Food : Segment, ISegmentBehavior
    {
        public Food(int x, int y, int r, Color FoodColor) : base(x, y, r, FoodColor)
        {

        }
        public void Respawn(int width, int height, Snake snake)
        {
            bool isRespawn = false;
            Random random = new Random();
            int fX = 0;
            int fY = 0;
            do
            {
                fX = (random.Next(Radius * 2, width - Radius) / 30) * 30;
                fY = (random.Next(Radius * 2, height - Radius) / 30) * 30;
                bool isInBody = false;
                foreach (Segment item in snake.Segments)
                {
                    if (Snake.canIEath(item, fX, fY))
                    {
                        isInBody = true;
                    }
                }
                if (!isInBody)
                {
                    X = fX;
                    Y = fY;
                    isRespawn = true;
                }
            } while (!isRespawn);
        }
        public Food()
        {
            
        }
        public void Draw(Graphics graphics)
        {
            Bitmap myBitmap = new Bitmap(Resource.apple);
            myBitmap.MakeTransparent(myBitmap.GetPixel(3, 3));
            graphics.DrawImage(myBitmap, new Rectangle(X - Radius, Y - Radius, Radius, Radius));
        }
    }
}
