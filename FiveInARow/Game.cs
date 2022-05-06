using System;

namespace Gomoku {

    /// <summary>
    /// Controller class containing game logic.
    /// </summary>
    public class Game {
        private BoardState board;
        private Bot bot;
        private bool playerBegins = true;
        private bool isPlayersTurn = true;
        private bool isGame = true;

        /// <summary>
        /// Checks if given position is in a winning line.
        /// </summary>
        public bool CheckForWinner(Position position) {
            LineParams[] cellParams = board.CellsLineParams(position);
            foreach (LineParams lineParams in cellParams) {
                if (lineParams.Length == board.WinnerLineLength)
                    return true;
            }
            return false;
        }

        public event Action GameOver = delegate { };

        public Game(BoardState board, Bot bot) {
            this.board = board;
            this.bot = bot;
        }

        /// <summary>
        /// Given player's choice of coordinates where to place their symbol, makes sure it's valid, saves the move and lets the bot play or ends the game.
        /// </summary>
        public void PlayerMove(Position position) {
            if (!isGame || !isPlayersTurn || board.GetCellsContentAtPosition(position) != CellContent.Empty) 
                return;
            board.SetCell(position, CellContent.Player);
            isPlayersTurn = false;
            if (CheckForWinner(position)) {
                isGame = false;
                GameOver();
                return;
            }
            Position botMove = bot.Move(board);
            if (board.GetCellsContentAtPosition(botMove) == CellContent.Empty) {
                board.SetCell(botMove, CellContent.Bot);
            }
            if (CheckForWinner(botMove)) {
                isGame = false;
                GameOver();
                return;
            }
            isPlayersTurn = true;
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

            Position position = bot.Move(board);
            if (board.GetCellsContentAtPosition(position) == CellContent.Empty) {
                board.SetCell(position, CellContent.Bot);
            }
            isPlayersTurn = true;
        }
    }
}
