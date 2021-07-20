using System;

namespace FiveInARow {

    static class Evaluation {
        public static int Win = int.MaxValue;
        public static int Neutral = 0;
        public static int Loss = int.MinValue;
    }

    class Bot {
        
        public static (int,int) Move(Board board) {
            var children = board.AdjacentChildren();

            if (children.Count == 0) {
                return (board.Size / 2, board.Size / 2);
            }

            var bestMove = board.LastMove;
            var bestEvaluation = Evaluation.Loss;

            foreach (Board child in children) {
                var eval = Minimax(child, 3, false, Evaluation.Loss, Evaluation.Win);
                if (eval >= bestEvaluation) {
                    bestEvaluation = eval;
                    bestMove.X = child.LastMove.X;
                    bestMove.Y = child.LastMove.Y;
                }
            }
            return (bestMove.X, bestMove.Y);
        }

        private static int Minimax(Board board, int depth, bool maxing, int alpha, int beta) {
            if (board.LastMove.Who != CellContent.Empty) {
                int cellEval = EvaluateCell(board, board.LastMove.X, board.LastMove.Y);
                if (cellEval == Evaluation.Loss || cellEval == Evaluation.Win) {
                    return cellEval;
                }
            }

            if (depth <= 0)
                return EvaluateBoard(board);

            var children = board.AdjacentChildren();

            if (maxing) {
                int eval = Evaluation.Loss;
                foreach (Board child in children) {
                    eval = Math.Max((int)eval, (int)Minimax(child, depth - 1, false, alpha, beta));
                    alpha = Math.Max((int)alpha, (int)eval);
                    if (alpha > beta)
                        break;
                }
                return eval;
            } else {
                int eval = Evaluation.Win;
                foreach (Board child in children) {
                    eval = Math.Min((int)eval, (int)Minimax(child, depth - 1, true, alpha, beta));
                    alpha = Math.Min((int)beta, (int)eval);
                    if (alpha > beta)
                        break;
                }
                return eval;
            }
        }

        private static int EvaluateBoard(Board board) {
            int eval = 0;

            for (int i = 0; i < board.Size; i++)
                for (int j = 0; j < board.Size; j++)
                    if (board.GetCell(i, j) != CellContent.Empty) {
                        int cellEval = EvaluateCell(board, i, j);
                        if (cellEval == Evaluation.Loss || cellEval == Evaluation.Win) {
                            return cellEval;
                        }
                        eval += cellEval;
                    }
            return eval;
        }

        private static int EvaluateCell(Board board, int x, int y) {
            CellContent whoseLine = board.GetCell(x, y);
            CellContent next = board.LastMove.Who == CellContent.Bot ? CellContent.Player : CellContent.Bot;

            int eval = 0;

            LineParams[] cellParams = board.CellParams(x, y);
            foreach (LineParams lineParams in cellParams) {
                int l = lineParams.Length;
                int oe = lineParams.OpenEnds;
                bool nextIsNotWhoseLineWins = (l == 5) || (l == 4 && oe == 2);
                bool nextIsWhoseLineWins = nextIsNotWhoseLineWins || (l == 4 && oe == 1) || (l == 3 && oe == 2);
                if (next == CellContent.Player && whoseLine == CellContent.Bot && nextIsNotWhoseLineWins) return Evaluation.Win;
                if (next == CellContent.Player && whoseLine == CellContent.Player && nextIsWhoseLineWins) return Evaluation.Loss;
                if (next == CellContent.Bot && whoseLine == CellContent.Bot && nextIsWhoseLineWins) return Evaluation.Win;
                if (next == CellContent.Bot && whoseLine == CellContent.Player && nextIsNotWhoseLineWins) return Evaluation.Loss;

                int coefficient = next == CellContent.Bot ? 1 : -1;
                eval += (int)Math.Pow(2, l*oe) * coefficient;

            }
            return eval;
        }
    }
}
