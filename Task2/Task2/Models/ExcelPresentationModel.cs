using Task2.Scripts;

namespace Task2.Models
{
    public class ExcelPresentationModel
    {
        public List<string> UploadedFiles { get; set; } = new List<string>();
        public ExcelFile ExcelFile { get; set; }
    }
}
