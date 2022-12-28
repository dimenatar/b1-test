namespace Task2.Scripts
{
    public class ExcelFile
    {
        private string _fileName;
        private List<RowClass> _classes;

        public ExcelFile(string fileName)
        {
            _classes = new List<RowClass>();
            _fileName = fileName;
        }

        public void AddRow(RowClass row)
        {
            _classes.Add(row);
        }
    }
}
