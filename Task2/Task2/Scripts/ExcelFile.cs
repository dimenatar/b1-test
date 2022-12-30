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

        public double GetActiveIncomeSum()
        {
            return _classes.Sum(c => c.GetActiveIncomeSum());
        }

        public double GetPassiveIncomeSum()
        {
            return _classes.Sum(c => c.GetPassiveIncomeSum());
        }

        public double GetDebetSum()
        {
            return _classes.Sum(c => c.GetDebetSum());
        }

        public double GetCreditSum()
        {
            return _classes.Sum(c => c.GetCreditSum());
        }

        public double GetActiveOutcomeSum()
        {
            return _classes.Sum(c => c.GetActiveOutcomeSum());
        }

        public double GetPassiveOutcomeSum()
        {
            return _classes.Sum(c => c.GetPassiveOutcomeSum());
        }
    }
}
