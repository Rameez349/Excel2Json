using Excel2Json.Converter;
using System;
using System.Windows.Forms;

namespace Excel2Json
{
    public partial class Main : Form
    {
        private static string ALLOWEDFILEEXTENSIONS = "*.xls|*.xlsx";
        public Main()
        {
            InitializeComponent();
        }

        private void btnBrowseFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog browseExcelFile = new OpenFileDialog();

            browseExcelFile.CheckFileExists = true;
            browseExcelFile.CheckPathExists = true;
            browseExcelFile.Multiselect = false;

            browseExcelFile.Filter = ALLOWEDFILEEXTENSIONS;

            if (browseExcelFile.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = browseExcelFile.FileName;
            }
        }

        private void ClearFile_Click(object sender, EventArgs e)
        {
            txtFilePath.Text = string.Empty;
        }

        private void btnConvertToJson_Click(object sender, EventArgs e)
        {
            try
            {
                bool generateIndividualJsonFiles = chkGenerateJsonType.Checked;
                IExcel2JsonConverter excel2JsonConverter = new Excel2JsonConverter();

                excel2JsonConverter.ConvertExcel2Json(generateIndividualJsonFiles, txtFilePath.Text);

                lblResult.Text = "Excel file has been converted to json file(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }

        }
    }
}
