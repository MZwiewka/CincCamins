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

        public Pawn(int number, Font font)
        {
            Number = number;
            NumText = new Text(number.ToString(), font)
            {
                Color = Color.Black,
                CharacterSize = 100,
            };
        }

        public new Vector2f Position {
            get { return base.Position; }
            set {
                base.Position = value;
                NumText.Position = value + new Vector2f(25f, -25f);
            }
        }
    }
}
