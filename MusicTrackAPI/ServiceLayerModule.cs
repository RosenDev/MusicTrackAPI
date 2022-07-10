using Autofac;
using MusicTrackAPI.Services;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI
{
    public class ServiceLayerModule : Module
	{
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
        }
    }
}

