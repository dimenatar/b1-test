namespace Task1
{
    public partial class ProgressForm : Form
    {
        public ProgressForm(int minValue, int maxValue)
        {
            InitializeComponent();
            Initialise(minValue, maxValue);
        }

        private void Initialise(int minValue, int maxValue)
        {
            progressBar1.Minimum = minValue;
            minRangeText.Text = minValue.ToString();

            maxRangeText.Text = maxValue.ToString();
            progressBar1.Maximum = maxValue;

            progressText.Text = $"0/{maxValue}";
        }

        public void UpdateValue(int value)
        {
            progressBar1.Value = value;
            progressText.Text = $"{value}/{progressBar1.Maximum}";

            if (value == progressBar1.Maximum)
            {
                this.Close();
            }
        }
    }
}
