using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CincCamins
{
    public partial class MainForm : Form
    {
        private List<Pawn> _pawns;
        private RenderWindow _renderWindow;
        private Timer _timer;
        private Sprite _board;
        private Font _font;

        public MainForm()
        {
            InitializeComponent();
            
            _font = new Font("consola.ttf");
            Texture tx = new Texture("Board.png");
            _board = new Sprite(tx);
            
            _timer = new Timer { Interval = 1000 / 60 };
            _timer.Tick += MainLoop;
            _timer.Start();

            var context = new ContextSettings { DepthBits = 24, AntialiasingLevel = 16 };
            this._renderWindow = new RenderWindow(SFMLRenderControl.Handle, context);
            _renderWindow.SetActive(true);

            InitPawns();
        }

        private void InitPawns()
        {
            _pawns = new List<Pawn>();
            for (int i = 0; i < 5; i++)
            {
                _pawns.Add(new Pawn(i + 1, _font)
                {
                    Radius = 50,
                    FillColor = Color.Red,
                    Position = new Vector2f(i * 100, 0),
                    X = 0,
                    Y = i,
                });
            }

            for (int i = 0; i < 5; i++)
            {
                _pawns.Add(new Pawn(i + 1, _font)
                {
                    Player = true,
                    Radius = 50,
                    FillColor = Color.Green,
                    Position = new Vector2f(i * 100, 400),
                    X = 0,
                    Y = i,
                });
            }
        }

        private void MainLoop(object sender, EventArgs e)
        {
            _renderWindow.Clear(new Color(50, 50, 50));

            _renderWindow.Draw(_board);
            _pawns.ForEach(p => {
                _renderWindow.Draw(p);
                _renderWindow.Draw(p.NumText);
            });
            _renderWindow.Display();
        }

        private void Left_Click(object sender, EventArgs e)
        {
            try
            {
                var pawn = _pawns.Single(p => p.Player && p.Number.ToString().Equals(SelectedPon.Text));
                pawn.Position -= new Vector2f(100, 0);
            }
            catch (Exception)
            {
            }
        }

        private void Up_Click(object sender, EventArgs e)
        {
            try
            {
                var pawn = _pawns.Single(p => p.Player && p.Number.ToString().Equals(SelectedPon.Text));
                pawn.Position -= new Vector2f(0, 100);
            }
            catch (Exception)
            {
            }
        }

        private void Right_Click(object sender, EventArgs e)
        {
            try
            {
                var pawn = _pawns.Single(p => p.Player && p.Number.ToString().Equals(SelectedPon.Text));
                pawn.Position += new Vector2f(100, 0);
            }
            catch (Exception)
            {
            }
        }

        private void Down_Click(object sender, EventArgs e)
        {
            try
            {
                var pawn = _pawns.Single(p => p.Player && p.Number.ToString().Equals(SelectedPon.Text));
                pawn.Position += new Vector2f(0, 100);
            }
            catch (Exception)
            {
            }
        }
    }
}
