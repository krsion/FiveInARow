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
        public CellContent? CheckForWinner(Position position) {
            CellContent who = board.GetCellsContentAtPosition(position);
            LineParams[] cellParams = board.CellsLineParams(position);
            foreach (LineParams lineParams in cellParams) {
                if (lineParams.Length == board.WinnerLineLength)
                    return who;
            }
            return null;
        }

        public event Action<CellContent> GameOver = delegate { };

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
                    board.SetCellsContentAtPosition(position, CellContent.PlayerX);
                } else {
                    board.SetCellsContentAtPosition(position, CellContent.PlayerO);
                }
                isXsTurn = !isXsTurn;

                CellContent? winner = CheckForWinner(position);
                if (winner != null) {
                    isGame = false;
                    GameOver((CellContent)winner);
                    return;
                }
            } else {
                if (!isXsTurn) return;
                board.SetCellsContentAtPosition(position, CellContent.PlayerX);
                CellContent? winner = CheckForWinner(position);
                if (winner != null) {
                    isGame = false;
                    GameOver((CellContent)winner);
                    return;
                }

                Position botMove = bot.Move(board);
                board.SetCellsContentAtPosition(botMove, CellContent.PlayerO);
                CellContent? winner2 = CheckForWinner(botMove);
                if (winner2 != null) {
                    isGame = false;
                    GameOver((CellContent)winner2);
                    return;
                }
            }
            if (board.IsFull()) {
                isGame = false;
                GameOver(CellContent.Empty);
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
                board.SetCellsContentAtPosition(position, CellContent.PlayerO);
                isXsTurn = true;
            }
        }

        internal void SetPlayerVsBotMode() {
            isPlayerVsPlayer = false;
            Reset();
            
        }

        internal void SetPlayerVsPlayerMode() {
            isPlayerVsPlayer = true;
            Reset();
        }
    }
}
