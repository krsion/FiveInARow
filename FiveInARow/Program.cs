using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Gomoku {
    static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            BoardState board = new BoardState(15, 5);
            Bot bot = new Bot(Bot.Difficulty.Easy);
            Game game = new Game(board, bot);
            GameForm.ColorSettings colorSettings = new GameForm.ColorSettings() {
                EmptyBrush = Brushes.LightGray,
                PlayerXPen = new Pen(Brushes.Blue, 2),
                PlayerOPen = new Pen(Brushes.Red, 2),
                CellBorderPen = Pens.Black,
                LastMove = Brushes.LightYellow,
                XWinsColor = Color.LightBlue,
                OWinsColor = Color.LightCoral

            };
            GameForm gameForm = new GameForm(board, game, bot, colorSettings);
            board.Changed += gameForm.OnBoardChanged;
            game.GameOver += gameForm.OnGameOver;

            Application.Run(gameForm);
        }
    }
}
