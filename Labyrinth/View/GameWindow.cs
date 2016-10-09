﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Labyrinth.Model;
using Labyrinth.Data;
using System.IO;

namespace Labyrinth.View
{
    public partial class GameWindow : Form
    {
        private Game game;
        ALevel level1 = new Level1();
        ALevel level2 = new Level2();
        int picSize = 50;

        public GameWindow()
        {
            InitializeComponent();
            game = new Game();
            
            #region eventhandlers
            KeyDown += new KeyEventHandler(this.GameWindow_KeyDown);
            KeyPreview = true;
            newGameButton.Click += new System.EventHandler(newGame);
            loadButton.Click += new System.EventHandler(loadLevelClicked);

            game.gameEnd += new EventHandler<Boolean>(Game_GameEnd); // modell eseményének társítása
            game.newGameStarted += new EventHandler(newGameEvent);
            #endregion
            newGame(level1);
        }
        private void newGame(ALevel level)
        {
            this.Size = new Size(level.gameSize * picSize + 100, level.gameSize * picSize + 160);
            gameTable.Width = level.gameSize * 100;
            gameTable.Height = level.gameSize * 100;
            game.newGame(level.gameSize, level.gameBoard);
            drawGameTable();
        }
        private void newGameEvent(object sender, EventArgs e)
        {
            this.Size = new Size(game.GameSize * picSize + 100, game.GameSize * picSize + 160);
            gameTable.Width = game.GameSize * picSize;
            gameTable.Height = game.GameSize * picSize;
            drawGameTable();
        }
        private void newGame(object sen,EventArgs e)
        {
            newGame(level1);
        }
        private void loadLevelClicked(object sen, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    game.loadLevel(file);
                }
                catch (IOException)
                {
                }
            }
        }
        private void Game_GameEnd(object sender, Boolean e)
        {
            if (e)
            {
                drawGameTable();
                MessageBox.Show("You Won", "Game Finished");
            }
        }

        private void GameWindow_KeyDown(object sender, KeyEventArgs e)
        {
            Boolean successFullMove = false;
            switch (e.KeyCode) // megkapjuk a billentyűt
            {
                case Keys.W:
                    successFullMove = game.movePlayer(Model.Move.UP);
                    break;
                case Keys.A:
                    successFullMove = game.movePlayer(Model.Move.LEFT);
                    break;
                case Keys.S:
                    successFullMove = game.movePlayer(Model.Move.DOWN);
                    break;
                case Keys.D:
                    successFullMove = game.movePlayer(Model.Move.RIGHT);
                    break;
                default:
                    break;
            }
            if (successFullMove)
            {
                drawGameTable();
            }
        }
        
        public void drawGameTable()
        {

            Bitmap bitmap = new Bitmap(gameTable.Width, gameTable.Height); // kép létrehozása
            Graphics graphics = Graphics.FromImage(bitmap); // rajzeszköz a képre
            graphics.Clear(SystemColors.Control);

            foreach (Field field in game.getFields())
            {
                switch (field.Type)
                {
                    case FieldType.ROAD:
                        graphics.DrawImage(Properties.Resources.roadsprite, field.Y* picSize, field.X * picSize, picSize, picSize);
                        break;
                    case FieldType.WALL:
                        graphics.DrawImage(Properties.Resources.greensprite1, field.Y * picSize, field.X * picSize, picSize, picSize);
                        break;
                    default:
                        graphics.DrawImage(Properties.Resources.blacksprite, field.Y * picSize, field.X * picSize, picSize, picSize);
                        break;
                }
                if (!field.Visible)
                {
                    graphics.DrawImage(Properties.Resources.blacksprite, field.Y * picSize, field.X * picSize, picSize, picSize);
                }
                if (game.Player.X == field.X && game.Player.Y == field.Y)
                {
                    graphics.DrawImage(Properties.Resources._250px_007Squirtle, field.Y * picSize, field.X * picSize, picSize, picSize);
                }
            }

            gameTable.CreateGraphics().DrawImage(bitmap, 0, 0); // kép kirajzolása a panelre
        }
    }
}
