using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("FiveInARowTests")]
namespace Gomoku {

    public enum CellContent {
        Empty, PlayerX, PlayerO
    }

    /// <summary>
    /// How long a line of equal symbols is and from how many ends (0, 1 or 2) it is blocked by opponent's symbol or edge of the board.
    /// </summary>
    public struct LineParams {
        public LineParams(int length, int openEnds) {
            Length = length;
            OpenEnds = openEnds;
        }
        public int Length { get; set; }
        public int OpenEnds { get; set; }
    }

    public struct Position {
        public Position(int x, int y) {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
    }

    /// <summary>
    /// Representation of Gomoku game board state.
    /// Contains each cell's content, who's turn it is and where is the last move.
    /// </summary>
    public class BoardState : ICloneable{
        public BoardState(int boardSize, int winnerLineLength) {
            Size = boardSize;
            WinnerLineLength = winnerLineLength;
            board = new CellContent[Size, Size];
            LastMove = (new Position(0, 0), CellContent.Empty);
            Changed();
        }
        private CellContent[,] board;
        private int fullCellCount = 0;
        public (Position Position, CellContent Who) LastMove { get; private set; }
        public event Action Changed = delegate { };
        public int Size { get; }
        public int WinnerLineLength { get; }

        public void SetCellsContentAtPosition(Position position, CellContent content) {
            if (!Fits(position)) throw new ArgumentOutOfRangeException();
            if (board[position.X, position.Y] == CellContent.Empty && content != CellContent.Empty)
                fullCellCount += 1;
            if (board[position.X, position.Y] != CellContent.Empty && content == CellContent.Empty)
                fullCellCount -= 1;

            board[position.X, position.Y] = content;
            LastMove = (position, content);
       
            Changed();
        }

        /// <summary>
        /// Given coordinates, returns what is at the position in the board state.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">If the given position is invalid.</exception>
        public CellContent GetCellsContentAtPosition(Position position) {
            if (!Fits(position)) throw new ArgumentOutOfRangeException();
            return board[position.X, position.Y];
        }

        /// <summary>
        /// Tells whether the given position is within board's boundaries.
        /// </summary>
        public bool Fits(Position position) {
            return (0 <= position.X && position.X < Size && 0 <= position.Y && position.Y < Size);
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
            LastMove = (new Position(0,0), CellContent.Empty);
            fullCellCount = 0;
            Changed();
        }

        /// <summary>
        /// Returns a deep copy of the board.
        /// </summary>
        public object Clone() {
            BoardState result = new BoardState(Size, WinnerLineLength) {
                board = board.Clone() as CellContent[,],
                LastMove = LastMove,
                fullCellCount = fullCellCount
            };
            return result;
        }

        /// <summary>
        /// Each position is in 4 possible lines of the same symbols - vertical, horizontal and two diagonal lines.
        /// This method finds length and number of open ends each line containing given cell has.
        /// Ordering of line parameters is: (diagonal descending, diagonal ascending, vertical, horizontal)
        /// </summary>
        public LineParams[] CellsLineParams(Position position) {
            CellContent who = GetCellsContentAtPosition(position);
            LineParams[] lines = new LineParams[4];
            (int X, int Y)[] mask = { (1, 1), (1, -1), (1, 0), (0, 1) };
            for (int m = 0; m < 4; m++) {
                lines[m] = new LineParams(1, 2);
                // positive direction
                for (int offset = 1; offset < WinnerLineLength; offset++) {
                    Position positionInLine = new Position(
                        position.X + offset * mask[m].X, 
                        position.Y + offset * mask[m].Y);
                    if (!Fits(positionInLine)) {
                        lines[m].OpenEnds -= 1;
                        break;
                    }
                    CellContent cell = GetCellsContentAtPosition(positionInLine);
                    if (cell == CellContent.Empty) {
                        break;
                    }
                    if (cell != who) {
                        lines[m].OpenEnds -= 1;
                        break;
                    }
                    lines[m].Length += 1;
                }
                // negative direction
                for (int offset = 1; offset < WinnerLineLength; offset++) {
                    Position positionInLine = new Position(position.X - offset * mask[m].X, position.Y - offset * mask[m].Y);
                    if (!Fits(positionInLine)) {
                        lines[m].OpenEnds -= 1;
                        break;
                    }
                    CellContent cell = GetCellsContentAtPosition(positionInLine);
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
            CellContent next = LastMove.Who == CellContent.PlayerO ? CellContent.PlayerX : CellContent.PlayerO;

            for (int i = 0; i < Size; i++) {
                for (int j = 0; j < Size; j++) {
                    Position position = new Position(i, j);
                    if (GetCellsContentAtPosition(position) == CellContent.Empty && HasCellAnyNeighbor(position)) {
                        BoardState child = Clone() as BoardState;
                        child.SetCellsContentAtPosition(position, next);
                        children.Add(child);
                    }
                }
            }

            return children;
        }

        /// <summary>
        /// Tells whether any of cell's neighboring cells is not empty.
        /// </summary>
        private bool HasCellAnyNeighbor(Position position) {
            (int X, int Y)[] mask = { (0, 1), (0, -1), (1, 0), (-1, 0), (1, 1), (-1, -1), (1, -1), (-1, 1) };
            foreach (var (X, Y) in mask) {
                Position newPosition = new Position(position.X + X, position.Y + Y);
                if (Fits(newPosition) && GetCellsContentAtPosition(newPosition) != CellContent.Empty) {
                    return true;
                }
            }
            return false;
        }
    }
}
