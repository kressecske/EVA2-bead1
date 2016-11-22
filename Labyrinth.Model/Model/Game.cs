using Labyrinth.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Labyrinth.Model
{
    public class Game
    {
        private int gameSize;
        private Dictionary<Coordinate, Field> gameBoard;
        private Player player;

        public Boolean gamePaused {get;private set;}
        public int time { get; private set; }
        private Timer timer;
        private IDataCommunication dataCommunication = new MyDataDirector();
        public event EventHandler<Boolean> gameEnd;
        public event EventHandler<EventArgs> newGameStarted;
        public event EventHandler<int> newTime;

        public void newGame(int gameSize, Dictionary<Coordinate, Field> gameBoard)
        {
            this.gameSize = gameSize;
            this.gameBoard = gameBoard;
            player = new Player(gameSize - 1, 0);
            gamePaused = false;
            refreshVisibility();
            
            #region timer
            if(timer != null)
            {
                timer.Stop();
            }
            time = 0;
            timer = new Timer(1000);
            timer.Elapsed += TimeAdded;
            timer.Start();
            #endregion

            if(newGameStarted != null)
                newGameStarted(this, EventArgs.Empty);
        }

        private void TimeAdded(object sender, ElapsedEventArgs e)
        {
            time = time + 1;
            if(newTime != null)
                newTime(this, time);
        }

        public void pauseResumeGame()
        {
            if (gamePaused)
            {
                timer.Start();
            }
            else
            {
                timer.Stop();
            }
            gamePaused = !gamePaused;
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
            if (gamePaused)
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
                gameEnded();
            }
            return true;
        }

        private void gameEnded()
        {
            gamePaused = true;
            timer.Stop();
            gameEnd(this, true);
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

        private void refreshVisibility()
        {
            foreach(Field f in gameBoard.Values)
            {
                if(Math.Abs(f.X-player.X) <= 2 && Math.Abs(f.Y-player.Y) <= 2)
                {
                    f.Visible = true;
                }
                else
                {
                    f.Visible = false;
                }
            }
            for (int i = 0; i < gameSize; i++)
            {
                if (!isNextFieldAvaiable(player.Coords, Move.UP))
                {
                    Coordinate c = new Coordinate(player.X - 2, i);
                    if (gameBoard.ContainsKey(c))
                    {
                        gameBoard[c].Visible = false;
                    }
                }
                if (!isNextFieldAvaiable(player.Coords, Move.DOWN))
                {

                    Coordinate c = new Coordinate(player.X + 2, i);
                    if (gameBoard.ContainsKey(c))
                    {
                        gameBoard[c].Visible = false;
                    }
                }
                if (!isNextFieldAvaiable(player.Coords, Move.LEFT))
                {

                    Coordinate c = new Coordinate(i, player.Y - 2);
                    if (gameBoard.ContainsKey(c))
                    {
                        gameBoard[c].Visible = false;
                    }
                }
                if (!isNextFieldAvaiable(player.Coords, Move.RIGHT))
                {

                    Coordinate c = new Coordinate(i, player.Y + 2);
                    if (gameBoard.ContainsKey(c))
                    {
                        gameBoard[c].Visible = false;
                    }
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

        public Dictionary<Coordinate,Field> GameBoard
        {
            get { return gameBoard; }
        }

    }
}
