using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CarGuru.Database.ApisDtos;
using CarGuru.Database.Dtos.BaseDto;
using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.RequestDto;
using CarGuru.Database.Dtos.ResponseDto;
using CarGuru.Database.Models;

namespace CarGuru.Services.AutoMapper
{
  public  class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Users, UserResponseDto>().ReverseMap();
            CreateMap<Users, LoginResponseDto>().ReverseMap();
            CreateMap<Users, UserRequestDto>().ReverseMap();

            CreateMap<Lookups, LookupResponseDto>().ReverseMap();

            CreateMap<Customers, CustomerResponseDto>().ReverseMap();
            CreateMap<Customers, CustomerRequestDto>().ReverseMap();
            CreateMap<Customers, EditCustomerRequestDto>().ReverseMap();

            CreateMap<Employees, EmployeeResponseDto>().ReverseMap();
            CreateMap<Employees, EmployeeRequestDto>().ReverseMap();

            CreateMap<EmployeeTypes, EmployeeTypeResponseDto>().ReverseMap();
            CreateMap<CustomerTypes, CustomerTypeResponseDto>().ReverseMap();


            CreateMap<Products, ProductRequestDto>().ReverseMap();
            CreateMap<Products, ProductResponseDto>().ReverseMap();

            CreateMap<Vendors, VendorRequestDto>().ReverseMap();
            CreateMap<Vendors, VendorResponseDto>().ReverseMap();
            CreateMap<Vendors, VendorDto>().ReverseMap();

            CreateMap<ProductCategories, ProductCategoryRequestDto>().ReverseMap();
            CreateMap<ProductSubCategories, ProductSubCategoryRequestDto>().ReverseMap();
            CreateMap<ProductCategoryResponseDto, ProductCategoryRequestDto>().ReverseMap();
            CreateMap<ProductCategories, ProductCategoryResponseDto>().ReverseMap();
            CreateMap<ProductCategories, ProductCategoryBaseDto>().ReverseMap();

            CreateMap<CustomerVehicles, CustomerVehicleRequestDto>().ReverseMap();
            CreateMap<CustomerVehicles, CustomerVehicleResponseDto>().ReverseMap();

            CreateMap<ServiceOrders,ServiceOrderRequestDto>().ReverseMap();
            CreateMap<ServiceOrders, ServiceOrderResponseDto>().ReverseMap();

            CreateMap<ProductInServiceOrderDto, ProductsInServiceOrders>().ReverseMap();

            CreateMap<UserSignupDto, Users>().ReverseMap();
            
            CreateMap<CustomerVehicleDto, CustomerVehicles>().ReverseMap();

            CreateMap<ServicesInServiceOrderDto, ServicesInOrder>().ReverseMap();

            CreateMap<HelpRequests, MakeRequestApiDto>().ReverseMap(); 

            CreateMap<Roles, RolesResponseDto>().ReverseMap();

            CreateMap<Fleets, FleetResponseDto>().ReverseMap();
            CreateMap<Fleets, FleetRequestDto>().ReverseMap();

            CreateMap<Attendance, AttendanceAPiDto>().ReverseMap();
            CreateMap<Products, ProductListDto>().ReverseMap();

            CreateMap<ProductsInServiceOrders, ProductInOrderApiDto>().ReverseMap();
            
            CreateMap<ProductCategories, ProductCategoriesApiDto>().ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Title)
            ).ReverseMap();

            CreateMap<Feedback, FeedbackRequestDto>().ReverseMap();
            
            CreateMap<QuotationRequestDto, Qoutations>().ReverseMap();
            CreateMap<Qoutations, QuotationResponseDto>().ReverseMap();
            CreateMap<QuotationProduct, ProductsInQoutations>().ReverseMap();
            CreateMap<Conversation, ConversationDto>().ReverseMap();
            CreateMap<Conversation, MConversationDto>().ReverseMap();

            CreateMap<Users, UpdateEmployeeApiDto>().ReverseMap();
            CreateMap<ServiceOrderApiDto, ServiceOrders>().ReverseMap();

            CreateMap<MServices, ServicesInOrder>().ReverseMap();

            CreateMap<QuotationDto, Qoutations>().ReverseMap();
            CreateMap<ProductInQuotationDto, ProductsInQoutations>().ReverseMap();
            CreateMap<UserDeviceDto, UserDevices>().ReverseMap();
            CreateMap<APILogDto, APILogs>().ReverseMap();
            CreateMap<CustomerCardDetailDto, CustomerCardDetail>().ReverseMap();
            CreateMap<MakePaymentInputDto, CustomerPaymentDetail>().ReverseMap();
            CreateMap<ServiceTypeDto, CarGuru.Database.Models.ServiceType>().ReverseMap();

            CreateMap<NotificationDto, Notifications>().ReverseMap();
                //.ForMember(dest => dest.Type.Id,
                //    opts => opts.MapFrom(src => src.TypeId))
                //.ForMember(dest => dest.Type.LookupTitle,
                //    opts => opts.MapFrom(src => src.NotificationType)).ReverseMap();


            CreateMap<UserDevices, UserDevicesDto>().ReverseMap();

            CreateMap<Roles, RolesDto>().ReverseMap();
            CreateMap<PushQueueDto, NotificationQueue>().ReverseMap();
            CreateMap<UserUpdateDto, Users>().ReverseMap();
            CreateMap<UserUpdateModelDto, Users>().ReverseMap();

            CreateMap<ManualCallRecordDto, ManualCallRecords>().ReverseMap();     

        }
    }
}
