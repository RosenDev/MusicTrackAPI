using Autofac;
using MusicTrackAPI.Data.Repositories;

namespace MusicTrackAPI
{
    public class DataLayerModule : Module
	{ 
		public DataLayerModule()
		{
		}

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterGeneric(typeof(RepositoryBase<>)).As(typeof(IRepositoryBase<>)).InstancePerLifetimeScope(); ;
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
        }
    }
}

