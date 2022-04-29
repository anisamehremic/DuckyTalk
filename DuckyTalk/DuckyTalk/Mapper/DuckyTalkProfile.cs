using AutoMapper;

namespace DuckyTalk.Mapper
{
    public class DuckyTalkProfile:Profile
    {
        public DuckyTalkProfile()
        {
            CreateMap<Database.User, Model.User>().ReverseMap();
            CreateMap<Database.Technology, Model.Technology>().ReverseMap();
            CreateMap<Database.UserTechnology, Model.UserTechnology>().ReverseMap();
            CreateMap<Model.UpsertRequests.UserUpsertRequest, Database.User>().ReverseMap();
            CreateMap<Model.UpsertRequests.TechnologyUpsertRequest, Database.Technology>().ReverseMap();
            CreateMap<Model.UpsertRequests.UserTechnologyUpsertRequest, Database.UserTechnology>().ReverseMap();
        }
    }
}
