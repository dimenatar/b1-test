using Task2.Scripts;

namespace Task2.Models
{
    public class ExcelPresentationModel
    {
        public List<string> Files { get; set; }
        public ExcelFile ExcelFile { get; set; } = new ExcelFile("name");
    }
}
