using System;

namespace Gomoku {

    /// <summary>
    /// Controller class containing game logic.
    /// </summary>
    public class Game {
        private BoardState board;
        private Bot bot;
        private bool xBegins = true;
        private bool isXsTurn = true;
        private bool isGame = true;
        private bool isPlayerVsPlayer = false;

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
        public void Move(Position position) {
            if (!isGame || board.GetCellsContentAtPosition(position) != CellContent.Empty) return;
            if (isPlayerVsPlayer) {
                if (isXsTurn) {
                    board.SetCell(position, CellContent.X);
                } else {
                    board.SetCell(position, CellContent.O);
                }
                isXsTurn = !isXsTurn;

                if (CheckForWinner(position)) {
                    isGame = false;
                    GameOver();
                    return;
                }
            } else {
                if (!isXsTurn) return;
                board.SetCell(position, CellContent.X);
                if (CheckForWinner(position)) {
                    isGame = false;
                    GameOver();
                    return;
                }

                Position botMove = bot.Move(board);
                board.SetCell(botMove, CellContent.O);
                if (CheckForWinner(botMove)) {
                    isGame = false;
                    GameOver();
                    return;
                }
            }
        }

        /// <summary>
        /// Resets the game. Now first move has the one who didn't have it last time.
        /// </summary>
        public void Reset() {
            board.Reset();
            isGame = true;
            xBegins = !xBegins;
            isXsTurn = xBegins;
            if (xBegins)
                return;
            if (!isPlayerVsPlayer) {
                Position position = bot.Move(board);
                board.SetCell(position, CellContent.O);
                isXsTurn = true;
            }
        }

        internal void PlayerVsBot() {
            isPlayerVsPlayer = false;
            Reset();
            
        }

        internal void PlayerVsPlayer() {
            isPlayerVsPlayer = true;
            Reset();
        }
    }
}
