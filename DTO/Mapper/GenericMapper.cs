using AutoMapper;
using CQRSMediatRAutoMaperTask.DTO.Request;
using CQRSMediatRAutoMaperTask.DTO.Response;
using CQRSMediatRAutoMaperTask.Model;

namespace CQRSMediatRAutoMaperTask.DTO.Mapper
{
    public class GenericMapper : Profile
    {
        public GenericMapper()
        {
            CreateMap<GetCarByBrandIdResponse, Car>();

            CreateMap<GetAllCarsResponse, Car>();

            CreateMap<Car, GetAllCarsResponse>()
            .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Name));

            CreateMap<CreateCarRequest, Car>()
            .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.BrandId))
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Model));

            CreateMap<Car, CreateCarResponse>()
            .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand));

            CreateMap<CreateBrandRequest, Brand>()
            .ForMember(dest => dest.Cars, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<UpdateCarRequest, Car>()
            .ForMember(dest => dest.Brand, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedDate, opt => opt.Ignore());
        }
    }
}
