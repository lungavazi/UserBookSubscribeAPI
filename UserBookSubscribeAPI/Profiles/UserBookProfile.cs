using AutoMapper;

namespace UserBookSubscribeAPI.Profiles
{
    public class UserBookProfile: Profile
    {
        public UserBookProfile()
        {
            CreateMap<Entities.Book,Entities.DTO.BookDTO >().ReverseMap();
            CreateMap<Entities.Book,Entities.DTO.BookAddDTO >().ReverseMap();
            CreateMap<Entities.User,Entities.DTO.UserDTO>().ReverseMap();
            CreateMap<Entities.User,Entities.DTO.UserAddDTO>().ReverseMap();
            CreateMap<Entities.Subscribe,Entities.DTO.SubscribeDTO>().ReverseMap();
        }
    }
}
