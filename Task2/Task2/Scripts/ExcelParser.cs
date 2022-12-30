using Aspose.Cells;
using MySqlConnector;

namespace Task2.Scripts
{
    public static class ExcelParser
    {
        public static ExcelFile Parse(string path, string fileName)
        {
            ExcelFile excelFile = new ExcelFile(fileName);

            using (Workbook book = new Workbook(path))
            {
                var sheet = book.Worksheets[0];
                var rowCount = sheet.Cells.MaxDataRow;
                var cells = sheet.Cells;
                int classIndex = 1;

                //var rowClassName = rows[8].Cell(1).Value.ToString();
                var cell = sheet.Cells[8, 0];
                var rowClassName = sheet.Cells[8, 0].Value.ToString();

                RowClass rowClass = new RowClass(classIndex, rowClassName.Substring(rowClassName.IndexOf(rowClassName.LastOrDefault(c => c >= '0' && c <= '9'))+2));

                for (int i = 9; i < rowCount; i++)
                {
                    var c = cells.Rows[i];

                    if (double.TryParse(cells[i, 0].Value.ToString(), out double value1))
                    {
                        Row row = new Row(GetTruncatedValue(cells[i, 0].Value), GetTruncatedValue(cells[i, 1].Value), GetTruncatedValue(cells[i, 2].Value), GetTruncatedValue(cells[i, 3].Value), GetTruncatedValue(cells[i, 4].Value), GetTruncatedValue(cells[i, 5].Value), GetTruncatedValue(sheet.Cells[i, 6].Value));
                        rowClass.AddRow(row);
                    }
                    else if (cells[i, 1].Value == null)
                    {
                        classIndex++;
                        excelFile.AddRowClass(rowClass);
                        rowClassName = cells[i, 0].Value.ToString();

                        if (rowClassName.Where(c => c >= '0' && c <= '9').Count() > 0)
                        {
                            rowClass = new RowClass(classIndex, rowClassName.Substring(rowClassName.IndexOf(rowClassName.LastOrDefault(c => c >= '0' && c <= '9')) + 2));
                        }
                    }
                }
                excelFile.AddRowClass(rowClass);
            }

            return excelFile;
        }

        public static void SendExcelToDB(ExcelFile excelFile)
        {
            using (MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=task2"))
            {
                connection.Open();
                var classes = excelFile.GetClasses();
                int insertedIncomeID, insertedOutcomeID, insertedTurnID, insertedFileID;

                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;

                command.CommandText = $"INSERT INTO `files` value (default, '{excelFile.FileName}')";
                command.ExecuteNonQuery();
                command.CommandText = "SELECT LAST_INSERT_ID()";
                insertedFileID = Convert.ToInt32(command.ExecuteScalar());

                command.Parameters.Add("ActiveIncome", System.Data.DbType.Double);
                command.Parameters.Add("PassiveIncome", System.Data.DbType.Double);
                command.Parameters.Add("Debet", System.Data.DbType.Double);
                command.Parameters.Add("Credet", System.Data.DbType.Double);
                command.Parameters.Add("ActiveOutcome", System.Data.DbType.Double);
                command.Parameters.Add("PassiveOutcome", System.Data.DbType.Double);


                for (int i = 0; i < classes.Count; i++)
                {
                    //insert income
                    var rowclass = classes[i];

                    for (int j = 0; j < rowclass.Rows.Count; j++)
                    {
                        var row = rowclass.Rows[j];

                        command.CommandText = $"INSERT INTO `incomebalance` VALUE (default, @'ActiveIncome', @'PassiveIncome')";
                        command.Parameters["ActiveIncome"].Value = row.activeIncome;
                        command.Parameters["PassiveIncome"].Value = row.passiveIncome;
                        command.ExecuteNonQuery();
                        command.CommandText = "SELECT LAST_INSERT_ID()";
                        insertedIncomeID = Convert.ToInt32(command.ExecuteScalar());

                        command.CommandText = $"INSERT INTO `turns` VALUE (default, @'Debet', @'Credet')";
                        command.Parameters["Debet"].Value = row.debet;
                        command.Parameters["Credet"].Value = row.credit;
                        command.ExecuteNonQuery();
                        command.CommandText = "SELECT LAST_INSERT_ID()";
                        insertedTurnID = Convert.ToInt32(command.ExecuteScalar());

                        command.CommandText = $"INSERT INTO `outcomebalance` VALUE (default, @'ActiveOutcome', @'PassiveOutcome')";
                        command.Parameters["ActiveOutcome"].Value = row.activeOutcome;
                        command.Parameters["PassiveOutcome"].Value = row.passiveOutcome;
                        command.ExecuteNonQuery();
                        command.CommandText = "SELECT LAST_INSERT_ID()";
                        insertedOutcomeID = Convert.ToInt32(command.ExecuteScalar());
                         command.CommandText = $"INSERT INTO `record` VALUE (default, '{row.number}', (SELECT ID FROM class WHERE ClassOrder = {rowclass.Class}), '{insertedIncomeID}', '{insertedTurnID}', '{insertedOutcomeID}', '{insertedFileID}')";
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public static async Task<ExcelFile> GetDataFromDB(string fileName)
        {
            ExcelFile excelFile = new ExcelFile(fileName);

            using (MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=task2"))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;


                // this awful query
                command.CommandText = $"SELECT record.BankAccNumber, incomebalance.Active, incomebalance.Passive, turns.Debit, turns.Credit, outcomebalance.Active, outcomebalance.Passive, class.ClassOrder, class.Name FROM record inner join incomebalance on incomebalance.ID = record.IncomeBalanceID inner join turns on record.TurnsID = turns.ID INNER join outcomebalance on record.OutcomeBalanceID = outcomebalance.ID INNER join files on files.ID = record.FileID INNER JOIN class on record.ClassID = class.ID WHERE files.FileName like '{fileName}';";
                MySqlDataReader reader = await command.ExecuteReaderAsync();
                int rowClassIndex = 1;

                //RowClass rowClass = new RowClass(rowClassIndex);
                RowClass rowClass = null;

                while (await reader.ReadAsync())
                {
                    Row row = new Row(reader.GetInt32(0), reader.GetDouble(1), reader.GetDouble(2), reader.GetDouble(3), reader.GetDouble(4), reader.GetDouble(5), reader.GetDouble(6));

                    //command.CommandText = $"SELECT ClassOrder FROM class where ID = {reader.GetInt32(7)};";
                    int currentRowClassIndex = reader.GetInt32(7);

                    if (rowClass== null)
                    {
                        rowClass = new RowClass(1, reader.GetString(8));
                    }

                    if (currentRowClassIndex > rowClassIndex)
                    {
                        excelFile.AddRowClass(rowClass);

                        rowClassIndex++;
                        rowClass = new RowClass(rowClassIndex, reader.GetString(8));
                    }

                    rowClass.AddRow(row);

                }
                excelFile.AddRowClass(rowClass);
            }

            return excelFile;
        }

        private static double GetTruncatedValue(object value)
        {
            return Math.Round(Convert.ToDouble(value), 2);
        }
    }
}
