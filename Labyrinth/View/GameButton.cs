using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Labyrinth.View
{
    class GameButton : Button
    {
        Point position;
        public GameButton()
        {
            this.Height = 100;
            this.Width = 100;
            this.Enabled = false;
            this.BackgroundImage = Properties.Resources.greensprite1;
            this.Padding = new Padding(0,0,0,0);
            this.Margin = new Padding(0,0,0,0);
            this.ForeColor = Color.Black;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Dock = DockStyle.Fill;
        }
    }
}