using System;

namespace FiveInARow {
    public class Game {
        private GomokuBoardState board;
        private bool playerBegins = true;
        private bool isPlayersTurn = true;
        private bool isGame = true;

        public bool CheckForWinner(int x, int y) {
            LineParams[] cellParams = board.CellsLineParams(x, y);
            foreach (LineParams lineParams in cellParams) {
                if (lineParams.Length == board.WinnerLineLength)
                    return true;
            }
            return false;
        }

        public event Action GameOver = delegate { };

        public Game(GomokuBoardState board) {
            this.board = board;
        }
        public void PlayerMove(int x, int y) {
            if (!isGame || !isPlayersTurn || board.GetCellsContentAtPosition(x, y) != CellContent.Empty) 
                return;
            board.SetCell(x, y, CellContent.Player);
            isPlayersTurn = false;
            if (CheckForWinner(x,y)) {
                isGame = false;
                GameOver();
                return;
            }
            (int X, int Y) botMove = Bot.Move(board);
            if (board.GetCellsContentAtPosition(botMove.X, botMove.Y) == CellContent.Empty) {
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

            (int X, int Y) = Bot.Move(board);
            if (board.GetCellsContentAtPosition(X, Y) == CellContent.Empty) {
                board.SetCell(X, Y, CellContent.Bot);
            }
            isPlayersTurn = true;
        }
    }
}
