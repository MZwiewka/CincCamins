using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CincCamins
{
    public class GameStatus
    {
        public PawnStatus[,] Pawns = new PawnStatus[5, 5];
        public int PlayerBeatings;
        public int OpponentBeatings;
        public int Value;

        public GameStatus(List<Pawn> gameStatus)
        {
            gameStatus.ForEach(p =>
            {
                Pawns[p.X, p.Y] = new PawnStatus
                {
                    Number = p.Number,
                    Player = p.Player,
                };
            });
        }

        public GameStatus(GameStatus game)
        {
            PlayerBeatings = 0;
            OpponentBeatings = 0;
            Value = 0;

            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    var p = game.Pawns[x, y];
                    if (p == null) continue;

                    Pawns[x, y] = new PawnStatus
                    {
                        Number = p.Number,
                        Player = p.Player,
                    };
                }
            }
        }

        public override string ToString()
        {
            var result = "";
            for (int y = 0; y < 5; y++)
            {
                result += "[";
                for (int x = 0; x < 5; x++)
                {
                    if (Pawns[x, y] != null)
                    {
                        result += Pawns[x, y].Player ?
                            (x == 4 ? "P" : "P,"):
                            (x == 4 ? "O" : "O,");
                    }
                    else result += (x == 4 ? " " : " ,");
                }
                result += "]\n";
            }
            return result;
        }

        public class PawnStatus
        {
            public bool Player;
            public int Number;
        }
    }
}
