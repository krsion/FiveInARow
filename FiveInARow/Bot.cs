using System;

namespace Gomoku {

    static class Evaluation {
        public static int Win = int.MaxValue;
        public static int Neutral = 0;
        public static int Loss = int.MinValue;
    }

    /// <summary>
    /// Artificial Intelligence for playing Gomoku.
    /// </summary>
    public class Bot {
        public enum Difficulty {
            Easy, Medium, Hard
        }

        public void changeDifficulty(Bot.Difficulty difficulty) {
            switch (difficulty) {
                case Difficulty.Easy:
                    depthOfSearch = 1;
                    break;
                case Difficulty.Medium:
                    depthOfSearch = 2;
                    break;
                case Difficulty.Hard:
                    depthOfSearch = 3;
                    break;
                default:
                    depthOfSearch = 0;
                    break;
            }

        }

        private int depthOfSearch;
        public Bot(Difficulty difficulty) {
            changeDifficulty(difficulty);
        }


        /// <summary>
        /// Given the state of the game, calculates which move would be best for the bot to win and returns the coordinates where the bot wants to place it's symbol. 
        /// </summary>
        /// <param name="board">To which board to add bot's symbol</param>
        /// <returns>Returns coordianates where bot wants to place it's symbol</returns>
        public Position Move(BoardState board) {
            var children = board.AdjacentChildren();
            // first move in the middle
            if (children.Count == 0) {
                return new Position(board.Size / 2, board.Size / 2);
            }

            var bestMove = board.LastMove;
            var bestEvaluation = Evaluation.Loss;

            foreach (BoardState child in children) {
                var eval = Minimax(child, depthOfSearch, false, Evaluation.Loss, Evaluation.Win);
                if (eval >= bestEvaluation) {
                    bestEvaluation = eval;
                    bestMove.Position.X = child.LastMove.Position.X;
                    bestMove.Position.Y = child.LastMove.Position.Y;
                }
            }
            return bestMove.Position;
        }

        /// <summary>
        /// Implementation of alpha-beta pruning minimax algorithm.
        /// </summary>
        /// <param name="board">Current state of the board</param>
        /// <param name="depth">How many steps ahead should the minimax algorithm search </param>
        /// <param name="maximizingPlayer">If true, we are looking for the best player's move, if false, we are searching for the best bot's move.</param>
        /// <param name="alpha">Minimum guaranteed score of the maximizing player. If greater than beta, no need to search anymore.</param>
        /// <param name="beta">Maximum guaranteed score of the minimizing player. If smaller than alpha, no need to search anymore.</param>
        /// <returns>If maxing, returns the highest reachable evaluation. If not maxing, returns the lowest reachable evaluation.</returns>
        private int Minimax(BoardState board, int depth, bool maximizingPlayer, int alpha, int beta) {
            if (board.LastMove.Who != CellContent.Empty) {
                int cellEval = EvaluateCell(board, board.LastMove.Position);
                if (cellEval == Evaluation.Loss || cellEval == Evaluation.Win) {
                    return cellEval;
                }
            }

            if (depth <= 0)
                return EvaluateBoard(board);

            var children = board.AdjacentChildren();

            if (maximizingPlayer) {
                int evaluation = Evaluation.Loss;
                foreach (BoardState child in children) {
                    evaluation = Math.Max(evaluation, Minimax(child, depth - 1, false, alpha, beta));
                    alpha = Math.Max(alpha, evaluation);
                    if (alpha > beta) {
                        break;
                    }
                }
                return evaluation;
            } else {
                int evaluation = Evaluation.Win;
                foreach (BoardState child in children) {
                    evaluation = Math.Min(evaluation, Minimax(child, depth - 1, true, alpha, beta));
                    alpha = Math.Min(beta, evaluation);
                    if (alpha > beta) {
                        break;
                    }
                }
                return evaluation;
            }
        }

        /// <summary>
        /// Returns how good given game state is from bot's perspective.
        /// </summary>
        /// <param name="board">Gomoku board state to evaluate</param>
        /// <returns>Returns evaluation of given game state.</returns>
        private int EvaluateBoard(BoardState board) {
            int evaluation = 0;

            for (int i = 0; i < board.Size; i++)
                for (int j = 0; j < board.Size; j++) {
                    Position position = new Position(i, j);
                    if (board.GetCellsContentAtPosition(position) != CellContent.Empty) {
                        int cellEvaluation = EvaluateCell(board, position);
                        if (cellEvaluation == Evaluation.Loss || cellEvaluation == Evaluation.Win) {
                            return cellEvaluation;
                        }
                        evaluation += cellEvaluation;
                    }
                }
            return evaluation;
        }

        /// <summary>
        /// Given the game board and one position in it, returns how much it contributes to bot's win. It is constant time O(1) evaluation of the position and does not do any search.
        /// </summary>
        /// <param name="board">Current state of the game board</param>
        /// <param name="x">X coordinate of the evaluated position</param>
        /// <param name="y">Y coordinate of the evaluated position</param>
        /// <returns>How much given position contributes to bot winning (or losing, if negative)</returns>
        private int EvaluateCell(BoardState board, Position position) {
            CellContent whoseLine = board.GetCellsContentAtPosition(position);
            CellContent next = board.LastMove.Who == CellContent.PlayerO ? CellContent.PlayerX : CellContent.PlayerO;

            int evaluation = 0;

            LineParams[] cellsLineParams = board.CellsLineParams(position);
            foreach (LineParams lineParams in cellsLineParams) {
                int length = lineParams.Length;
                int openEnds = lineParams.OpenEnds;
                bool nextIsNotWhoseLineWins = (length == 5) || (length == 4 && openEnds == 2);
                bool nextIsWhoseLineWins = nextIsNotWhoseLineWins || (length == 4 && openEnds == 1) || (length == 3 && openEnds == 2);
                if (next == CellContent.PlayerX && whoseLine == CellContent.PlayerO && nextIsNotWhoseLineWins) return Evaluation.Win;
                if (next == CellContent.PlayerX && whoseLine == CellContent.PlayerX && nextIsWhoseLineWins) return Evaluation.Loss;
                if (next == CellContent.PlayerO && whoseLine == CellContent.PlayerO && nextIsWhoseLineWins) return Evaluation.Win;
                if (next == CellContent.PlayerO && whoseLine == CellContent.PlayerX && nextIsNotWhoseLineWins) return Evaluation.Loss;

                int coefficient = next == CellContent.PlayerO ? 1 : -1;
                evaluation += (int)Math.Pow(2, length*openEnds) * coefficient;

            }
            return evaluation;
        }
    }
}
