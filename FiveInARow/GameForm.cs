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
        public GameForm() {
            InitializeComponent();
        }

        private Board board = new Board();

        private void boardPictureBox_Paint(object sender, PaintEventArgs e) {
            PictureBox pb = sender as PictureBox;
            board.Draw(e.Graphics, pb.Width, pb.Height);
        }

        private void boardPictureBox_MouseClick(object sender, MouseEventArgs e) {
            PictureBox pb = sender as PictureBox;
            board.click(e.X, e.Y, pb.Width, pb.Height);
            pb.Refresh();
        }

        private void GameForm_Load(object sender, EventArgs e) {

        }
    }
}
