using Labyrinth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth.Data
{
    public class Level : ALevel
    {
        public Level(int gameSize, Dictionary<Coordinate, Field> gameBoard)
        {
            this.gameSize = gameSize;
            this.gameBoard = gameBoard;
        }
    }
}
