using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SFML.Graphics;

namespace CincCamins
{
    public partial class SFMLRenderControl : UserControl
    {
        private RenderWindow window = null;

        public SFMLRenderControl()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (window == null) base.OnPaint(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (window == null) base.OnPaintBackground(e);
        }
    }
}
