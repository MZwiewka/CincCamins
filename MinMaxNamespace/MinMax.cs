using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CincCamins.GameStatus;

namespace CincCamins.MinMaxNamespace
{
    public class MinMax
    {
        /// <summary>
        /// Proteza :>
        /// </summary>
        public static GameStatus CountAIMove(GameStatus game)
        {
            return game;
        }

        public static GameStatus CheckBeatings(GameStatus game)
        {
            // Lista "bić" czyli pary X-Y określające pozycję pionka do zbicia
            var beatings = new List<PawnPosition>();

            // Najpierw poziomo
            for (int i = 0; i < 5; i++)
            {
                var pawns = new List<PawnPosition>();
                for (int j = 0; j < 5; j++)
                {
                    if (game.Pawns[j, i] != null)
                    {
                        pawns.Add(new PawnPosition
                        {
                            X = j,
                            Y = i,
                            Player = game.Pawns[j, i].Player,
                        });
                    }
                }

                // jeżeli są równo 3 to ok
                if (pawns.Count == 3)
                {
                    var position = CheckHorizontally(pawns);
                    if (position != null)
                    {
                        beatings.Add(position);
                    }
                }
            }

            // Następnie pionowo
            for (int i = 0; i < 5; i++)
            {
                var pawns = new List<PawnPosition>();
                for (int j = 0; j < 5; j++)
                {
                    if (game.Pawns[i, j] != null)
                    {
                        pawns.Add(new PawnPosition
                        {
                            X = i,
                            Y = j,
                            Player = game.Pawns[i, j].Player,
                        });
                    }
                }

                // jeżeli są równo 3 to ok
                if (pawns.Count == 3)
                {
                    var position = CheckVertically(pawns);
                    if (position != null)
                    {
                        beatings.Add(position);
                    }
                }
            }

            foreach (var b in beatings)
            {
                game.Pawns[b.X, b.Y] = null;
            }

            game.PlayerBeatings = beatings.Count(b => b.Player);
            game.OpponentBeatings = beatings.Count(b => !b.Player);
            return game;
        }

        private static PawnPosition CheckVertically(List<PawnPosition> pawns)
        {
            bool x;
            if (pawns.Count(p => p.Player) == 2) x = true;
            else x = false;

            // [X,X,O, , ]
            if (pawns[0].Y == 0 && pawns[0].Player == x &&
                pawns[1].Y == 1 && pawns[1].Player == x &&
                pawns[2].Y == 2 && pawns[2].Player == !x)
            {
                return pawns[2];
            }
            // [ ,X,X,O, ]
            if (pawns[0].Y == 1 && pawns[0].Player == x &&
                pawns[1].Y == 2 && pawns[1].Player == x &&
                pawns[2].Y == 3 && pawns[2].Player == !x)
            {
                return pawns[2];
            }
            // [ , , X,X,O]
            if (pawns[0].Y == 2 && pawns[0].Player == x &&
                pawns[1].Y == 3 && pawns[1].Player == x &&
                pawns[2].Y == 4 && pawns[2].Player == !x)
            {
                return pawns[2];
            }
            // [ , ,O,X,X]
            if (pawns[0].Y == 2 && pawns[0].Player == !x &&
                pawns[1].Y == 3 && pawns[1].Player == x &&
                pawns[2].Y == 4 && pawns[2].Player == x)
            {
                return pawns[0];
            }
            // [ ,O,X,X, ]
            if (pawns[0].Y == 1 && pawns[0].Player == !x &&
                pawns[1].Y == 2 && pawns[1].Player == x &&
                pawns[2].Y == 3 && pawns[2].Player == x)
            {
                return pawns[0];
            }
            // [O,X,X, , ]
            if (pawns[0].Y == 0 && pawns[0].Player == !x &&
                pawns[1].Y == 1 && pawns[1].Player == x &&
                pawns[2].X == 2 && pawns[2].Player == x)
            {
                return pawns[0];
            }
            // nic :<
            return null;
        }

        private static PawnPosition CheckHorizontally(List<PawnPosition> pawns)
        {
            bool x;
            if (pawns.Count(p => p.Player) == 2) x = true;
            else x = false;

            // [X,X,O, , ]
            if (pawns[0].X == 0 && pawns[0].Player == x &&
                pawns[1].X == 1 && pawns[1].Player == x &&
                pawns[2].X == 2 && pawns[2].Player == !x)
            {
                return pawns[2];
            }
            // [ ,X,X,O, ]
            if (pawns[0].X == 1 && pawns[0].Player == x &&
                pawns[1].X == 2 && pawns[1].Player == x &&
                pawns[2].X == 3 && pawns[2].Player == !x)
            {
                return pawns[2];
            }
            // [ , , X,X,O]
            if (pawns[0].X == 2 && pawns[0].Player == x &&
                pawns[1].X == 3 && pawns[1].Player == x &&
                pawns[2].X == 4 && pawns[2].Player == !x)
            {
                return pawns[2];
            }
            // [ , ,O,X,X]
            if (pawns[0].X == 2 && pawns[0].Player == !x &&
                pawns[1].X == 3 && pawns[1].Player == x &&
                pawns[2].X == 4 && pawns[2].Player == x)
            {
                return pawns[0];
            }
            // [ ,O,X,X, ]
            if (pawns[0].X == 1 && pawns[0].Player == !x &&
                pawns[1].X == 2 && pawns[1].Player == x &&
                pawns[2].X == 3 && pawns[2].Player == x)
            {
                return pawns[0];
            }
            // [O,X,X, , ]
            if (pawns[0].X == 0 && pawns[0].Player == !x &&
                pawns[1].X == 1 && pawns[1].Player == x &&
                pawns[2].X == 2 && pawns[2].Player == x)
            {
                return pawns[0];
            }
            // nic :<
            return null;
        }

        private class PawnPosition
        {
            public int X, Y;
            public bool Player;

            public override string ToString()
            {
                return $"{(Player ? "Player's" : "Opponent's")} pawn: [X = {X}][Y = {Y}] ";
            }
        }
    }
}
