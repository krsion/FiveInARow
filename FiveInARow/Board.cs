using System;
using System.Collections.Generic;
using System.Text;

namespace FiveInARow {

    public enum CellContent {
        Empty, Player, Bot
    }

    public class Board {
        private CellContent[,] board;

        public event EventHandler<EventArgs> Changed = delegate { };

        public int Size { get => 15; }
        public Board() {
            board = new CellContent[Size, Size];
            Changed(this, new EventArgs());
        }

        public void SetCell(int x, int y, CellContent content) {
            board[x, y] = content;
            Changed(this, new EventArgs());
        }

        public CellContent GetCell(int x, int y) {
            return board[x, y];
        }

        public void Reset() {
            board = new CellContent[Size, Size];
            Changed(this, new EventArgs());
        }
    }
}
