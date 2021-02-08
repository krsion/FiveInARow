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
        private readonly int winnerLineLength = 5;

        private bool CheckForWinner(int x, int y) {
            LineParams[] cellParams = CellParams(x, y);
            foreach (LineParams lineParams in cellParams) {
                if (lineParams.Length == winnerLineLength)
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

        public LineParams[] CellParams(int x, int y) {
            CellContent who = board.GetCell(x, y);
            LineParams[] lines = new LineParams[4];
            (int X, int Y)[] mask = { (1, 1), (1, -1), (1, 0), (0, 1) };
            for (int m = 0; m < 4; m++) {
                lines[m] = new LineParams();
                for (int i = 1; i < winnerLineLength; i++) {
                    (int X, int Y) position = (x + i * mask[m].X, y + i * mask[m].Y);
                    if (!board.Fits(position.X, position.Y)) {
                        lines[m].PositiveEndOpen = false;
                        break;
                    }
                    CellContent cell = board.GetCell(position.X, position.Y);
                    if (cell == CellContent.Empty) {
                        break;
                    }
                    if (cell != who) {
                        lines[m].PositiveEndOpen = false;
                        break;
                    }
                    lines[m].Length += 1;
                }
            }

            for (int m = 0; m < 4; m++) {
                for (int i = 1; i < winnerLineLength; i++) {
                    (int X, int Y) position = (x - i * mask[m].X, y - i * mask[m].Y);
                    if (!board.Fits(position.X, position.Y)) {
                        lines[m].NegativeEndOpen = false;
                        break;
                    }
                    CellContent cell = board.GetCell(position.X, position.Y);
                    if (cell == CellContent.Empty) {
                        break;
                    }
                    if (cell != who) {
                        lines[m].NegativeEndOpen = false;
                        break;
                    }
                    lines[m].Length += 1;
                }
            }
            return lines;
        }
    }
}
