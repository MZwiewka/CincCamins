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
        /// 
        public static GameStatus CountAIMove(GameStatus game)
        {
            root = new TreeNode<GameStatus>(game);

            BuildTree(root, false, 0);
            GetValue(root, 0);
            var g = MiniMax(root, 7, true);
            int zz = 0;
            while (g.Parent.Parent != null)
                 g = g.Parent;

            var newGameRoot = new GameStatus(g.Data);
            return newGameRoot;
        }

        static Random rnd = new Random();
        public static TreeNode<GameStatus> MiniMax(TreeNode<GameStatus> game, int depth, bool maximizingPlayer)
        {
            if (depth == 0 ||  game.Children.Count() == 0)
            {
                return game;
            }
            if (maximizingPlayer == true)
            {
                int bestValue = -10000;
                TreeNode<GameStatus> best = game;
                --depth;

                foreach (var child in game.Children)
                {
                    var v = MiniMax(child, depth, false);
                    if (bestValue < v.Data.Value)
                    {
                        best = v;
                        bestValue = v.Data.Value;
                    }
                }
                return best;
            }
            else
            {
                int bestValue = 10000;
                TreeNode<GameStatus> best = game;
                --depth;
                foreach (var child in game.Children)
                {
                    var v = MiniMax(child, depth, true);
                    if (bestValue > v.Data.Value)
                    {
                        best = v;
                        bestValue = v.Data.Value;
                    }
                }
                return best;
            }
        }

        public static void GetValue(TreeNode<GameStatus> game, int z)
        {
        if(game.Parent!=null)
            {
                game.Data.Value += game.Parent.Data.Value;
            }
            int opponentPawns = 0;
            int playerPawns = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (game.Data.Pawns[i, j] != null)
                    {
                        if (game.Data.Pawns[i, j].Player == true)
                        {
                            opponentPawns++;
                        }
                        else
                        {
                            playerPawns++;
                        }
                    }
                }
            }
    /* if(game.Data.PlayerBeatings == 0 && z>0)
            {
                game.Data.Value += -1;
            }*/
            if (game.Data.PlayerBeatings == 1 && z==1)
            {
                game.Data.Value += 50;
            }
            else if (game.Data.PlayerBeatings == 2 && z==1)
            {
                game.Data.Value += 100;
            }
            if (game.Data.PlayerBeatings == 1 && z == 3)
            {
                game.Data.Value += 2;
            }
            else if (game.Data.PlayerBeatings == 2 && z == 3)
            {
                game.Data.Value += 4;
            }
            if (game.Data.PlayerBeatings == 1 && z == 5)
            {
                game.Data.Value += 1;
            }
            else if (game.Data.PlayerBeatings == 2 && z == 5)
            {
                game.Data.Value += 2;
            }
            if (opponentPawns == 0)
            {
                game.Data.Value += 1000;
            }
            if (playerPawns == 0)
            {
                game.Data.Value += -1000;
            }
            if (game.Data.OpponentBeatings == 1 && (z==2 || z==1))
            {
                game.Data.Value += -200;
            }
            else if (game.Data.OpponentBeatings == 2 && (z == 2 || z == 1))
            {
                game.Data.Value += -400;
            }
            if (game.Data.OpponentBeatings == 1 && (z == 4|| z == 3))
            {
                game.Data.Value += -100;
            }
            else if (game.Data.OpponentBeatings == 2 && (z == 4 || z == 3))
            {
                game.Data.Value += -200;
            }
            if (game.Data.OpponentBeatings == 1 && (z == 6 || z == 7))
            {
                game.Data.Value += -50;
            }
            else if (game.Data.OpponentBeatings == 2 && (z == 2 || z == 7))
            {
                game.Data.Value += -100;
            }
            ++z;
            foreach (var child in game.Children)
            {
                GetValue(child, z);
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
                        newRoot.Value += 1;
                        result.Add(newRoot);
                    }

                    // Sprawdzanie ruchu w prawo
                    if (x < 4 && p[x + 1, y] == null)
                    {
                        var newRoot = new GameStatus(root);
                        newRoot.Pawns[x + 1, y] = p[x, y];
                        newRoot.Pawns[x, y] = null;
                        newRoot.Value += 1;
                        result.Add(newRoot);
                    }

                    // Sprawdzanie ruchu do góry
                    if (y > 0 && p[x, y - 1] == null)
                    {
                        var newRoot = new GameStatus(root);
                        newRoot.Pawns[x, y - 1] = p[x, y];
                        newRoot.Pawns[x, y] = null;
                        newRoot.Value += 1;
                        result.Add(newRoot);
                    }

                    // Sprawdzanie ruchu w dół
                    if (y < 4 && p[x, y + 1] == null)
                    {
                        var newRoot = new GameStatus(root);
                        newRoot.Pawns[x, y + 1] = p[x, y];
                        newRoot.Pawns[x, y] = null;
                        newRoot.Value += 2;
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
