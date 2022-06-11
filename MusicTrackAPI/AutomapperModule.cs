﻿using Autofac;
using AutoMapper;
using MusicTrackAPI.Data.Domain;
using MusicTrackAPI.Model;

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

