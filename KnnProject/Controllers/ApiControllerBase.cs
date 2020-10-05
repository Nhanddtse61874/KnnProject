using AutoMapper;

using KnnProject.ViewModels;
using Persistence.KnnProject.Models;
using System.Web.Http;

namespace KnnProject.Controllers
{
    public abstract class ApiControllerBase : ApiController
    {
        //default cua? .net core se~ co' DI
        //con` cua? .net framework thi` ko => minh` phai config = tay

        protected IMapper _mapper;

        protected ApiControllerBase()
        {
            _mapper = CreateMapper();
        }

        private IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryViewModel, Category>().ReverseMap();
                cfg.CreateMap<ColorViewModel, Color>().ReverseMap();
                cfg.CreateMap<ColorProductViewModel, ColorProduct>().ReverseMap();
                cfg.CreateMap<ContactViewModel, Contact>().ReverseMap();
                cfg.CreateMap<ImageStorageViewModel, ImageStorage>().ReverseMap();
                cfg.CreateMap<OrderViewModel, Order>().ReverseMap();
                cfg.CreateMap<OrderDetailViewModel, OrderDetail>().ReverseMap();
                cfg.CreateMap<Product, ProductViewModel>()
                    .ForMember(x => x.CategoryName, des => des.MapFrom(y => y.Category.CategoryName)).ReverseMap();
                cfg.CreateMap<RankViewModel, Rank>().ReverseMap();
                cfg.CreateMap<RoleViewModel, Role>().ReverseMap();
                cfg.CreateMap<SizeViewModel, Size>().ReverseMap();
                cfg.CreateMap<SizeProductViewModel, SizeProduct>().ReverseMap();
                cfg.CreateMap<TagViewModel, Tag>().ReverseMap();
                cfg.CreateMap<TagProductViewModel, TagProduct>().ReverseMap();
                cfg.CreateMap<UserViewModel, User>().ReverseMap();
            });

            return config.CreateMapper();
        }
    }
}
