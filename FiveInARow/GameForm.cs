using System;
using System.Drawing;
using System.Windows.Forms;

namespace Gomoku {
    
    public partial class GameForm : Form {
        public class ColorSettings {
            public Brush EmptyBrush { get; set; }
            public Pen PlayerXPen { get; set; }
            public Pen PlayerOPen { get; set; }
            public Pen CellBorderPen { get; set; }
            public Brush LastMove { get; set; }
            public Color XWinsColor { get; set; }
            public Color OWinsColor { get; set; }
        }

        private BoardState board;
        private Game game;
        private Bot bot;
        private ColorSettings colorSettings;

        public GameForm(BoardState board, Game game, Bot bot, ColorSettings colorSettings) {
            InitializeComponent();
            this.board = board;
            this.game = game;
            this.bot = bot;
            this.colorSettings = colorSettings;
        }


        /// <summary>
        /// Rendering of the board
        /// </summary>
        private void boardPictureBox_Paint(object sender, PaintEventArgs e) {
            // setting up cursor
            if (board.LastMove.Who == CellContent.PlayerX && radioButtonPvB.Checked) Cursor = Cursors.WaitCursor;
            else Cursor = Cursors.Arrow;

            PictureBox pictureBox = sender as PictureBox;
            int cellWidth = pictureBox.Width / board.Size;
            int cellHeight = pictureBox.Height / board.Size;
            Graphics graphics = e.Graphics;
            for (int i = 0; i < board.Size; i++) {
                for (int j = 0; j < board.Size; j++) {
                    Position position = new Position(i, j);
                    // calculating coordinates of the cell
                    int left = i * (cellWidth + 1);
                    int right = left + cellWidth;
                    int top = j * (cellHeight + 1);
                    int bottom = top + cellHeight;

                    Rectangle rectangle = new Rectangle(left, top, cellWidth, cellHeight);

                    // drawing empty cell
                    graphics.DrawRectangle(colorSettings.CellBorderPen, rectangle);
                    graphics.FillRectangle(colorSettings.EmptyBrush, rectangle);

                    // highlighting last move
                    if (i == board.LastMove.Position.X && j == board.LastMove.Position.Y && board.LastMove.Who != CellContent.Empty) {
                        graphics.FillRectangle(colorSettings.LastMove, rectangle);
                    }
                    // drawing cells content
                    CellContent cellContent = board.GetCellsContentAtPosition(position);
                    if (cellContent == CellContent.PlayerX) { // player has a cross
                        graphics.DrawLine(colorSettings.PlayerXPen, left, top, right, bottom);
                        graphics.DrawLine(colorSettings.PlayerXPen, left, bottom, right, top);
                    }
                    if (cellContent == CellContent.PlayerO) { // bot has a circle
                        graphics.DrawEllipse(colorSettings.PlayerOPen, rectangle);
                    }
                    
                }
            }
        }
        public void OnBoardChanged() {
            boardPictureBox_Paint(boardPictureBox, new PaintEventArgs(boardPictureBox.CreateGraphics(), new Rectangle()));
        }

        public void OnGameOver(CellContent cellContent) {
            gameOverLabel.Visible = true;
            if (cellContent == CellContent.PlayerO) {
                gameOverLabel.BackColor = colorSettings.OWinsColor;
                gameOverLabel.Text = "Game Over\nO Wins";
            }
            else if (cellContent == CellContent.PlayerX) {
                gameOverLabel.BackColor = colorSettings.XWinsColor;
                gameOverLabel.Text = "Game Over\nX Wins";
            }
            else {
                gameOverLabel.BackColor = Color.LightYellow;
                gameOverLabel.Text = "Game Over\nTie";
            }
            Cursor = Cursors.Arrow;
        }

        private void boardPictureBox_MouseClick(object sender, MouseEventArgs e) {
            PictureBox pictureBox = sender as PictureBox;
            int cellWidth = (pictureBox.Width / board.Size) + 1;
            int cellHeight = (pictureBox.Height / board.Size) + 1;
            int x = e.X / cellWidth;
            int y = e.Y / cellHeight;
            game.Move(new Position(x, y));
        }

        private void resetButton_Click(object sender, EventArgs e) {
            game.Reset();
            gameOverLabel.Visible = false;
        }

        private void hardRadioButton_CheckedChanged(object sender, EventArgs e) {
            if (hardRadioButton.Checked) bot.changeDifficulty(Bot.Difficulty.Hard);
        }

        private void mediumRadioButton_CheckedChanged(object sender, EventArgs e) {
            if (mediumRadioButton.Checked) bot.changeDifficulty(Bot.Difficulty.Medium);
        }

        private void easyRadioButton_CheckedChanged(object sender, EventArgs e) {
            if (easyRadioButton.Checked) bot.changeDifficulty(Bot.Difficulty.Easy);
        }

        private void radioButtonPlayerVsBot_CheckedChanged(object sender, EventArgs e) {
            if (radioButtonPvB.Checked) {
                gameOverLabel.Visible = false;
                game.SetPlayerVsBotMode();
            }
        }

        private void radioButtonPlayerVsPlayer_CheckedChanged(object sender, EventArgs e) {
            if (radioButtonPvP.Checked) {
                gameOverLabel.Visible = false;
                game.SetPlayerVsPlayerMode();
            }
        }

        private void gameOverLabel_Click(object sender, EventArgs e) {

        }
    }   
}
