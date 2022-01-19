using ExcelDataReader;
using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

namespace Excel2Json.Services
{
    public class Excel2JsonConverter : IExcel2JsonConverter
    {
        public void ConvertExcel2Json(bool generateIndividualJsonFile, string excelFilePath)
        {
            DataSet excelDataSet = GetDataSetFromExcel(ref excelFilePath);

            for (int i = 0; i < excelDataSet.Tables.Count; i++)
            {
                GenerateJsonFilesFromTable(excelDataSet, excelDataSet.Tables[i].TableName, ref generateIndividualJsonFile, ref excelFilePath);
            }
        }

        private DataSet GetDataSetFromExcel(ref string excelFilePath)
        {
            using (IExcelDataReader excelReader = GeteReader(ref excelFilePath))
            {
                if (excelReader == null)
                {
                    return null;
                }

                DataSet dataSet = new DataSet();
                do
                {
                    DataTable dataTable = GetSheetData(excelReader);

                    if (dataTable != null)
                    {
                        dataSet.Tables.Add(dataTable);
                    }
                }
                while (excelReader.NextResult());

                return dataSet;
            }
        }

        private DataTable GetSheetData(IExcelDataReader excelReader)
        {
            if (excelReader == null)
            {
                return null;
            }

            //Create the table with the spreadsheet name
            DataTable table = new DataTable(excelReader.Name);
            table.Clear();

            string value = null;
            bool rowIsEmpty;

            while (excelReader.Read())
            {
                DataRow row = table.NewRow();
                rowIsEmpty = true;
                for (int i = 0; i < excelReader.FieldCount; i++)
                {
                    // If the column is null and this is the first row, skip
                    // to next iteration (do not want to include empty columns)
                    if (excelReader.IsDBNull(i) &&
                        (excelReader.Depth == 1 || i > table.Columns.Count - 1))
                    {
                        continue;
                    }


                    if (excelReader.IsDBNull(i))
                        value = "";
                    else
                    {

                        if (excelReader.GetFieldType(i).ToString() == "System.Double")
                        {
                            value = excelReader.IsDBNull(i) ? "" : excelReader.GetDouble(i).ToString();
                        }

                        if (excelReader.GetFieldType(i).ToString() == "System.Int")
                        {
                            value = excelReader.IsDBNull(i) ? "" : excelReader.GetInt32(i).ToString();
                        }

                        if (excelReader.GetFieldType(i).ToString() == "System.Bool")
                        {
                            value = excelReader.IsDBNull(i) ? "" : excelReader.GetBoolean(i).ToString();
                        }

                        if (excelReader.GetFieldType(i).ToString() == "System.DateTime")
                        {
                            value = excelReader.IsDBNull(i) ? "" : excelReader.GetDateTime(i).ToString();
                        }

                        if (excelReader.GetFieldType(i).ToString() == "System.TimeSpan")
                        {
                            value = excelReader.IsDBNull(i) ? "" : excelReader.GetDateTime(i).ToString();
                        }

                        if (excelReader.GetFieldType(i).ToString() == "System.String")
                        {
                            value = excelReader.IsDBNull(i) ? "" : excelReader.GetString(i).ToString();
                        }
                    }


                    if (excelReader.Depth == 0)
                    {
                        table.Columns.Add(value);
                    }
                    else
                    {
                        row[table.Columns[i]] = value;
                    }

                    if (!string.IsNullOrEmpty(value))
                    {
                        rowIsEmpty = false;
                    }
                }

                if (excelReader.Depth >= 1 && !rowIsEmpty)
                {
                    table.Rows.Add(row);
                }
            }

            return table;
        }

        private IExcelDataReader GeteReader(ref string excelFilePath)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            FileStream stream = File.Open(excelFilePath, FileMode.Open, FileAccess.Read);

            IExcelDataReader eReader;

            Regex xlsRegex = new Regex(@"^(.*\.(xls$))");
            Regex xlsxRegex = new Regex(@"^(.*\.(xlsx$))");

            if (xlsRegex.IsMatch(excelFilePath))
            {
                // Reading from *.xls)
                eReader = ExcelReaderFactory.CreateBinaryReader(stream);
            }
            else if (xlsxRegex.IsMatch(excelFilePath))
            {
                // Reading from *.xlsx)
                eReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            }
            else
            {
                return null;
            }

            return eReader;

        }

        private void GenerateJsonFilesFromTable(DataSet excelDataSet, string sheetName, ref bool generateIndividualJsonFile, ref string excelFilePath)
        {
            DataTable dataTable = excelDataSet.Tables[sheetName];
            if (generateIndividualJsonFile)
            {
                DataTable table = dataTable.Copy();
                table.Clear();

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    table.ImportRow(dataTable.Rows[i]);

                    string folderPath = Path.Combine(Path.GetDirectoryName(excelFilePath), Path.GetFileNameWithoutExtension(excelFilePath));
                    string fileName = Path.Combine(folderPath, (i + 1).ToString("0000000") + ".json");
                    if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

                    System.IO.File.WriteAllText(fileName, Newtonsoft.Json.JsonConvert.SerializeObject(table));

                    table.Clear();
                }

            }
            else
            {
                string spreadSheetJson = JsonConvert.SerializeObject(dataTable);

                string folderPath = Path.Combine(Path.GetDirectoryName(excelFilePath), Path.GetFileNameWithoutExtension(excelFilePath));
                string fileName = Path.Combine(folderPath, "ConvertedFile.json");
                if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);
                System.IO.File.WriteAllText(fileName + ".json", spreadSheetJson);
            }
        }
    }
}
