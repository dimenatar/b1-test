using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal static class FileGenerator
    {
        public static readonly int FILE_AMOUNT = 100;
        public static readonly int AMOUNT_LINES_IN_FILE = 1000;

        public static void GenerateFiles(string path, int fileAmount, int amountLinesInEachFile)
        {
            for (int i = 0; i < fileAmount; i++)
            {
                File.WriteAllText(GetFileName(path, i), GetFileData(amountLinesInEachFile));
            }
        }

        private static string GetFileName(string path, int index)
        {
            return $"{path}\\ randomFile_{index + 1}.txt";
        }

        private static string GetFileData(int amountLines)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < amountLines; i++)
            {
                sb.Append(new FileData().ToString());
            }
            

            return sb.ToString();
        }
    }
}
