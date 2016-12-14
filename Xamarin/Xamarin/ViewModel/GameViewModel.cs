using Labyrinth.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFView.ViewModel
{
    public class GameViewModel : ViewModelBase
    {
        #region Fields
        private Game _model;
        #endregion

        #region Properties
        public DelegateCommand NewGameCommand { get; private set; }
        public DelegateCommand LoadGameCommand { get; private set; }
        public DelegateCommand StepCommand { get; private set; }
        public String time { get { return TimeSpan.FromSeconds(_model.time).ToString("g"); } }
        public ObservableCollection<GameField> Fields { get; set; }
        public int GameSize { get; set; }


        #endregion

        #region Events
        public event EventHandler NewGame;
        public event EventHandler LoadGame;
        #endregion
        #region Constructor
        public GameViewModel(Game model)
        {
            // játék csatlakoztatása
            _model = model;
            _model.gameEnd += new EventHandler<Boolean>(Model_GameOver);
            _model.newTime += new EventHandler<int>(Model_NewTime);
            _model.newGameStarted += new EventHandler<EventArgs>(Model_NewGame);

            // parancsok kezelése
            NewGameCommand = new DelegateCommand(param => { OnNewGame(); RefreshTable(); });
            LoadGameCommand = new DelegateCommand(param => { OnLoadGame(); RefreshTable(); });
            StepCommand = new DelegateCommand(param => { StepGame(param.ToString()); });
            // játéktábla létrehozása
            Fields = new ObservableCollection<GameField>();
            if (_model.getFields() == null)
                return;
            foreach (Field field in _model.getFields())
            {
                Fields.Add(new GameField
                {
                    Type = field.Type,
                    Visibile = field.Visible,
                    X = field.X,
                    Y = field.Y,
                });
            }
                RefreshTable();
        }
        #endregion

        #region Private Methods
        private void StepGame(String key)
        {
            Boolean successFullMove = false;
            switch (key) // megkapjuk a billentyűt
            {
                case "W":
                    successFullMove = _model.movePlayer(Move.UP);
                    break;
                case "A":
                    successFullMove = _model.movePlayer(Move.LEFT);
                    break;
                case "S":
                    successFullMove = _model.movePlayer(Move.DOWN);
                    break;
                case "D":
                    successFullMove = _model.movePlayer(Move.RIGHT);
                    break;
                default:
                    break;
            }
            if (successFullMove)
            {
                RefreshTable();
            }
        }
        private void RefreshTable()
        {
            foreach (GameField field in Fields) // inicializálni kell a mezőket is
            {
                field.Type = _model.GameBoard[new Coordinate(field.X, field.Y)].Type;
                field.Visibile = _model.GameBoard[new Coordinate(field.X, field.Y)].Visible;
                if (_model.Player.X == field.X && _model.Player.Y == field.Y)
                {
                    field.Type = FieldType.PLAYER;
                }

            }
        }

        #endregion

        #region Model Events
        private void Model_GameOver(object sender, Boolean e)
        {
            if (e)
            {
                RefreshTable();
                //MessageBox.Show("You Won", "Game Finished");
            }
        }

        private void Model_NewTime(object sender, int e)
        {
            OnPropertyChanged("time");
        }

        private void Model_NewGame(object sender, EventArgs e)
        {
            GameSize = _model.GameSize;
            OnPropertyChanged("GameSize");
            Fields.Clear();
            foreach (Field field in _model.getFields())
            {
                Fields.Add(new GameField
                {
                    Type = field.Type,
                    Visibile = field.Visible,
                    X = field.X,
                    Y = field.Y,
                });
            }
            OnPropertyChanged("time");
            RefreshTable();
        }

        #endregion

        #region Event Methods
        private void OnNewGame()
        {
            if (NewGame != null)
                NewGame(this, EventArgs.Empty);
        }

        private void OnLoadGame()
        {
            if (LoadGame != null)
                LoadGame(this, EventArgs.Empty);
        }
        #endregion

    }
}
