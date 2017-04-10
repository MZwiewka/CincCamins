using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CincCamins
{
    public static class Globals
    {
        private static Font font;
        public static Font FONT {
            get {
                return font ?? (font = new Font("consola.ttf"));
            }
        }

        public static bool WHO_IS_PLAYER = true;
    }
}
