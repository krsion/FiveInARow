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


            BoardState board = new BoardState();
            Game game = new Game(board);
            GameForm.ColorSettings colorSettings = new GameForm.ColorSettings() {
                EmptyBrush = Brushes.LightGray,
                PlayerPen = new Pen(Brushes.Red, 2),
                BotPen = new Pen(Brushes.Blue, 2),
                CellBorderPen = Pens.Black,
                LastMove = Brushes.LightYellow

            };
            GameForm gameForm = new GameForm(board, game, colorSettings);
            board.Changed += gameForm.OnBoardChanged;
            game.GameOver += gameForm.OnGameOver;

            Application.Run(gameForm);
        }
    }
}
