using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class MainForm : Form
    {
        private GameField _gameField;
        //private Snake _snake;
        public MainForm()
        {
            InitializeComponent();
            _gameField = new GameField();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            panelControl.Controls.Add(_gameField.GameFieldControl);
            //GameTimer.Interval = 300;
            GameTimer.Interval = 400;
            GameTimer.Start();
            GameTimer.Tick += GameTimer_Tick;
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            _gameField.Snake.Move();

            if (Snake.canIEath(_gameField.Snake.Head, _gameField.Food.X, _gameField.Food.Y))
            {
                _gameField.Snake.Grow(_gameField.Food);
                _gameField.Food.Respawn( _gameField.GameFieldControl.Width, _gameField.GameFieldControl.Height, _gameField.Snake);
            }

            _gameField.GameFieldControl.Refresh();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                case Keys.Up:
                    {
                        _gameField.Snake.Head.Direction = Direction.UP;
                        break;
                    }
                case Keys.S:
                case Keys.Down:
                    {
                        _gameField.Snake.Head.Direction = Direction.DOWN;
                        break;
                    }
                case Keys.A:
                case Keys.Left:
                    {
                        _gameField.Snake.Head.Direction = Direction.LEFT;
                        break;
                    }
               case Keys.D:
               case Keys.Right:
                    {
                        _gameField.Snake.Head.Direction = Direction.RIGHT;
                        break;
                    }
            }
        }
    }
}
