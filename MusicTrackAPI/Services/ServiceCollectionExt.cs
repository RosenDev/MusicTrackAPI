using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicTrackAPI.Commands.Playlist;
using MusicTrackAPI.Data;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Data.Repositories;
using MusicTrackAPI.Data.Repositories.Interfaces;
using MusicTrackAPI.Model;
using MusicTrackAPI.Model.Album;
using MusicTrackAPI.Model.Playlist;
using MusicTrackAPI.Model.Track;
using MusicTrackAPI.Model.User;
using MusicTrackAPI.Services.Interface;

namespace MusicTrackAPI.Services
{
    public static class ServiceCollectionExt
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MusicTrackAPIDbContext>(opts =>
            opts.UseMySql(configuration.GetConnectionString("MySqlConnection"),
            ServerVersion.AutoDetect(configuration.GetConnectionString("MySqlConnection"))));
            services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(CreatePlaylistCommand).Assembly));

            services.AddDatabaseLayerServices();
            services.AddServiceLayerServices();
            services.AddAutoMapper();

            return services;
        }

        public static IServiceCollection AddDatabaseLayerServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITrackRepository, TrackRepository>();
            services.AddTransient<IAlbumRepository, AlbumRepository>();
            services.AddTransient<IPlaylistRepository, PlaylistRepository>();
            return services;
        }

        public static IServiceCollection AddServiceLayerServices(this IServiceCollection services)
        {
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITrackService, TrackService>();
            services.AddTransient<IAlbumService, AlbumService>();
            services.AddTransient<IPlaylistService, PlaylistService>();
            services.AddTransient(typeof(IDataService<,>), typeof(DataService<,>));

            return services;
        }

        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddSingleton(context => new MapperConfiguration(cfg =>
            {
                CreateMap<User, UserModel>(cfg);
                CreateMap<Track, TrackModel>(cfg);
                CreateMap<Album, AlbumModel>(cfg);
                CreateMap<Playlist, PlaylistModel>(cfg);

                cfg.CreateMap<TrackCreateModel, Track>()
                .ForMember(x => x.Id, opts => opts.Ignore());

                cfg.CreateMap<TrackUpdateModel, Track>();

                cfg.CreateMap<AlbumCreateModel, Album>()
                .ForMember(x => x.Id, opts => opts.Ignore())
                .ForMember(x => x.Tracks, opts => opts.Ignore())
                .ForMember(x => x.Playlists, opts => opts.Ignore());

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

            }));

            services.AddSingleton(sp =>
            {
                var config = sp.GetService<MapperConfiguration>();
                return config.CreateMapper(sp.GetService);
            });

            return services;
        }

        private static void CreateMap<TSource, TDestination>(IMapperConfigurationExpression config)
        {
            config.CreateMap<TSource, TDestination>();
            config.CreateMap<TDestination, TSource>();
        }
    }
}
