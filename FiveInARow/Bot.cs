using System;
using System.Collections.Generic;
using System.Text;

namespace FiveInARow {

    enum Evaluation {
        Good = 1, Neutral = 0, Bad = -1
    }

    class Bot {
        
        public static (int,int) Move(Board board) {
            var children = board.AdjacentChildren();

            var bestMove = board.LastMove;
            var bestEvaluation = Evaluation.Bad;

            foreach (Board child in children) {
                var eval = Minimax(child, 2, true, Evaluation.Bad, Evaluation.Good);
                if (eval >= bestEvaluation) {
                    bestEvaluation = eval;
                    bestMove = child.LastMove;
                }
            }
            return (bestMove.X, bestMove.Y);
        }

        private static Evaluation Minimax(Board board, int depth, bool maxing, Evaluation alpha, Evaluation beta) {
            if (board.LastMove.Who != CellContent.Empty) {
                Evaluation cellEval = EvaluateCell(board, board.LastMove.X, board.LastMove.Y);
                if (cellEval != Evaluation.Neutral)
                    return cellEval;
            }

            if (depth <= 0)
                return EvaluateBoard(board);

            var children = board.AdjacentChildren();

            if (maxing) {
                Evaluation eval = Evaluation.Bad;
                foreach (Board child in children) {
                    eval = (Evaluation)Math.Max((int)eval, (int)Minimax(child, depth - 1, false, alpha, beta));
                    alpha = (Evaluation)Math.Max((int)alpha, (int)eval);
                    if (alpha > beta)
                        break;
                }
                return eval;
            } else {
                Evaluation eval = Evaluation.Good;
                foreach (Board child in children) {
                    eval = (Evaluation)Math.Min((int)eval, (int)Minimax(child, depth - 1, true, alpha, beta));
                    alpha = (Evaluation)Math.Min((int)beta, (int)eval);
                    if (alpha > beta)
                        break;
                }
                return eval;
            }
        }

        private static Evaluation EvaluateBoard(Board board) {
            for (int i = 0; i < board.Size; i++)
                for (int j = 0; j < board.Size; j++)
                    if (board.GetCell(i, j) != CellContent.Empty) {
                        Evaluation cellEval = EvaluateCell(board, i, j);
                        if (cellEval != Evaluation.Neutral) {
                            return cellEval;
                        }
                    }
            return Evaluation.Neutral;
        }

        private static Evaluation EvaluateCell(Board board, int x, int y) {
            LineParams[] cellParams = board.CellParams(x, y);
            foreach (LineParams lineParams in cellParams) {
                if (lineParams.Length == board.WinnerLineLength || lineParams.Length == board.WinnerLineLength-1 && lineParams.OpenEnds >= 1) {
                    if (board.GetCell(x, y) == CellContent.Bot)
                        return Evaluation.Good;
                    else return Evaluation.Bad;
                }
            }
            return Evaluation.Neutral;
        }
    }
}
