using ClosedXML.Excel;
using MySqlConnector;

namespace Task2.Scripts
{
    public static class ExcelToBDParser
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
                        excelFile.AddRow(rowClass);
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
                var data = excelFile.GetClasses();
                int insertedIncomeID, insertedOutcomeID, insertedTurnID;

                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;


                for (int i = 0; i < data.Count; i++)
                {
                    //insert income
                    var rowclass = data[i];

                    for (int j = 0; j < rowclass.Rows.Count; j++)
                    {
                        var row = rowclass.Rows[j];

                        command.CommandText = $"INSERT INTO `incomebalance` VALUE (default, '{row.activeIncome}', '{row.passiveIncome}')";
                        command.ExecuteNonQuery();
                        command.CommandText = "SELECT LAST_INSERT_ID()";
                        insertedIncomeID = Convert.ToInt32(command.ExecuteScalar());

                        command.CommandText = $"INSERT INTO `turns` VALUE (default, '{row.debet}', '{row.credit}')";
                        command.ExecuteNonQuery();
                        command.CommandText = "SELECT LAST_INSERT_ID()";
                        insertedTurnID = Convert.ToInt32(command.ExecuteScalar());

                        command.CommandText = $"INSERT INTO `outcomebalance` VALUE (default, '{row.activeOutcome}', '{row.passiveOutcome}')";
                        command.ExecuteNonQuery();
                        command.CommandText = "SELECT LAST_INSERT_ID()";
                        insertedOutcomeID = Convert.ToInt32(command.ExecuteScalar());
                         command.CommandText = $"INSERT INTO `record` VALUE (default, '{row.number}', (SELECT ID FROM class WHERE ClassOrder = {rowclass.Class}), '{insertedIncomeID}', '{insertedTurnID}', '{insertedOutcomeID}')";
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public static bool IsNumber(this object value)
        {
            return value is sbyte
                    || value is byte
                    || value is short
                    || value is ushort
                    || value is int
                    || value is uint
                    || value is long
                    || value is ulong
                    || value is float
                    || value is double
                    || value is decimal;
        }
    }


}
