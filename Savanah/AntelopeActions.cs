namespace Savanah
{
    public class AntelopeActions
    {
        public bool IsPosSafe(string[,]board,int y, int x)
        {
            bool PosSafe;
            switch (y)
            {
                case 10:
                    y = 8;
                    break;
                case -1:
                    y = 1;
                    break;
                case 9:
                    y = 8;
                    break;
                case 0:
                    y = 1;
                    break;
            }
            switch (x)
            {
                case 10:
                    x = 8;
                    break;
                case -1:
                    x = 1;
                    break;
                case 9:
                    x = 8;
                    break;
                case 0:
                    x = 1;
                    break;
            }
            if (board[y - 1, x - 1] == Constants.Lion) PosSafe = false;
            if (board[y - 1, x] == Constants.Lion) PosSafe = false;
            if (board[y - 1, x + 1] == Constants.Lion) PosSafe = false;
            if (board[y, x - 1] == Constants.Lion) PosSafe = false;
            if (board[y, x + 1] == Constants.Lion) PosSafe = false;
            if (board[y + 1, x - 1] == Constants.Lion) PosSafe = false;
            if (board[y + 1, x] == Constants.Lion) PosSafe = false;
            if (board[y + 1, x + 1] == Constants.Lion) PosSafe = false;
            else PosSafe = true;
            return PosSafe;
        }
    }
}
