using System;
using System.Collections.Generic;
using System.Text;

namespace FiveInARow {
    class Bot {
        public static (int,int) Move(Board board) {
            for (int i = 0; i < board.Size; i++) {
                for (int j = 0; j < board.Size; j++) {
                    if (board.GetCell(i,j) == CellContent.Empty) {
                        return (i, j);
                    }  
                }
            }
            return (0, 0);
        }
    }
}
