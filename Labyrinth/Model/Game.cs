using Labyrinth.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth.Model
{
    class Game
    {
        private int gameSize;
        private Dictionary<Coordinate, Field> gameBoard;
        private Player player;
        private Boolean gameFinished = false;
        private IDataCommunication dataCommunication = new MyDataDirector();
        public event EventHandler<Boolean> gameEnd;
        public event EventHandler newGameStarted;

        public void newGame(int gameSize, Dictionary<Coordinate, Field> gameBoard)
        {
            this.gameSize = gameSize;
            this.gameBoard = gameBoard;
            player = new Player(gameSize - 1, 0);
            refreshVisibility();
            newGameStarted(this, null);
    }

        public void loadLevel(string file)
        {
            ALevel level = dataCommunication.loadLevel(file);
            newGame(level.gameSize, level.gameBoard);
        }

        public Player Player
        {
            get { return player; }
        }

        public int GameSize
        {
            get { return gameSize; }
        }

        public Boolean movePlayer(Move move)
        {
            if (gameFinished)
            {
                return false;
            }
            switch (move)
            {
                case Move.UP:
                    if (player.X <= 0 || !isNextFieldAvaiable(new Coordinate(player.X,player.Y),move))
                    {
                        return false;
                    }
                    break;
                case Move.DOWN:
                    if (player.X >= gameSize - 1 || !isNextFieldAvaiable(new Coordinate(player.X, player.Y), move))
                    {
                        return false;
                    }
                    break;
                case Move.LEFT:
                    if (player.Y <= 0 || !isNextFieldAvaiable(new Coordinate(player.X, player.Y), move))
                    {
                        return false;
                    }
                    break;
                case Move.RIGHT:
                    if (player.Y >= gameSize - 1 || !isNextFieldAvaiable(new Coordinate(player.X, player.Y), move))
                    {
                        return false;
                    }
                    break;
            }
            player.movePlayer(move);
            refreshVisibility();
            if(player.X == 0 && player.Y == gameSize -1)
            {
                gameFinished = true;
                gameEnd(this, gameFinished);
            }
            return true;
        }


        public Boolean isFieldOnBoard(Coordinate p)
        {
            return gameBoard.ContainsKey(p);
        }

        public Boolean isNextFieldAvaiable(Coordinate player, Move move)
        {
            Coordinate p = new Coordinate(player);
            switch (move)
            {
                case Move.UP:
                    p.X = p.X - 1;
                    if( !isFieldOnBoard(p) || gameBoard[p].Type == FieldType.WALL)
                    {
                        return false;
                    }
                    break;
                case Move.DOWN:
                    p.X = p.X + 1;
                    if (!isFieldOnBoard(p) || gameBoard[p].Type == FieldType.WALL)
                    {
                        return false;
                    }
                    break;
                case Move.LEFT:
                    p.Y = p.Y - 1;
                    if (!isFieldOnBoard(p) || gameBoard[p].Type == FieldType.WALL)
                    {
                        return false;
                    }
                    break;
                case Move.RIGHT:
                    p.Y = p.Y + 1;
                    if (!isFieldOnBoard(p) || gameBoard[p].Type == FieldType.WALL)
                    {
                        return false;
                    }
                    break;
                }
                return true;
        }

        public void refreshVisibility()
        {
            //TODO
            foreach (Field field in gameBoard.Values)
            {
                int xDest = field.X - player.X;
                int yDest = field.Y - player.Y;
                if (Math.Abs(xDest) <= 2 && Math.Abs(yDest) <= 2)
                {
                    field.Visible = true;
                    //UP LEFT
                    if(xDest == -1 && yDest == -1)
                    {
                        if(field.Type == FieldType.WALL)
                        {

                        }
                    }
                    //UP
                    if (xDest == -1 && yDest == 0)
                    {
                        field.Visible = false;
                    }
                    //UP RIGHT
                    if (xDest == -1 && yDest == 1)
                    {
                        field.Visible = false;
                    }
                    //RIGHT
                    if (xDest == 0 && yDest == 1)
                    {
                        field.Visible = false;
                    }
                    //DOWN RIGHT
                    if (xDest == 1 && yDest == 1)
                    {
                        field.Visible = false;
                    }
                    //DOWN
                    if (xDest == 1 && yDest == 0)
                    {
                        field.Visible = false;
                    }
                    //DOWN LEFT
                    if (xDest == 1 && yDest == -1)
                    {
                        field.Visible = false;
                    }
                    //LEFT
                    if (xDest == 0 && yDest == -1)
                    {
                        field.Visible = false;
                    }
                }
                else
                {
                    field.Visible = false;
                }
            }
        }
        public Field getField(int x,int y)
        {
            return gameBoard[new Coordinate(x, y)];
        }

        public List<Field> getFields()
        {
            if(gameBoard != null)
            {
                return gameBoard.Values.ToList();
            }
            return null;
        }

    }
}
