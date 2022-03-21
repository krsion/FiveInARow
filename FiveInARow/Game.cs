using System;

namespace FiveInARow {

    /// <summary>
    /// Controller class containing game logic.
    /// </summary>
    public class Game {
        private BoardState board;
        private bool playerBegins = true;
        private bool isPlayersTurn = true;
        private bool isGame = true;

        /// <summary>
        /// Checks if given position is in a winning line.
        /// </summary>
        public bool CheckForWinner(int x, int y) {
            LineParams[] cellParams = board.CellsLineParams(x, y);
            foreach (LineParams lineParams in cellParams) {
                if (lineParams.Length == board.WinnerLineLength)
                    return true;
            }
            return false;
        }

        public event Action GameOver = delegate { };

        public Game(BoardState board) {
            this.board = board;
        }

        /// <summary>
        /// Given player's choice of coordinates where to place their symbol, makes sure it's valid, saves the move and lets the bot play or ends the game.
        /// </summary>
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

        /// <summary>
        /// Resets the game. Now first move has the one who didn't have it last time.
        /// </summary>
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
