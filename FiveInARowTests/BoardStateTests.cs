using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Gomoku;

namespace FiveInARowTests {
    [TestClass]
    public class BoardStateTests {

        [TestMethod]
        public void Fits_TooSmallDoesntFit_Test() {
            BoardState boardState = new BoardState(5, 5);
            Position invalidPosition = new Position(-1, 3);

            bool fits = boardState.Fits(invalidPosition);

            Assert.IsFalse(fits);
        }

        [TestMethod]
        public void Fits_TooLargeDoesntFit_Test() {
            BoardState boardState = new BoardState(5, 5);
            Position invalidPosition = new Position(5, 1);

            bool fits = boardState.Fits(invalidPosition);

            Assert.IsFalse(fits);
        }

        [TestMethod]
        public void Fits_WithinRangeFits_Test() {
            BoardState boardState = new BoardState(5, 5);
            Position validPosition = new Position(3, 3);

            bool fits = boardState.Fits(validPosition);

            Assert.IsTrue(fits);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetCellsContentAtPosition_FailsForInvalidPosition_Test() {
            BoardState boardState = new BoardState(5, 5);
            Position invalidPosition = new Position(5, 1);

            CellContent content = boardState.GetCellsContentAtPosition(invalidPosition);
        }

        [TestMethod]
        public void GetCellsContentAtPosition_ValidEmptyPosition_Test() {
            BoardState boardState = new BoardState(5, 5);
            Position validPosition = new Position(3,3);

            CellContent content = boardState.GetCellsContentAtPosition(validPosition);
            Assert.IsTrue(content == CellContent.Empty);
        }

        [TestMethod]
        public void GetCellsContentAtPosition_ValidTakenPosition_Test() {
            BoardState boardState = new BoardState(5, 5);
            Position validPosition = new Position(3, 3);
            boardState.SetCellsContentAtPosition(validPosition, CellContent.PlayerX);

            CellContent content = boardState.GetCellsContentAtPosition(validPosition);
            Assert.IsTrue(content == CellContent.PlayerX);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetCellsContentAtPosition_InvalidPosition_Test() {
            BoardState boardState = new BoardState(5, 5);
            Position invalidPosition = new Position(5, 1);
            boardState.SetCellsContentAtPosition(invalidPosition, CellContent.PlayerX);
        }

        [TestMethod]
        public void SetCellsContentAtPosition_ValidPosition_Test() {
            BoardState boardState = new BoardState(5, 5);
            Position validPosition = new Position(3, 3);
            boardState.SetCellsContentAtPosition(validPosition, CellContent.PlayerX);

            CellContent content = boardState.GetCellsContentAtPosition(validPosition);
            Assert.IsTrue(content == CellContent.PlayerX);
        }

        [TestMethod]
        public void Clone_newBoardIsACopyNotSameObject_Test() {
            BoardState boardStateOriginal = new BoardState(5, 5);
            BoardState boardStateCopied = (BoardState)boardStateOriginal.Clone();
            Position position = new Position(3, 3);
            boardStateCopied.SetCellsContentAtPosition(position, CellContent.PlayerX);
            Assert.IsTrue(boardStateOriginal.GetCellsContentAtPosition(position) == CellContent.Empty);
        }


        /// <summary>
        /// [-,-,-,-,-],
        /// [-,X,-,-,-],
        /// [O,O,O,O,O],
        /// [O,X,-,-,-],
        /// [-,-,-,-,-]
        /// </summary>
        [TestMethod]
        public void LineParams_ComplicatedSituation_Test() {
            BoardState boardState = new BoardState(5, 5);
            boardState.SetCellsContentAtPosition(new Position(2, 4), CellContent.PlayerO);
            boardState.SetCellsContentAtPosition(new Position(2, 3), CellContent.PlayerO);
            boardState.SetCellsContentAtPosition(new Position(2, 2), CellContent.PlayerO);
            boardState.SetCellsContentAtPosition(new Position(2, 1), CellContent.PlayerO);
            boardState.SetCellsContentAtPosition(new Position(2, 0), CellContent.PlayerO);

            boardState.SetCellsContentAtPosition(new Position(3, 0), CellContent.PlayerO);
            boardState.SetCellsContentAtPosition(new Position(3, 1), CellContent.PlayerX);
            boardState.SetCellsContentAtPosition(new Position(1, 1), CellContent.PlayerX);

            LineParams[] lineParams = boardState.CellsLineParams(new Position(2, 1));
            Assert.AreEqual(lineParams[0].Length, 1);
            Assert.AreEqual(lineParams[1].Length, 2);
            Assert.AreEqual(lineParams[2].Length, 1);
            Assert.AreEqual(lineParams[3].Length, 5);
            Assert.AreEqual(lineParams[0].OpenEnds, 2);
            Assert.AreEqual(lineParams[1].OpenEnds, 1);
            Assert.AreEqual(lineParams[2].OpenEnds, 0);
            Assert.AreEqual(lineParams[3].OpenEnds, 0);
        }


    }
}