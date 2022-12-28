namespace Task2.Scripts
{
    public class RowClass
    {
        private List<Row> _rows;

        public int Class { get; private set; }

        public RowClass(int rowClass)
        {
            _rows = new List<Row>();

            Class = rowClass;
        }

        public void AddRow(Row row)
        {
            _rows.Add(row);
        }

        public long GetActiveIncomeSum()
        {
            return _rows.Select(row => row.activeIncome).Sum();
        }

        public long GetPassiveIncomeSum()
        {
            return _rows.Select(row => row.passiveIncome).Sum();
        }

        public long GetDebetSum()
        {
            return _rows.Select(row => row.debet).Sum();
        }

        public long GetCreditSum()
        {
            return _rows.Select(row => row.credit).Sum();
        }

        public long GetActiveOutcomeSum()
        {
            return _rows.Select(row => row.activeOutcome).Sum();
        }

        public long GetPassiveOutcomeSum()
        {
            return _rows.Select(row => row.passiveOutcome).Sum();
        }
    }
}
