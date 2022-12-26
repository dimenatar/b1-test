using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal static class FileDataManager
    {
        public static List<FileData> GetDataFromFile(string path, string symbols, ref int removed)
        {
            var text = File.ReadAllText(path);
            var lines = text.Split('\n');

            List<FileData> data = new List<FileData>();

            foreach (var line in lines)
            {
                if (line == "") continue;

                if (symbols != "")
                {
                    if (line.Contains(symbols))
                    {
                        removed++;
                        continue;
                    }
                }

                var items = line.Split(FileData.SEPARATOR);

                try
                {
                    data.Add(new FileData(Convert.ToDateTime(items[0]), items[1], items[2], Convert.ToInt32(items[3]), Convert.ToSingle(items[4])));
                }
                catch (Exception e)
                {
                    MessageBox.Show($"{line} {e.Message}");
                    return null;
                }
            }

            File.WriteAllText(path, string.Concat(data));

            return data;
        }

        public static List<FileData> GetDataFromFile(string path)
        {
            var text = File.ReadAllText(path);
            var lines = text.Split('\n');

            List<FileData> data = new List<FileData>();

            foreach (var line in lines)
            {
                if (line == "") continue;

                var items = line.Split(FileData.SEPARATOR);

                try
                {
                    data.Add(new FileData(Convert.ToDateTime(items[0]), items[1], items[2], Convert.ToInt32(items[3]), Convert.ToSingle(items[4])));
                }
                catch (Exception e)
                {
                    MessageBox.Show($"{line} {e.Message}");
                    return null;
                }
            }

            File.WriteAllText(path, string.Concat(data));

            return data;
        }

        public static List<FileData> GetDataFromFiles(string[] paths, string symbols, ref int removed)
        {
            List<FileData> datas = new List<FileData>();

            foreach (var path in paths)
            {
                if (path.Contains(".txt"))
                {
                    var data = GetDataFromFile(path, symbols, ref removed);

                    if (data != null)
                    {
                        datas.AddRange(data);
                    }
                }
            }

            return datas;
        }

        public static List<FileData> GetDataFromFiles(string[] paths)
        {
            List<FileData> datas = new List<FileData>();

            foreach (var path in paths)
            {
                if (path.Contains(".txt"))
                {
                    var data = GetDataFromFile(path);

                    if (data != null)
                    {
                        datas.AddRange(data);
                    }
                }
            }

            return datas;
        }

        public static void UniteFiles(string[] files, string fileName, string symbols)
        {
            int removed = 0;
            var data = GetDataFromFiles(files, symbols, ref removed);

            MessageBox.Show($"Removed {removed}");

            File.WriteAllText(fileName, string.Concat(data));
        }

        public static string RemoveWhitespace(this string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }
    }
}
