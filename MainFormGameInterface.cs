using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CincCamins
{
    public partial class MainForm
    {
        public void GenerateFromGameStatus(GameStatus game)
        {
            _pawns.Clear();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    var pawn = game.Pawns[i, j];
                    if (pawn != null)
                    {
                        _pawns.Add(new Pawn(pawn.Number, pawn.Player)
                        {
                            X = i,
                            Y = j,
                            Position = new Vector2f(i * 100f, j * 100f),
                        });
                    }
                }
            }
        }

        public GameStatus GenerateGameStatus()
        {
            return new GameStatus(this._pawns);
        }
    }
}
