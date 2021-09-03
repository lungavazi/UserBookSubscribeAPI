using AutoMapper;
using UserBookSubscribeAPI.Models.DTO;

namespace UserBookSubscribeAPI.Profiles
{
    public class UserBookProfile: Profile
    {
        public UserBookProfile()
        {
            CreateMap<Entities.Book,BookDTO >().ReverseMap();
            CreateMap<Entities.Book,BookAddDTO >().ReverseMap();
            CreateMap<Entities.User,UserDTO>().ReverseMap();
            CreateMap<Entities.User,UserAddDTO>().ReverseMap();
            CreateMap<Entities.Subscribe,SubscribeDTO>().ReverseMap();
        }
    }
}
