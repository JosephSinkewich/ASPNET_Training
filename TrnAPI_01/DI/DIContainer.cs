using DAL.Repositories.Interfaces;
using DAL.Repositories.Implementations;
using DAL.Helpers;
using BLL.Services.Interfaces;
using BLL.Services.Implementations;
using Unity;

namespace DI
{
    public class DIContainer
    {
        public static UnityContainer UpdateContainer(UnityContainer container)
        {
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<IEmailRepository, EmailRepository>();
            container.RegisterType<IEventRepository, EventRepository>();
            container.RegisterType<IPictureRepository, PictureRepository>();
            container.RegisterType<IRecordRepository, RecordRepository>();
            container.RegisterType<IRoleRepository, RoleRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            
            container.RegisterType<ISQLHelper, SQLHelper>();

            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<IEmailService, EmailService>();
            container.RegisterType<IEventService, EventService>();
            container.RegisterType<IPictureService, PictureService>();
            container.RegisterType<IRecordService, RecordService>();
            container.RegisterType<IRoleService, RoleService>();
            container.RegisterType<IUserService, UserService>();
            
            return container;
        }
    }
}
