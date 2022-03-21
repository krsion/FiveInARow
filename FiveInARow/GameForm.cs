using System;
using System.Drawing;
using System.Windows.Forms;

namespace FiveInARow {
    public partial class GameForm : Form {
        private GomokuBoardState board;
        private Game game;

        private Brush emptyBrush = Brushes.LightGray;
        private Pen playerPen = new Pen(Brushes.Red, 2);
        private Pen botPen = new Pen(Brushes.Blue, 2);
        private Pen borderPen = Pens.Black;

        public GameForm(GomokuBoardState board, Game game) {
            InitializeComponent();
            this.board = board;
            this.game = game;
        }
        private void boardPictureBox_Paint(object sender, PaintEventArgs e) {
            if (board.LastMove.Who == CellContent.Player) Cursor = Cursors.WaitCursor;
            if (board.LastMove.Who == CellContent.Bot) Cursor = Cursors.Arrow;
            PictureBox pb = sender as PictureBox;
            int cellWidth = pb.Width / 15;
            int cellHeight = pb.Height / 15;
            Graphics g = e.Graphics;
            for (int i = 0; i < 15; i++) {
                for (int j = 0; j < 15; j++) {
                    int left = i * (cellWidth + 1);
                    int right = left + cellWidth;
                    int top = j * (cellHeight + 1);
                    int bottom = top + cellHeight;
                    Rectangle rect = new Rectangle(left, top, cellWidth, cellHeight);
                    g.DrawRectangle(borderPen, rect);
                    
                    CellContent c = board.GetCellsContentAtPosition(i, j);
                    g.FillRectangle(emptyBrush, rect);
                    if (i == board.LastMove.X && j == board.LastMove.Y && board.LastMove.Who != CellContent.Empty) {
                        g.FillRectangle(Brushes.LightYellow, rect);
                    }
                    if (c == CellContent.Player) {
                        g.DrawLine(playerPen, left, top, right, bottom);
                        g.DrawLine(playerPen, left, bottom, right, top);
                    }
                    if (c == CellContent.Bot) {
                        g.DrawEllipse(botPen, rect);
                    }
                    
                }
            }
        }
        public void OnBoardChanged() {
            boardPictureBox_Paint(boardPictureBox, new PaintEventArgs(boardPictureBox.CreateGraphics(), new Rectangle()));
            

        }

        public void OnGameOver() {
            gameOverLabel.Visible = true;
        }

        private void boardPictureBox_MouseClick(object sender, MouseEventArgs e) {
            PictureBox pb = sender as PictureBox;
            int cellWidth = (pb.Width / 15) + 1;
            int cellHeight = (pb.Height / 15) + 1;
            int x = e.X / cellWidth;
            int y = e.Y / cellHeight;
            game.PlayerMove(x, y);
        }

        private void resetButton_Click(object sender, EventArgs e) {
            game.Reset();
            gameOverLabel.Visible = false;
        }

        private void gameOverLabel_Click(object sender, EventArgs e) {

        }
    }   
}
