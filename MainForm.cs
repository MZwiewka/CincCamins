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

        public MainForm()
        {
            InitializeComponent();
            
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
                _pawns.Add(new Pawn(number: i + 1, player: false)
                {
                    Position = new Vector2f(i * 100, 0),
                    X = i,
                    Y = 0,
                });
            }

            for (int i = 0; i < 5; i++)
            {
                _pawns.Add(new Pawn(number: i + 1, player: true)
                {
                    Position = new Vector2f(i * 100, 400),
                    X = i,
                    Y = 4,
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
                var pawn = _pawns.Single(p => p.Player == Globals.WHO_IS_PLAYER && p.Number.ToString().Equals(SelectedPon.Text));

                if (pawn.X > 0)
                {
                    if (CheckIfCollide(pawn, newX: pawn.X - 1)) return;

                    pawn.Position -= new Vector2f(100, 0);
                    pawn.X--;
                }
            }
            catch (Exception)
            {
            }
        }

        private void Up_Click(object sender, EventArgs e)
        {
            try
            {
                var pawn = _pawns.Single(p => p.Player == Globals.WHO_IS_PLAYER && p.Number.ToString().Equals(SelectedPon.Text));

                if (pawn.Y > 0)
                {
                    if (CheckIfCollide(pawn, newY: pawn.Y - 1)) return;

                    pawn.Position -= new Vector2f(0, 100);
                    pawn.Y--;
                }
            }
            catch (Exception)
            {
            }
        }

        private void Right_Click(object sender, EventArgs e)
        {
            try
            {
                var pawn = _pawns.Single(p => p.Player == Globals.WHO_IS_PLAYER && p.Number.ToString().Equals(SelectedPon.Text));

                if (pawn.X < 4)
                {
                    if(CheckIfCollide(pawn, newX: pawn.X + 1)) return;

                    pawn.Position += new Vector2f(100, 0);
                    pawn.X++;
                }
            }
            catch (Exception)
            {
            }
        }

        private void Down_Click(object sender, EventArgs e)
        {
            try
            {
                var pawn = _pawns.Single(p => p.Player == Globals.WHO_IS_PLAYER && p.Number.ToString().Equals(SelectedPon.Text));

                if (pawn.Y < 4)
                {
                    if(CheckIfCollide(pawn, newY: pawn.Y + 1)) return;

                    pawn.Position += new Vector2f(0, 100);
                    pawn.Y++;
                }
            }
            catch (Exception)
            {
            }
        }

        private bool CheckIfCollide(Pawn pawn, int? newX = null, int? newY = null)
        {
            var x = newX ?? pawn.X;
            var y = newY ?? pawn.Y;

            if (_pawns.Any(p => p.X == x && p.Y == y)) return true;
            else return false;
        }

        private void CheckTable_Click(object sender, EventArgs e)
        {
            GenerateFromGameStatus(GenerateGameStatus());
        }

        private void ChangePlayer_Click(object sender, EventArgs e)
        {
            if (Globals.WHO_IS_PLAYER)
            {
                WhoIsPlayer.BackColor = System.Drawing.Color.Red;
                Globals.WHO_IS_PLAYER = false;
            }
            else
            {
                WhoIsPlayer.BackColor = System.Drawing.Color.Lime;
                Globals.WHO_IS_PLAYER = true;
            }
        }

        private void CountAIMove_Click(object sender, EventArgs e)
        {
            var game = MinMaxNamespace.MinMax.CountAIMove(GenerateGameStatus());
            GenerateFromGameStatus(game);
        }

        private void CheckBeatings_Click(object sender, EventArgs e)
        {
            var game = MinMaxNamespace.MinMax.CheckBeatings(GenerateGameStatus());
            GenerateFromGameStatus(game);
        }
    }
}
