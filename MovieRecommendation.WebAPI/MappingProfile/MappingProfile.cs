using AutoMapper;
using MovieRecommendation.Entities;
using System.Collections.Generic;

namespace MovieRecommendation.Business.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MoviesDto, Movies>();
            CreateMap<Movies, MoviesDto>();
        }
    }
}