using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class FileData
    {
        public static readonly string SEPARATOR = "||";

        public DateTime Date { get; private set; }
        public string EngBundle { get; private set; }
        public string RusBundle { get; private set; }
        public int IntValue { get; private set; }
        public float FloatValue { get; private set; }

        private const string _engAlphanumericCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" + "abcdefghijklmnopqrstuvwxyz";
        private const string _rusAlphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя";

        public FileData()
        {
            Date = GetRandomDate();
            EngBundle = GetRandomString(_engAlphanumericCharacters);
            RusBundle = GetRandomString(_rusAlphabet);
            IntValue = GetRandomInt(100000000);
            FloatValue = GetRandomFloat();
        }

        public FileData(DateTime date, string engBundle, string rusBundle, int intValue, float floatValue)
        {
            Date = date;
            EngBundle = engBundle;
            RusBundle = rusBundle;
            IntValue = intValue;
            FloatValue = floatValue;
        }

        public override string ToString()
        {
            return $"{Date.Day:00}.{Date.Month:00}.{Date.Year}{SEPARATOR}{EngBundle}{SEPARATOR}{RusBundle}{SEPARATOR}{IntValue}{SEPARATOR}{FloatValue}{SEPARATOR}\n";
        }

        public string GetDate()
        {
            return $"{Date.Day:00}.{Date.Month:00}.{Date.Year}";
        }

        private DateTime GetRandomDate()
        {
            var random = new Random();

            DateTime current = DateTime.Now;
            var date = new DateTime(current.Year - 5, current.Month, current.Day);
            var range = (current - date).Days;
            var rand = random.Next(range);

            return date.AddDays(rand);
        }

        private string GetRandomString(string sequence)
        {
            var random = new Random();
            return new string(Enumerable.Repeat(sequence, sequence.Length).Select(s => s[random.Next(sequence.Length)]).ToArray());
        }

        private int GetRandomInt(int max)
        {
            var random = new Random();
            var value = random.Next(max + 1);

            while (value % 2 != 0)
            {
                value = random.Next(max + 1);
            }

            return value;
        }

        private float GetRandomFloat() 
        {
            var random = new Random();
            return random.Next(1, 21) + (float)Math.Round(random.NextSingle(), 9);
        }
    }
}
