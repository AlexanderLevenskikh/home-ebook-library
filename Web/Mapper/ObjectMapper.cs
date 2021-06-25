﻿using System;
using AutoMapper;
using Core.Entities;
using Web.ViewModels.Book;
using Web.ViewModels.Upload;

namespace Web.Mapper
{
    // The best implementation of AutoMapper for class libraries - https://stackoverflow.com/questions/26458731/how-to-configure-auto-mapper-in-class-library-project
    public class ObjectMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<WebMapperProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
        
        public class WebMapperProfile : Profile
        {
            public WebMapperProfile()
            {
                CreateMap<Upload, UploadDto>().ReverseMap();
                CreateMap<Book, BookDto>().ReverseMap();
            }
        }
    }
}
