using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiveInARow {
    static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            Board board = new Board();
            Game game = new Game(board);
            GameForm gameForm = new GameForm(board, game);
            board.Changed += gameForm.OnBoardChanged;

            Application.Run(gameForm);
        }
    }
}
