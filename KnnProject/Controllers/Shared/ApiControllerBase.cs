using AutoMapper;

using KnnProject.ViewModels;
using Persistence.KnnProject.Models;
using System.Web.Http;

namespace KnnProject.Controllers
{
    public abstract class ApiControllerBase : ApiController
    {
        protected IMapper _mapper;

        protected ApiControllerBase() => _mapper = CreateMapper();

        private IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, CategoryViewModel>();
                cfg.CreateMap<CreateCategoryViewModel, Category>();
                cfg.CreateMap<ModifiedCategoryViewModel, Category>();

                cfg.CreateMap<Color, ColorViewModel>();
                cfg.CreateMap<CreateColorViewModel, Color>();
                cfg.CreateMap<UpdateColorViewModel, Color>();

                cfg.CreateMap<Contact, ContactViewModel>();
                cfg.CreateMap<CreateContactViewModel, Contact>();
                cfg.CreateMap<UpdateContactViewModel, Contact>();

                cfg.CreateMap<ImageStorage, ImageStorageViewModel>();
                cfg.CreateMap<CreateImageStorageViewModel, ImageStorage>();
                cfg.CreateMap<UpdateImageStorageViewModel, ImageStorage>();

                cfg.CreateMap<Order, OrderViewModel>();
                cfg.CreateMap<CreateOrderViewModel, Order>();
                cfg.CreateMap<UpdateOrderViewModel, Order>();

                cfg.CreateMap<OrderDetail, OrderDetailViewModel>();
                cfg.CreateMap<CreateOrderDetailViewModel, OrderDetail>();
                cfg.CreateMap<UpdateOrderDetailViewModel, OrderDetail>();

                cfg.CreateMap<Rank, RankViewModel>();
                cfg.CreateMap<CreateRankViewModel, Rank>();
                cfg.CreateMap<UpdateRankViewModel, Rank>();

                cfg.CreateMap<Role, RoleViewModel>();
                cfg.CreateMap<CreateRoleViewModel, Role>();
                cfg.CreateMap<UpdateRoleViewModel, Role>();

                cfg.CreateMap<Size, SizeViewModel>();
                cfg.CreateMap<CreateSizeViewModel, Size>();
                cfg.CreateMap<UpdateSizeViewModel, Size>();

                cfg.CreateMap<Tag, TagViewModel>();
                cfg.CreateMap<CreateTagViewModel, Tag>();
                cfg.CreateMap<UpdateTagViewModel, Tag>();

                cfg.CreateMap<User, UserViewModel>();
                cfg.CreateMap<CreateUserViewModel, User>();
                cfg.CreateMap<UpdateUserViewModel, User>();

                cfg.CreateMap<ColorProductViewModel, ColorProduct>().ReverseMap();
                cfg.CreateMap<ContactViewModel, Contact>().ReverseMap();
                cfg.CreateMap<ImageStorageViewModel, ImageStorage>().ReverseMap();
                cfg.CreateMap<OrderViewModel, Order>().ReverseMap();
                cfg.CreateMap<OrderDetailViewModel, OrderDetail>().ReverseMap();
                cfg.CreateMap<Product, ProductViewModel>().ReverseMap();
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
