using Labyrinth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth.Data
{
    class Level2 : ALevel
    {
        public Level2()
        {
            this.gameSize = 10;
            for (int i = 0; i < gameSize; i++)
            {
                for (int j = 0; j < gameSize; j++)
                {
                    Field f = new Field(i, j, FieldType.ROAD);
                    if (i != 0 && j == 1)
                    {
                        f = new Field(i, j, FieldType.WALL);
                    }
                    if (i != gameSize - 1 && j == 3)
                    {
                        f = new Field(i, j, FieldType.WALL);
                    }

                    gameBoard.Add(new Coordinate(i, j), f);
                }
            }
        }
    }
}
