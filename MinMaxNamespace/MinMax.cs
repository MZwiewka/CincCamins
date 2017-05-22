using CincCamins.MinMaxNamespace;
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
        public static TreeNode<GameStatus> root = null;
        /// <summary>
        /// Proteza :>
        /// </summary>
        public static GameStatus CountAIMove(GameStatus game)
        {
            root = new TreeNode<GameStatus>(game);
            BuildTree(root, false, 0);
            var g = MiniMax(root, 6, true);
            /// 3. Odpalamy minimaksa, który ocenia najlepszy ruch
            /// 4. Zwracamy GameStatus określający najlepszy ruch (najlepszy korzeń drzewa min-max)

            /// kopiowanie GameStatus:
            var newGameRoot = new GameStatus(g.Data);
            return newGameRoot;
        }

        static Random rnd = new Random();

        /*public static GameStatus MiniMax(TreeNode<GameStatus> game, int depth, bool maximizingPlayer)
        {
            if (depth == 0 || game.Children.Count() == 0)
            {
                return game.Data;
            }
            if (maximizingPlayer == true)
            {
                int bestValue = -10;
                GameStatus best = game.Data;
                --depth;
                foreach (var child in game.Children)
                {
                    var v = MiniMax(child, depth, false);
                    if (bestValue < v.Value)
                    {
                        best = v;
                    }
                    //bestValue = Math.Max(bestValue.Value, v.Value);
                }
                return best;
            }
            else
            {
                int bestValue = 10;
                GameStatus best = game.Data;
                --depth;
                foreach (var child in game.Children)
                {
                    var v = MiniMax(child, depth, true);
                    if (bestValue > v.Value)
                    {
                        best = v;
                    }
                    //bestValue = Math.Min(bestValue.Value, v.Value);
                }
                return best;
            }
        }*/

        public static TreeNode<GameStatus> MiniMax(TreeNode<GameStatus> game, int depth, bool maximizingPlayer)
        {
            if (depth == 0 || game.Children.Count() == 0)
            {
                return game;
            }
            if (maximizingPlayer == true)
            {
                TreeNode<GameStatus> bestValue = game.Children.ElementAt(0);
                --depth;
                foreach (var child in game.Children)
                {
                    var v = MiniMax(child, depth, false);
                    if (v.Data.PlayerBeatings == 1)
                    {
                        bestValue = v;
                    }
                    else if (bestValue.Data.PlayerBeatings < 1 && v.Data.PlayerBeatings == 0)
                    {
                        int r= rnd.Next(game.Children.Count);
                        bestValue = game.Children.ElementAt(r);
                    }
                    //bestValue.OpponentBeatings = Math.Max(bestValue.OpponentBeatings, v.OpponentBeatings);
                }
                return bestValue;
            }
            else
            {
                TreeNode<GameStatus> bestValue = game.Children.ElementAt(0);
                --depth;
                foreach (var child in game.Children)
                {
                    var v = MiniMax(child, depth, true);
                    if(v.Data.PlayerBeatings == 0)
                    {
                        bestValue = v;
                    }

                    //bestValue.OpponentBeatings = Math.Min(bestValue.OpponentBeatings, v.OpponentBeatings);
                }
                return bestValue;
            }
        }

        public static void BuildTree(TreeNode<GameStatus> r, bool x, int level)
        {
            if (level == 6)
                return;
            var moves = FindMovesForRoot(r.Data, x);
            foreach (var move in moves)
            {
                r.AddChild(CheckBeatings(move));
            }
            ++level;
            foreach (var child in r.Children)
            {
                BuildTree(child, !x, level);
            }
        }

        public static List<GameStatus> FindMovesForRoot(GameStatus root, bool isPlayer)
        {
            var p = root.Pawns;
            var result = new List<GameStatus>();

            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    // Jeśli null lub należy do innego gracza to jedziemy dalej
                    if (p[x, y] == null || p[x, y].Player != isPlayer) continue;

                    // Sprawdzanie ruchu w lewo
                    if (x > 0 && p[x - 1, y] == null)
                    {
                        var newRoot = new GameStatus(root);
                        newRoot.Pawns[x - 1, y] = p[x, y];
                        newRoot.Pawns[x, y] = null;

                        result.Add(newRoot);
                    }

                    // Sprawdzanie ruchu w prawo
                    if (x < 4 && p[x + 1, y] == null)
                    {
                        var newRoot = new GameStatus(root);
                        newRoot.Pawns[x + 1, y] = p[x, y];
                        newRoot.Pawns[x, y] = null;

                        result.Add(newRoot);
                    }

                    // Sprawdzanie ruchu do góry
                    if (y > 0 && p[x, y - 1] == null)
                    {
                        var newRoot = new GameStatus(root);
                        newRoot.Pawns[x, y - 1] = p[x, y];
                        newRoot.Pawns[x, y] = null;

                        result.Add(newRoot);
                    }

                    // Sprawdzanie ruchu w dół
                    if (y < 4 && p[x, y + 1] == null)
                    {
                        var newRoot = new GameStatus(root);
                        newRoot.Pawns[x, y + 1] = p[x, y];
                        newRoot.Pawns[x, y] = null;

                        result.Add(newRoot);
                    }
                }
            }
            return result;
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
            if(game.PlayerBeatings==1)
            {
                game.Value += 5;
            }
            else if (game.PlayerBeatings==2)
            {
                game.Value += 10;
            }
            game.OpponentBeatings = beatings.Count(b => !b.Player);
            if (game.OpponentBeatings == 1)
            {
                game.Value -= 5;
            }
            else if (game.OpponentBeatings == 2)
            {
                game.Value -= 10;
            }
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
                pawns[2].Y == 2 && pawns[2].Player == x)
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
