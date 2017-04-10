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

        public class PawnStatus
        {
            public bool Player;
            public int Number;
        }
    }
}
