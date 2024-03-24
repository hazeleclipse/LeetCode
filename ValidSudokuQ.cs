namespace LeetCode;

/// <summary>
/// 36. Valid Sudoku
/// </summary>
internal static class ValidSudokuQ
{
    public static bool IsValidSudoku(char[][] board)
    {
        // Setup Hash Sets
        var rowHs = new HashSet<char>();

        var colHsArray = new HashSet<char>[9];
        var subHsArray = new HashSet<char>[9];

        for (int i = 0; i < 9; i++)
        {
            colHsArray[i] = [];
            subHsArray[i] = [];
        }
        

        // Run check
        for (byte row = 0; row < 9; row++) 
        {            
            for (byte col = 0; col < 9; col++)
            {
                char c = board[row][col];
                
                if (c != '.')
                {
                    byte subBoxIndex = ConvertToSubBoxIndex(row, col);
                    if ( !rowHs.Add(c)
                        || !colHsArray[col].Add(c)
                        || !subHsArray[subBoxIndex].Add(c))
                    {
                        return false;
                    }
                }
            }

            rowHs.Clear();
        }

        return true;
    }

    public static byte ConvertToSubBoxIndex(byte row, byte col)
    {
        if (row < 3)
        {
            if (col < 3)
            {
                return 0;
            }
            else if (col < 6)
            {
                return 1;
            }
            else { return 2; }
        }
        else if (row < 6)
        {
            if (col < 3)
            {
                return 3;
            }
            else if (col < 6)
            {
                return 4;
            }
            else { return 5; }
        }
        else
        {
            if (col < 3)
            {
                return 6;
            }
            else if (col < 6)
            {
                return 7;
            }
            else { return 8; }
        }
    }

    public static void Client()
    {
        char[][] board =
            [['5', '3', '.', '.', '7', '.', '.', '.', '.'],
            ['6', '.', '.', '1', '9', '5', '.', '.', '.'],
            ['.', '9', '8', '.', '.', '.', '.', '6', '.'],
            ['8', '.', '.', '.', '6', '.', '.', '.', '3'],
            ['4', '.', '.', '8', '.', '3', '.', '.', '1'],
            ['7', '.', '.', '.', '2', '.', '.', '.', '6'],
            ['.', '6', '.', '.', '.', '.', '2', '8', '.'],
            ['.', '.', '.', '4', '1', '9', '.', '.', '5'],
            ['.', '.', '.', '.', '8', '.', '.', '7', '9']];

        var valid = IsValidSudoku(board);
        Console.WriteLine(valid);
    }
}
