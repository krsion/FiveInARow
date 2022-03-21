using System;
using System.Drawing;
using System.Windows.Forms;

namespace Gomoku {
    
    public partial class GameForm : Form {
        public class ColorSettings {
            public Brush EmptyBrush { get; set; }
            public Pen PlayerPen { get; set; }
            public Pen BotPen { get; set; }
            public Pen CellBorderPen { get; set; }
            public Brush LastMove { get; set; }
        }

        private BoardState board;
        private Game game;
        private ColorSettings colorSettings;

        public GameForm(BoardState board, Game game, ColorSettings colorSettings) {
            InitializeComponent();
            this.board = board;
            this.game = game;
            this.colorSettings = colorSettings;
        }
        /// <summary>
        /// Rendering of the board
        /// </summary>
        private void boardPictureBox_Paint(object sender, PaintEventArgs e) {
            // setting up cursor
            if (board.LastMove.Who == CellContent.Player) Cursor = Cursors.WaitCursor;
            if (board.LastMove.Who == CellContent.Bot) Cursor = Cursors.Arrow;

            PictureBox pictureBox = sender as PictureBox;
            int cellWidth = pictureBox.Width / board.Size;
            int cellHeight = pictureBox.Height / board.Size;
            Graphics graphics = e.Graphics;
            for (int i = 0; i < board.Size; i++) {
                for (int j = 0; j < board.Size; j++) {
                    // calculating coordinates of the cell
                    int left = i * (cellWidth + 1);
                    int right = left + cellWidth;
                    int top = j * (cellHeight + 1);
                    int bottom = top + cellHeight;

                    // drawing empty cell
                    Rectangle rectangle = new Rectangle(left, top, cellWidth, cellHeight);
                    graphics.DrawRectangle(colorSettings.CellBorderPen, rectangle);
                    graphics.FillRectangle(colorSettings.EmptyBrush, rectangle);

                    // highlighting last move
                    if (i == board.LastMove.X && j == board.LastMove.Y && board.LastMove.Who != CellContent.Empty) {
                        graphics.FillRectangle(colorSettings.LastMove, rectangle);
                    }
                    // drawing cells content
                    CellContent cellContent = board.GetCellsContentAtPosition(i, j);
                    if (cellContent == CellContent.Player) { // player has a cross
                        graphics.DrawLine(colorSettings.PlayerPen, left, top, right, bottom);
                        graphics.DrawLine(colorSettings.PlayerPen, left, bottom, right, top);
                    }
                    if (cellContent == CellContent.Bot) { // bot has a circle
                        graphics.DrawEllipse(colorSettings.BotPen, rectangle);
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
            PictureBox pictureBox = sender as PictureBox;
            int cellWidth = (pictureBox.Width / board.Size) + 1;
            int cellHeight = (pictureBox.Height / board.Size) + 1;
            int x = e.X / cellWidth;
            int y = e.Y / cellHeight;
            game.PlayerMove(x, y);
        }

        private void resetButton_Click(object sender, EventArgs e) {
            game.Reset();
            gameOverLabel.Visible = false;
        }
    }   
}
