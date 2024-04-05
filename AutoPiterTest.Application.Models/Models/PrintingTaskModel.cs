namespace AutoPiterTest.Application.Models.Models;

public class PrintingTaskModel
{
    public string Name { get; set; }
    public EmployeeModel Employee { get; set; }
    public int SerialNumber { get; set; }
    public int NumberOfPages { get; set; }
    public bool IsSuccessful { get; set; }
}