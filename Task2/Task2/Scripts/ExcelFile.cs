namespace Task2.Scripts
{
    public class ExcelFile
    {
        private string _fileName;
        private List<RowClass> _classes;

        public string FileName => _fileName;

        public ExcelFile(string fileName)
        {
            _classes = new List<RowClass>();
            _fileName = fileName;
        }

        public void AddRowClass(RowClass row)
        {
            _classes.Add(row);
        }

        public List<RowClass> GetClasses()
        {
            return _classes;
        }
    }
}
