using AutoMapper;
using AutoPiterTest.Application.Models.Models;
using AutoPiterTest.Infrastructure.Entities.Entities;

namespace AutoPiterTest.Presentation.ProjectMapper;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<Branch, BranchModel>().ReverseMap();
        CreateMap<BranchPrintingDevice, BranchPrintingDeviceModel>().ReverseMap();
        CreateMap<Employee, EmployeeModel>().ReverseMap();
        CreateMap<MacAddress, MacAddressModel>().ReverseMap();
        CreateMap<PrintingDevice, PrintingDeviceModel>().ReverseMap();
        CreateMap<PrintingDeviceMacAddress, PrintingDeviceMacAddressModel>().ReverseMap();
        CreateMap<PrintingTask, PrintingTaskModel>().ReverseMap();
    }
}