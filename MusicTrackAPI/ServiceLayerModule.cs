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
            builder.RegisterType<TrackService>().As<ITrackService>().InstancePerLifetimeScope();
            builder.RegisterType<AlbumService>().As<IAlbumService>().InstancePerLifetimeScope();
            builder.RegisterType<PlaylistService>().As<IPlaylistService>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(DataService<,>)).As(typeof(IDataService<,>)).InstancePerLifetimeScope();
        }
    }
}

