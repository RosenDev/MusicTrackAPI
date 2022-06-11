using Autofac;
using MusicTrackAPI.Services;

namespace MusicTrackAPI
{
    public class ServiceLayerModule : Module
	{
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().InstancePerLifetimeScope();
        }
    }
}

