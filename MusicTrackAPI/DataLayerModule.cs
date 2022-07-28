using Autofac;
using MusicTrackAPI.Data.Repositories;
using MusicTrackAPI.Data.Repositories.Interfaces;

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
            builder.RegisterType<TrackRepository>().As<ITrackRepository>().InstancePerLifetimeScope();
            builder.RegisterType<AlbumRepository>().As<IAlbumRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PlaylistRepository>().As<IPlaylistRepository>().InstancePerLifetimeScope();
        }
    }
}

