namespace Excel2Json.Converter
{
    public interface IExcel2JsonConverter
    {
        void ConvertExcel2Json(bool generateIndividualJsonFile, string excelFilePath);
    }
}
