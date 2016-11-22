using Labyrinth.Data;
using Labyrinth.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPFView.ViewModel;

namespace WPFView
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Fields
        private Game _model;
        private GameViewModel _viewModel;
        private MainWindow _view;
        ALevel level1 = new Level1();
        #endregion


        #region Constructors

        /// <summary>
        /// Alkalmazás példányosítása.
        /// </summary>
        public App()
        {
            Startup += new StartupEventHandler(App_Startup);
        }

        #endregion

        #region Application event handlers

        private void App_Startup(object sender, StartupEventArgs e)
        {
            // modell létrehozása
            _model = new Game();
            _model.gameEnd += new EventHandler<Boolean>(Model_GameOver);

            _model.newGame(level1.gameSize, level1.gameBoard);

            // nézemodell létrehozása
            _viewModel = new GameViewModel(_model);
            _viewModel.NewGame += new EventHandler(ViewModel_NewGame);
            _viewModel.LoadGame += new EventHandler(ViewModel_LoadGame);


            // nézet létrehozása
            _view = new MainWindow();
            _view.DataContext = _viewModel;
            _view.Show();
        }
        #endregion

        #region ViewModel event handlers
        private void ViewModel_NewGame(object sender, EventArgs e)
        {
            _model.newGame(level1.gameSize, level1.gameBoard);
        }
        private void ViewModel_LoadGame(object sender, System.EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog(); // dialógusablak
                openFileDialog.Title = "Pálya betöltése";
                if (openFileDialog.ShowDialog() == true)
                {
                    // játék betöltése
                    _model.loadLevel(openFileDialog.FileName);
                }
            }
            catch (Labyrinth.Data.DataException)
            {
                MessageBox.Show("A fájl betöltése sikertelen!", "Labyrinth", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        #endregion

        private void Model_GameOver(object sender, Boolean e)
        {
            if (e)
            {
                MessageBox.Show("You Won", "Game Finished");
            }
        }

    }
}
