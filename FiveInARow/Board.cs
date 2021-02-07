using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace FiveInARow {
    class Board {
        private CellContent[,] board = new CellContent[15, 15];

        private Brush emptyBrush = Brushes.LightGray;
        private Brush playerBrush = Brushes.LightPink;
        private Brush botBrush = Brushes.LightBlue;
        private Pen borderPen = Pens.Black;

        public void Draw(Graphics g, int width, int height) {
            int cellWidth = width / 15;
            int cellHeight = height / 15;
            
            for (int i = 0; i < 15; i++) {
                for (int j = 0; j < 15; j++) {
                    Rectangle rect = new Rectangle(i * (cellWidth+1), j * (cellHeight+1), cellWidth, cellHeight);
                    g.DrawRectangle(borderPen, rect);
                    CellContent c = board[i, j];
                    if (c == CellContent.Empty) g.FillRectangle(emptyBrush, rect);
                    if (c == CellContent.Player) g.FillRectangle(playerBrush, rect);
                    if (c == CellContent.Bot) g.FillRectangle(botBrush, rect);
                }
            }
        }

        public void setCell(int x, int y, CellContent content) {
            board[x, y] = content;
        }

        public void click(int x, int y, int width, int height) {
            int cellWidth = (width / 15) + 1;
            int cellHeight = (height / 15) + 1;
            setCell(x/cellWidth, y/cellHeight, CellContent.Player);
        }
    }

    enum CellContent {
        Empty, Player, Bot
    }
}
