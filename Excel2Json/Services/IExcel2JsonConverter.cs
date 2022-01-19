using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel2Json.Services
{
    public interface IExcel2JsonConverter
    {
        void ConvertExcel2Json(bool generateIndividualJsonFile, string excelFilePath);
    }
}
