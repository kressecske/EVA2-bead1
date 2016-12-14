using Labyrinth.Data;
using Labyrinth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPFView.ViewModel;
using Xamarin.Forms;
using Xamarin.View;

namespace Xamarin
{
    public class App : Application
    {
        #region Fields

        private IDataCommunication _gameData;
        private Game _labyrinthGameModel;
        private GameViewModel _labyrinthViewModel;
        private GamePage _gamePage;

        private Boolean _advanceTimer;
        private NavigationPage _mainPage;
        ALevel level1 = new Level1();

        #endregion

        public App()
        {
            // játék összeállítása
            //_sudokuDataAccess = DependencyService.Get<ISudokuDataAccess>(); // az interfész megvalósítását automatikusan megkeresi a rendszer

            _labyrinthGameModel = new Game();
            _labyrinthGameModel.gameEnd += new EventHandler<Boolean>(Model_GameOver);
            

            // nézemodell létrehozása
            _labyrinthViewModel = new GameViewModel(_labyrinthGameModel);
            _labyrinthViewModel.NewGame += new EventHandler(ViewModel_NewGame);
            _labyrinthViewModel.LoadGame += new EventHandler(ViewModel_LoadGame);
            _labyrinthGameModel.newGame(level1.gameSize, level1.gameBoard);

            _gamePage = new GamePage();
            _gamePage.BindingContext = _labyrinthViewModel;

            // nézet beállítása
            _mainPage = new NavigationPage(_gamePage); // egy navigációs lapot használunk fel a három nézet kezelésére

            MainPage = _mainPage;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        #region ViewModel event handlers
        private void ViewModel_NewGame(object sender, EventArgs e)
        {
            _labyrinthGameModel.newGame(level1.gameSize, level1.gameBoard);
        }
        private async void ViewModel_LoadGame(object sender, System.EventArgs e)
        {
            try
            {
                var answer = await _mainPage.DisplayActionSheet("Choose level", "Cancel", null, "Level 1", "Level 2", "Level 3");
                switch (answer)
                {
                    case "Level 1":
                        _labyrinthGameModel.loadLevel(new Level1().ToString());
                        break;
                    case "Level 2":
                        string level2 = "R W R R R R R R W R\nR W W R W W W R W R\nR R R R W R W R W R\nR W W W W R W R R R\nR W R R R R W W W W\nR W R R W R R R R R\nR W W W W W W R W W\nR R R R R R R R W R\nR W W R R W W W W R\nR W R R R R R R R R";
                        _labyrinthGameModel.loadLevel(level2);
                        break;
                    case "Level 3":
                        string level3 = "R W R W W R W R R R R R R\nR R R W R R W W W W W R W\nR W R R R R R R R R R R R\nR W W W W R W W W W W W W\nR W W W W R W W W R W W W\nR R R W R R R R R R R R R\nR W R W W W W W W W W R W\nR W R R R R R R R R W R W\nR W R W W R W R W W W R R\nR R R R R R W R W W W W R\nR W W R W R W R R R R W R\nR W W R W R W R W W R W R\nR R R R R R R R R R R R R";
                        _labyrinthGameModel.loadLevel(level3);
                        break;
                    default:
                        break;
                }
            }
            catch (DataException)
            {
                _mainPage.DisplayAlert("Error!", "Something went wrong. Sorry! :)", "OK");
            }
        }

        #endregion

        private void Model_GameOver(object sender, Boolean e)
        {
            if (e)
            {
                //MessageBox.Show("You Won", "Game Finished");
                _mainPage.DisplayAlert("Game Over!", "Congrats!\n You Have Won!", "OK");
            }
        }
    }
}
