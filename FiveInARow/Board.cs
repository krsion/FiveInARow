using System;
using System.Collections.Generic;
using System.Text;

namespace FiveInARow {

    public enum CellContent {
        Empty, Player, Bot
    }

    public class LineParams {
        public int Length = 1;
        public int OpenEnds = 2;
    }

    public class Board : ICloneable{
        public Board() {
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

        public CellContent GetCell(int x, int y) {
            if (!Fits(x, y)) throw new ArgumentOutOfRangeException();
            return board[x, y];
        }

        public bool Fits(int x, int y) {
            return (0 <= x && x < Size && 0 <= y && y < Size);
        }

        public bool IsFull() {
            return fullCellCount >= Size * Size;
        }

        public void Reset() {
            board = new CellContent[Size, Size];
            LastMove = (0, 0, CellContent.Empty);
            fullCellCount = 0;
            Changed();
        }

        public object Clone() {
            Board result = new Board();
            result.board = board.Clone() as CellContent[,];
            result.LastMove = LastMove;
            result.fullCellCount = fullCellCount;
            return result;
        }

        public LineParams[] CellParams(int x, int y) {
            CellContent who = GetCell(x, y);
            LineParams[] lines = new LineParams[4];
            (int X, int Y)[] mask = { (1, 1), (1, -1), (1, 0), (0, 1) };
            for (int m = 0; m < 4; m++) {
                lines[m] = new LineParams();
                for (int i = 1; i < WinnerLineLength; i++) {
                    (int X, int Y) position = (x + i * mask[m].X, y + i * mask[m].Y);
                    if (!Fits(position.X, position.Y)) {
                        lines[m].OpenEnds -= 1;
                        break;
                    }
                    CellContent cell = GetCell(position.X, position.Y);
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
                    CellContent cell = GetCell(position.X, position.Y);
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

        public List<Board> AdjacentChildren() {
            List<Board> children = new List<Board>();
            CellContent next = LastMove.Who == CellContent.Bot ? CellContent.Player : CellContent.Bot;

            for (int i = 0; i < Size; i++) {
                for (int j = 0; j < Size; j++) {
                    if (GetCell(i, j) == CellContent.Empty && IsCellAdjacent(i, j)) {
                        Board child = Clone() as Board;
                        child.SetCell(i, j, next);
                        children.Add(child);
                    }
                }
            }

            return children;
        }

        private bool IsCellAdjacent(int x, int y) {
            (int X, int Y)[] mask = { (0, 1), (0, -1), (1, 0), (-1, 0), (1, 1), (-1, -1), (1, -1), (-1, 1) };
            foreach (var m in mask) {
                int newX = x + m.X;
                int newY = y + m.Y;
                if (Fits(newX, newY) && GetCell(newX, newY) != CellContent.Empty) {
                    return true;
                }
            }
            return false;
        }
    }
}
