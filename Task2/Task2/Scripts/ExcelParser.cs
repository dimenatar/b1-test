using ClosedXML.Excel;
using MySqlConnector;

namespace Task2.Scripts
{
    public static class ExcelParser
    {
        public static ExcelFile Parse(string path, string fileName)
        {
            ExcelFile excelFile = new ExcelFile(fileName);
            using (XLWorkbook workBook = new XLWorkbook(path))
            {
                IXLWorksheet workSheet = workBook.Worksheet(1);
                var rows = workSheet.Rows().ToList();

                int classIndex = 1;
                RowClass rowClass = new RowClass(classIndex);

                for (int i = 9; i < rows.Count; i++)
                {
                    var excelRow = rows[i];
                    var type = excelRow.Cell(2).Value.GetType();

                    if (double.TryParse(rows[i].Cell(1).Value.ToString(), out double value1))
                    {
                        Row row = new Row(Convert.ToDouble(rows[i].Cell(1).Value), Convert.ToDouble(rows[i].Cell(2).Value), Convert.ToDouble(rows[i].Cell(3).Value), Convert.ToDouble(rows[i].Cell(4).Value), Convert.ToDouble(rows[i].Cell(5).Value), Convert.ToDouble(rows[i].Cell(6).Value), Convert.ToDouble(rows[i].Cell(7).Value));
                        rowClass.AddRow(row);
                    }
                    else if (!double.TryParse(rows[i].Cell(2).Value.ToString(), out double value2))
                    {
                        classIndex++;
                        excelFile.AddRowClass(rowClass);
                        rowClass = new RowClass(classIndex);
                    }
                }
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
                command.Parameters.Add("Credit", System.Data.DbType.Double);
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

                        command.CommandText = $"INSERT INTO `turns` VALUE (default, @'Debet', @'Credit')";
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
                command.CommandText = $"SELECT record.BankAccNumber, incomebalance.Active, incomebalance.Passive, turns.Debit, turns.Credit, outcomebalance.Active, outcomebalance.Passive, class.ClassOrder FROM record inner join incomebalance on incomebalance.ID = record.IncomeBalanceID inner join turns on record.TurnsID = turns.ID INNER join outcomebalance on record.OutcomeBalanceID = outcomebalance.ID INNER join files on files.ID = record.FileID INNER JOIN class on record.ClassID = class.ID WHERE files.FileName like '{fileName}';";
                MySqlDataReader reader = await command.ExecuteReaderAsync();
                int rowClassIndex = 1;

                RowClass rowClass = new RowClass(rowClassIndex);

                while (await reader.ReadAsync())
                {
                    Row row = new Row(reader.GetInt32(0), reader.GetDouble(1), reader.GetDouble(2), reader.GetDouble(3), reader.GetDouble(4), reader.GetDouble(5), reader.GetDouble(6));

                    //command.CommandText = $"SELECT ClassOrder FROM class where ID = {reader.GetInt32(7)};";
                    int currentRowClassIndex = reader.GetInt32(7);

                    if (currentRowClassIndex > rowClassIndex)
                    {
                        excelFile.AddRowClass(rowClass);

                        rowClassIndex++;
                        rowClass = new RowClass(rowClassIndex);
                    }

                    rowClass.AddRow(row);

                }
            }

            return excelFile;
        }
    }

    //SELECT record.BackAccNumber, incomebalance.Active, incomebalance.Passive, turns.Debit, turns.Credit, outcomebalance.Active, outcome.Passive FROM record inner join on incomebalance.ID = record.IncomeBalanceID inner join turns on record.TurnsID = turns.ID INNER join outcomebalance on record.OutcomeBalanceID = outcomebalance.ID INNER join files on files.ID = record.FileID WHERE files.FileName like 'test';
}
