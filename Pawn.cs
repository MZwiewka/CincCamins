using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CincCamins
{
    public class Pawn : CircleShape
    {
        public int X, Y;
        public bool Player;
        public int Number;
        public Text NumText;

        public Pawn(int number, bool player)
        {
            if (player) FillColor = Color.Green;
            else FillColor = Color.Red;

            Radius = 50;
            Player = player;
            Number = number;
            NumText = new Text(number.ToString(), Globals.FONT)
            {
                Color = Color.Black,
                CharacterSize = 100,
            };
        }

        public new Vector2f Position {
            get { return base.Position; }
            set {
                base.Position = value;
                NumText.Position = value + new Vector2f(25f, -20f);
            }
        }

        public override string ToString()
        {
            return $"{(Player ? "Player's" : "Opponent's")} pawn number {Number}: [X = {X}][Y = {Y}] ";
        }
    }
}
