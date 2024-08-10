using System;

namespace AlgoTown.Utils
{
    public struct LogObject
    {
        private int rows;
        private int columns;
        private char[,] charMap;

        public LogObject(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            charMap = new char[rows, columns];
        }

        public void Print()
        {
            for (int row = 0; row < rows; row++)
            {
                string line = "";
                for (int col = 0; col < columns; col++)
                {
                    line += charMap[row, col];
                }
                Console.Write(line);
            }
        }

        public void PlaceString(string str, int x = 1, int y = 1, int pivotX = 0, int pivotY = 0)
        {
            char[] chars = str.ToCharArray();

            int row = y - pivotY;
            int col = x - pivotX;

            for (int i = 0; i < chars.Length; i++)
            {
                char curChar = chars[i];

                // Instead of adding the newline character to the string,
                // treat it as the end of the current row
                if (curChar == '\n')
                {
                    row++;
                    col = x - pivotX;
                    continue;
                }

                // Ignore carriage return
                else if (curChar == '\r')
                {
                    continue;
                }

                // Place 4 whitespaces
                else if (curChar == '\t')
                {
                    for (int j = 0; j < 4; j++)
                    {
                        col++;
                        if (row > 0 && col > 0 && row - 1 < rows && col - 1 < columns)
                        {
                            charMap[row - 1, col - 1] = ' ';
                        }
                    }
                    continue;
                }

                if (row > 0 && col > 0 && row - 1 < rows && col - 1 < columns)
                {
                    charMap[row - 1, col - 1] = curChar;
                }

                if (col < columns)
                {
                    col++;
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
