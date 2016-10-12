using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labyrinth.Model;
using Labyrinth.Data;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        Game model;
        [TestInitialize]
        public void Initialize() // teszt inicializálása
        {
            model = new Game();
        }

        [TestMethod]
        public void TestNewGame()
        {
            ALevel level = new Level1();
            try
            {
                model.newGame(level.gameSize, level.gameBoard);
            }
            catch { }
            Assert.AreEqual(model.time, 0);
            Assert.AreEqual(model.gamePaused,false);
            Assert.AreEqual(model.Player.Coords, new Coordinate(level.gameSize-1,0));
        }
        [TestMethod]
        public void MovePlayer()
        {
            ALevel level = new Level1();
            try
            {
                model.newGame(level.gameSize, level.gameBoard);
            }
            catch { }
            Assert.AreEqual(model.movePlayer(Move.DOWN), false);
            Assert.AreEqual(model.movePlayer(Move.LEFT), false);
            Assert.AreEqual(model.movePlayer(Move.RIGHT), false);
            Assert.AreEqual(model.movePlayer(Move.UP), true);

            Assert.AreEqual(model.Player.Coords, new Coordinate(model.GameSize-2,0));
            Assert.AreEqual(model.movePlayer(Move.LEFT), false);
            Assert.AreEqual(model.Player.Coords, new Coordinate(model.GameSize - 2, 0));
        }

        [TestMethod]
        public void ModelNextFieldTiest()
        {
            ALevel level = new Level1();
            try
            {
                model.newGame(level.gameSize, level.gameBoard);
            }
            catch { }
            Assert.AreEqual(model.isNextFieldAvaiable(new Coordinate(model.GameSize-1,0),Move.UP),true);
            Assert.AreEqual(model.isNextFieldAvaiable(new Coordinate(model.GameSize - 1, 0), Move.DOWN), false);
            Assert.AreEqual(model.isNextFieldAvaiable(new Coordinate(model.GameSize - 1, 0), Move.LEFT), false);
            Assert.AreEqual(model.isNextFieldAvaiable(new Coordinate(model.GameSize - 1, 0), Move.RIGHT), false);

            Assert.AreEqual(model.isNextFieldAvaiable(new Coordinate(0, 0), Move.UP), false);
            Assert.AreEqual(model.isNextFieldAvaiable(new Coordinate(0, 0), Move.DOWN), true);
            Assert.AreEqual(model.isNextFieldAvaiable(new Coordinate(0, 0), Move.LEFT), false);
            Assert.AreEqual(model.isNextFieldAvaiable(new Coordinate(0, 0), Move.RIGHT), true);
        }

    }
}
