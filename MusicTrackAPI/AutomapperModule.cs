using Autofac;
using AutoMapper;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Model;
using MusicTrackAPI.Model.Album;
using MusicTrackAPI.Model.Playlist;
using MusicTrackAPI.Model.Track;
using MusicTrackAPI.Model.User;

namespace MusicTrackAPI
{
    public class AutomapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                CreateMap<User, UserModel>(cfg);
                CreateMap<Track, TrackModel>(cfg);
                CreateMap<Album, AlbumModel>(cfg);
                CreateMap<Playlist, PlaylistModel>(cfg);

                cfg.CreateMap<TrackCreateModel,Track>()
                .ForMember(x => x.Id, opts => opts.Ignore());

                cfg.CreateMap<TrackUpdateModel, Track>();

                cfg.CreateMap<AlbumCreateModel, Album>()
                .ForMember(x => x.Id, opts => opts.Ignore())
                .ForMember(x=> x.Tracks, opts => opts.Ignore())
                .ForMember(x=> x.Playlists, opts => opts.Ignore());

                cfg.CreateMap<AlbumUpdateModel, Album>()
                .ForMember(x => x.Tracks, opts => opts.Ignore())
                .ForMember(x => x.Playlists, opts => opts.Ignore());

                cfg.CreateMap<PlaylistCreateModel, Playlist>()
                .ForMember(x => x.Id, opts => opts.Ignore())
                .ForMember(x => x.Album, opts => opts.Ignore())
                .ForMember(x => x.TracksPlaylists, opts => opts.Ignore());

                cfg.CreateMap<PlaylistUpdateModel, Playlist>()
               .ForMember(x => x.Album, opts => opts.Ignore())
               .ForMember(x => x.TracksPlaylists, opts => opts.Ignore());

                cfg.CreateMap<InsertTrackInPlaylistModel, TrackPlaylist>()
                .ForMember(x => x.Track, opts => opts.Ignore())
                .ForMember(x => x.Playlist, opts => opts.Ignore());

                cfg.CreateMap<TrackPlaylist, TrackInPlaylistModel>();
               
                cfg.CreateMap<UserRegisterModel, User>()
                .ForMember(x => x.Salt, opt => opt.Ignore())
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.CreatedAt, opt => opt.Ignore())
                .ForMember(x => x.UpdatedAt, opt => opt.Ignore());

                cfg.CreateMap<UserLoginModel, User>()
                .ForMember(x => x.Salt, opt => opt.Ignore())
                .ForMember(x => x.Email, opt => opt.Ignore())
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.CreatedAt, opt => opt.Ignore())
                .ForMember(x => x.UpdatedAt, opt => opt.Ignore());

            })).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();
        }

        private void CreateMap<TSource, TDestination>(IMapperConfigurationExpression config)
        {
            config.CreateMap<TSource, TDestination>();
            config.CreateMap<TDestination, TSource>();
        }

    }
}

