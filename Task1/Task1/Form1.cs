using System.ComponentModel;

namespace Task1
{
    public partial class Form1 : Form
    {
        private ProgressForm _progressForm;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    var directory = fbd.SelectedPath;

                    FileGenerator.GenerateFiles(directory, FileGenerator.FILE_AMOUNT, FileGenerator.AMOUNT_LINES_IN_FILE);
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    var directory = fbd.SelectedPath;
                    MessageBox.Show(directory);

                    var files = Directory.GetFiles(directory);

                    FileDataManager.UniteFiles(files, directory + "\\United.txt", textBox1.Text);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var fileBrowserDG = new OpenFileDialog())
            {
                fileBrowserDG.Multiselect = true;

                if (fileBrowserDG.ShowDialog() == DialogResult.OK)
                {
                    var files = fileBrowserDG.FileNames;

                    _progressForm = new ProgressForm(0, FileDataManager.GetLineAmount(files));
                    Action<int> valueUpdated = (value) => _progressForm.Invoke((MethodInvoker)delegate { _progressForm.UpdateValue(value); });

                    var databaseManager = new DatabaseManager(serverValue.Text, int.Parse(portValue.Text), usernameValue.Text, passwordValue.Text, databaseValue.Text, tableValue.Text);

                    _progressForm.Show();

                    Thread thread = new Thread(t => databaseManager.Import(files, valueUpdated, () => _progressForm.Invoke((MethodInvoker)delegate { _progressForm.Close(); })));
                    thread.Start();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var databaseManager = new DatabaseManager(serverValue.Text, int.Parse(portValue.Text), usernameValue.Text, passwordValue.Text, databaseValue.Text, tableValue.Text);
            MessageBox.Show(databaseManager.GetAvg().ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var databaseManager = new DatabaseManager(serverValue.Text, int.Parse(portValue.Text), usernameValue.Text, passwordValue.Text, databaseValue.Text, tableValue.Text);
            MessageBox.Show(databaseManager.GetSum().ToString());
        }
    }
}