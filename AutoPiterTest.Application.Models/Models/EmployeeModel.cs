namespace AutoPiterTest.Application.Models.Models;

public class EmployeeModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public BranchModel Branch { get; set; }
}