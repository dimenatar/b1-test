namespace Task2.Scripts
{
    public class RowClass
    {
        public List<Row> Rows { get; }

        public string PreviewText { get; private set; }
        public int Class { get; private set; }

        public RowClass(int rowClass, string previewText)
        {
            Rows = new List<Row>();

            Class = rowClass;
            PreviewText = previewText;
        }

        public void AddRow(Row row)
        {
            Rows.Add(row);
        }

        public double GetActiveIncomeSum()
        {
            return Rows.Where(row => row.number >= 100).Select(row => row.activeIncome).Sum();
        }

        public double GetPassiveIncomeSum()
        {
            return Rows.Where(row => row.number >= 100).Select(row => row.passiveIncome).Sum();
        }

        public double GetDebetSum()
        {
            return Rows.Where(row => row.number >= 100).Select(row => row.debet).Sum();
        }

        public double GetCreditSum()
        {
            return Rows.Where(row => row.number >= 100).Select(row => row.credit).Sum();
        }

        public double GetActiveOutcomeSum()
        {
            return Rows.Where(row => row.number >= 100).Select(row => row.activeOutcome).Sum();
        }

        public double GetPassiveOutcomeSum()
        {
            return Rows.Where(row => row.number >= 100).Select(row => row.passiveOutcome).Sum();
        }
    }
}
