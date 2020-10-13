using Ninject;
using Persistence.KnnProject.Repositories;

namespace Business.KnnProject.Services
{
    public abstract class ServiceBase
    {
        protected readonly IUnitOfWork _unitOfWork;

        protected ServiceBase() => _unitOfWork = new UnitOfWork();

        protected static void ResgisterServices(IKernel kernel)
        {
            kernel.Bind<ICategoryService>().To<CategoryService>();
            kernel.Bind<IColorService>().To<ColorService>();
            kernel.Bind<IContactService>().To<ContactService>();
            kernel.Bind<IImageStorageService>().To<ImageStorageService>();
            kernel.Bind<IOrderDetailService>().To<OrderDetailService>();
            kernel.Bind<IProductService>().To<ProductService>();
            kernel.Bind<IRankService>().To<RankService>();
            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<ISizeService>().To<SizeService>();
            kernel.Bind<ISizeService>().To<SizeService>();
            kernel.Bind<ITagService>().To<TagService>();
            kernel.Bind<IUserService>().To<UserService>();
        }
    }
}
