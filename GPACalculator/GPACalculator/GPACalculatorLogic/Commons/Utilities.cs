using System;

namespace GPACalculator.Logic.Commons
{
    public static class Utilities
    {
        // clean string to remove digit at the begining
        public static string RemoveDigitFromStart(string val)
        {
            var str = val.Substring(0, 1).ToCharArray();
            var strCode = (int)str[0];
            if (strCode >= 48 && strCode <= 57)
            {
                return val.Substring(1);
            }

            return val;
        }

        // Change first character to caps
        public static string FirstCharacterToUpper(string val)
        {
            var str = val.Substring(0, 1).ToCharArray();
            var strCode = (int)str[0];
            if (strCode >= 97)
            {
                var strCaps = strCode - 32;
                return (char)strCaps + val.Substring(1);
            }

            return val;
        }

        #region PRINT TABLE UTILITY CODE
        public static void PrintLine(int widthOfTable)
        {
            Console.WriteLine(new string('-', widthOfTable));
        }

        public static void PrintRow(int widthOfTable, params string[] columns)
        {
            int width = (widthOfTable - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += CenterText(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        public static string CenterText(string column, int width)
        {
            column = column.Length > width ? column.Substring(0, width - 3) + "..." : column;

            if (!string.IsNullOrEmpty(column))
            {
                return column.PadRight(width - (width - column.Length) / 2).PadLeft(width);
            }
            else
            {
                return new string(' ', width);
            }
        }

        #endregion

    }
}
