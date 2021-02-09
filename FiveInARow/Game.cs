using System;
using System.Collections.Generic;
using System.Text;

public class LineParams {
    public int Length = 1;
    public bool PositiveEndOpen = true;
    public bool NegativeEndOpen = true;
}

namespace FiveInARow {
    public class Game {
        private Board board;
        private bool playerBegins = true;
        private bool isPlayersTurn = true;
        private bool isGame = true;

        public bool CheckForWinner(int x, int y) {
            LineParams[] cellParams = board.CellParams(x, y);
            foreach (LineParams lineParams in cellParams) {
                if (lineParams.Length == board.WinnerLineLength)
                    return true;
            }
            return false;
        }

        public event Action GameOver = delegate { };

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
                GameOver();
                return;
            }
            (int X, int Y) botMove = Bot.Move(board);
            if (board.GetCell(botMove.X, botMove.Y) == CellContent.Empty) {
                board.SetCell(botMove.X, botMove.Y, CellContent.Bot);
            }
            isPlayersTurn = true;
            if (CheckForWinner(botMove.X, botMove.Y)) {
                isGame = false;
                GameOver();
                return;
            }
        }

        public void Reset() {
            board.Reset();
            isGame = true;
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
