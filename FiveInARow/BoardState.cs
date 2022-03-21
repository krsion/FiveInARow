using System;
using System.Collections.Generic;

namespace Gomoku {

    public enum CellContent {
        Empty, Player, Bot
    }

    /// <summary>
    /// How long a line of equal symbols is and from how many ends (0, 1 or 2) it is blocked by opponent's symbol or edge of the board.
    /// </summary>
    public class LineParams {
        public int Length = 1;
        public int OpenEnds = 2;
    }

    /// <summary>
    /// Representation of Gomoku game board state.
    /// Contains each cell's content, who's turn it is and where is the last move.
    /// </summary>
    public class BoardState : ICloneable{
        public BoardState() {
            board = new CellContent[Size, Size];
            LastMove = (0, 0, CellContent.Empty);
            Changed();
        }
        private CellContent[,] board;
        private int fullCellCount = 0;
        public (int X, int Y, CellContent Who) LastMove { get; private set; }
        public event Action Changed = delegate { };
        public int Size { get => 15; }
        public int WinnerLineLength { get => 5; }

        public void SetCell(int x, int y, CellContent content) {
            if (board[x, y] == CellContent.Empty && content != CellContent.Empty)
                fullCellCount += 1;
            if (board[x, y] != CellContent.Empty && content == CellContent.Empty)
                fullCellCount -= 1;

            board[x, y] = content;
            LastMove = (x, y, content);
       
            Changed();
        }

        /// <summary>
        /// Given coordinates, returns what is at the position in the board state.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">If the given position is invalid.</exception>
        public CellContent GetCellsContentAtPosition(int x, int y) {
            if (!Fits(x, y)) throw new ArgumentOutOfRangeException();
            return board[x, y];
        }

        /// <summary>
        /// Tells whether the given position is within board's boundaries.
        /// </summary>
        public bool Fits(int x, int y) {
            return (0 <= x && x < Size && 0 <= y && y < Size);
        }

        /// <summary>
        /// Tells if there are no empty cells left.
        /// </summary>
        public bool IsFull() {
            return fullCellCount >= Size * Size;
        }

        /// <summary>
        /// Makes the board empty.
        /// </summary>
        public void Reset() {
            board = new CellContent[Size, Size];
            LastMove = (0, 0, CellContent.Empty);
            fullCellCount = 0;
            Changed();
        }

        /// <summary>
        /// Returns a deep copy of the board.
        /// </summary>
        public object Clone() {
            BoardState result = new BoardState {
                board = board.Clone() as CellContent[,],
                LastMove = LastMove,
                fullCellCount = fullCellCount
            };
            return result;
        }

        /// <summary>
        /// Each position is in 4 possible lines of the same symbols - vertical, horizontal and two diagonal lines.
        /// This method finds length and number of open ends each line containing given cell has.
        /// </summary>
        public LineParams[] CellsLineParams(int x, int y) {
            CellContent who = GetCellsContentAtPosition(x, y);
            LineParams[] lines = new LineParams[4];
            (int X, int Y)[] mask = { (1, 1), (1, -1), (1, 0), (0, 1) };
            for (int m = 0; m < 4; m++) {
                lines[m] = new LineParams();
                for (int i = 1; i < WinnerLineLength; i++) {
                    (int X, int Y) = (x + i * mask[m].X, y + i * mask[m].Y);
                    if (!Fits(X, Y)) {
                        lines[m].OpenEnds -= 1;
                        break;
                    }
                    CellContent cell = GetCellsContentAtPosition(X, Y);
                    if (cell == CellContent.Empty) {
                        break;
                    }
                    if (cell != who) {
                        lines[m].OpenEnds -= 1;
                        break;
                    }
                    lines[m].Length += 1;
                }
                for (int i = 1; i < WinnerLineLength; i++) {
                    (int X, int Y) position = (x - i * mask[m].X, y - i * mask[m].Y);
                    if (!Fits(position.X, position.Y)) {
                        lines[m].OpenEnds -= 1;
                        break;
                    }
                    CellContent cell = GetCellsContentAtPosition(position.X, position.Y);
                    if (cell == CellContent.Empty) {
                        break;
                    }
                    if (cell != who) {
                        lines[m].OpenEnds -= 1;
                        break;
                    }
                    lines[m].Length += 1;
                }
            }
            return lines;
        }

        /// <summary>
        /// Returns all possibilities what the next state may be. 
        /// Considers moves only to cells that have a nonempty neighbour to make the state space smaller.
        /// </summary>
        public List<BoardState> AdjacentChildren() {
            List<BoardState> children = new List<BoardState>();
            CellContent next = LastMove.Who == CellContent.Bot ? CellContent.Player : CellContent.Bot;

            for (int i = 0; i < Size; i++) {
                for (int j = 0; j < Size; j++) {
                    if (GetCellsContentAtPosition(i, j) == CellContent.Empty && HasCellAnyNeighbor(i, j)) {
                        BoardState child = Clone() as BoardState;
                        child.SetCell(i, j, next);
                        children.Add(child);
                    }
                }
            }

            return children;
        }

        /// <summary>
        /// Tells whether any of cell's neighboring cells is not empty.
        /// </summary>
        private bool HasCellAnyNeighbor(int x, int y) {
            (int X, int Y)[] mask = { (0, 1), (0, -1), (1, 0), (-1, 0), (1, 1), (-1, -1), (1, -1), (-1, 1) };
            foreach (var (X, Y) in mask) {
                int newX = x + X;
                int newY = y + Y;
                if (Fits(newX, newY) && GetCellsContentAtPosition(newX, newY) != CellContent.Empty) {
                    return true;
                }
            }
            return false;
        }
    }
}
