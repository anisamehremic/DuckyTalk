namespace DuckyTalk.Services
{
    public interface IUserMessageService:ICRUDService<Model.UserMessage, Model.SearchRequests.UserMessageSearchRequest, Model.UpsertRequests.UserMessageUpsertRequest, Model.UpsertRequests.UserMessageUpsertRequest>
    {
    }
}
