using Labyrinth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth.Data
{
    public abstract class ALevel
    {
        public int gameSize;
        public Dictionary<Coordinate, Field> gameBoard = new Dictionary<Coordinate, Field>();
    }
}
