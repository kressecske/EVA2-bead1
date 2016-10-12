using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth.Model
{
    public class Player
    {
        Coordinate coords;

        public Player(int x,int y)
        {
            coords = new Coordinate(x, y);
        }

        public void movePlayer(Move move)
        {
            switch (move)
            {
                case Move.UP:
                    coords.X = coords.X - 1;
                    break;
                case Move.DOWN:
                    coords.X = coords.X + 1;
                    break;
                case Move.LEFT:
                    coords.Y = coords.Y - 1;
                    break;
                case Move.RIGHT:
                    coords.Y = coords.Y + 1;
                    break;
            }
        }

        public Coordinate Coords
        {
            get { return coords; }
        }
        public int X
        {
            get { return coords.X; }
        }
        public int Y
        {
            get { return coords.Y; }
        }
    }
}
