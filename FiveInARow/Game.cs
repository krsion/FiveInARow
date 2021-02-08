using System;
using System.Collections.Generic;
using System.Text;

namespace FiveInARow {
    public class Game {
        private Board board;
        private bool playerBegins = true;
        private bool isPlayersTurn = true;
        private bool isGame = true;

        private bool CheckForWinner(int x, int y) {
            return false;
        }
        public Game(Board board) {
            this.board = board;
        }
        public void PlayerMove(int x, int y) {
            if (!isGame || !isPlayersTurn || board.GetCell(x, y) != CellContent.Empty) 
                return;
            board.SetCell(x, y, CellContent.Player);
            isPlayersTurn = false;
            if (CheckForWinner(x,y)) {
                isGame = false;
                //TODO: send event to view to draw the line
                return;
            }
            (int X, int Y) botMove = Bot.Move(board);
            if (board.GetCell(botMove.X, botMove.Y) == CellContent.Empty) {
                board.SetCell(botMove.X, botMove.Y, CellContent.Bot);
            }
            isPlayersTurn = true;
            if (CheckForWinner(botMove.X, botMove.Y)) {
                isGame = false;
                //TODO: send event to view to draw the line
                return;
            }
        }

        public void Reset() {
            board.Reset();
            playerBegins = !playerBegins;
            isPlayersTurn = playerBegins;
            if (playerBegins)
                return;

            (int X, int Y) botMove = Bot.Move(board);
            if (board.GetCell(botMove.X, botMove.Y) == CellContent.Empty) {
                board.SetCell(botMove.X, botMove.Y, CellContent.Bot);
            }
            isPlayersTurn = true;
        }
    }
}
