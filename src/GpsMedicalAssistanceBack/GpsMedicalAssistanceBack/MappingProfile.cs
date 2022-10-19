using AutoMapper;
using Entities.DataTransferObjects.Family;
using Entities.DataTransferObjects.FamilyType;
using Entities.DataTransferObjects.FavoritePlace;
using Entities.DataTransferObjects.User;
using Entities.Models;

namespace GpsMedicalAssistanceBack
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            // User Mapping
            CreateMap<User, UserDto>().ForMember(
                c => c.ImagePath,
                opt => {
                    opt.MapFrom(x => Convert.ToBase64String(System.IO.File.ReadAllBytes(x.ImagePath)));
                }
            );
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();

            // Family Mapping
            CreateMap<Family, FamilyDto>();
            CreateMap<FamilyCreateDto, Family>();

            // FamilyType Mapping
            CreateMap<FamilyType, FamilyTypeDto>();

            // FavoritePlace Mapping
            CreateMap<FavoritePlace, FavoritePlaceDto>();
            CreateMap<FavoritePlaceCreateDto, FavoritePlace>();
            CreateMap<FavoritePlace, FavoritePlaceCreateDto>();
        }
    }
}
