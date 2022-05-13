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
            CreateMap<Database.Interest, Model.Interest>().ReverseMap();
            CreateMap<Database.Message, Model.Message>().ReverseMap();
            CreateMap<Database.UserMessage, Model.UserMessage>().ReverseMap();
            CreateMap<Database.UserInterest, Model.UserInterest>().ReverseMap();
            CreateMap<Database.UserBreakReminder, Model.UserBreakReminder>().ReverseMap();
            CreateMap<Model.UpsertRequests.UserUpsertRequest, Database.User>().ReverseMap();
            CreateMap<Model.UpsertRequests.TechnologyUpsertRequest, Database.Technology>().ReverseMap();
            CreateMap<Model.UpsertRequests.UserTechnologyUpsertRequest, Database.UserTechnology>().ReverseMap();
            CreateMap<Model.UpsertRequests.InterestUpsertRequest, Database.Interest>().ReverseMap();
            CreateMap<Model.UpsertRequests.MessageUpsertRequest, Database.Message>().ReverseMap();
            CreateMap<Model.UpsertRequests.UserMessageUpsertRequest, Database.UserMessage>().ReverseMap();
            CreateMap<Model.UpsertRequests.UserInterestUpsertRequest, Database.UserInterest>().ReverseMap();
            CreateMap<Model.UpsertRequests.UserBreakReminderUpsertRequests, Database.UserBreakReminder>().ReverseMap();

        }
    }
}
