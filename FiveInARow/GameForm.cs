using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiveInARow {
    public partial class GameForm : Form {
        private Board board;
        private Game game;

        private Brush emptyBrush = Brushes.LightGray;
        private Brush playerBrush = Brushes.LightPink;
        private Brush botBrush = Brushes.LightBlue;
        private Pen borderPen = Pens.Black;

        public GameForm(Board board, Game game) {
            InitializeComponent();
            this.board = board;
            this.game = game;
        }
        private void boardPictureBox_Paint(object sender, PaintEventArgs e) {
            PictureBox pb = sender as PictureBox;
            int cellWidth = pb.Width / 15;
            int cellHeight = pb.Height / 15;
            Graphics g = e.Graphics;
            for (int i = 0; i < 15; i++) {
                for (int j = 0; j < 15; j++) {
                    Rectangle rect = new Rectangle(i * (cellWidth + 1), j * (cellHeight + 1), cellWidth, cellHeight);
                    g.DrawRectangle(borderPen, rect);
                    CellContent c = board.GetCell(i, j);
                    if (c == CellContent.Empty) g.FillRectangle(emptyBrush, rect);
                    if (c == CellContent.Player) g.FillRectangle(playerBrush, rect);
                    if (c == CellContent.Bot) g.FillRectangle(botBrush, rect);
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

        

        
    }   
}
