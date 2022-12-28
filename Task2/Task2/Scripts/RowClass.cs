namespace Task2.Scripts
{
    public class RowClass
    {
        public List<Row> Rows { get; }

        public int Class { get; private set; }

        public RowClass(int rowClass)
        {
            Rows = new List<Row>();

            Class = rowClass;
        }

        public void AddRow(Row row)
        {
            Rows.Add(row);
        }

        public double GetActiveIncomeSum()
        {
            return Rows.Select(row => row.activeIncome).Sum();
        }

        public double GetPassiveIncomeSum()
        {
            return Rows.Select(row => row.passiveIncome).Sum();
        }

        public double GetDebetSum()
        {
            return Rows.Select(row => row.debet).Sum();
        }

        public double GetCreditSum()
        {
            return Rows.Select(row => row.credit).Sum();
        }

        public double GetActiveOutcomeSum()
        {
            return Rows.Select(row => row.activeOutcome).Sum();
        }

        public double GetPassiveOutcomeSum()
        {
            return Rows.Select(row => row.passiveOutcome).Sum();
        }
    }
}
