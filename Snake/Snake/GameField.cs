using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    class GameField
    {
        private PictureBox _gameFieldControl;//gameField.Snake.Head.Direction = Direction.UP;
        private Snake _snake = new Snake();
        private Food _food = new Food();

        public Food Food
        {
            get
            {
                return _food;
            }
        }
        public Snake Snake
        {
            get
            {
                return _snake;
            }
        }
        public PictureBox GameFieldControl
        {
            get
            {
                return _gameFieldControl;
            }
        }
        public GameField()
        {
            _gameFieldControl = new PictureBox();
            _gameFieldControl.BackColor = Color.Black;
            _gameFieldControl.Dock = DockStyle.Fill;

            _gameFieldControl.Paint += _gameFieldControl_Paint;
        }
        private void _gameFieldControl_Paint(object sender, PaintEventArgs e)
        {
            _snake.Draw(e.Graphics);
            _food.Draw(e.Graphics);
        }
    }
}
