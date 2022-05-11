namespace DuckyTalk.Services
{
    public interface IMessageService:ICRUDService<Model.Message, Model.SearchRequests.MessageSearchRequest, Model.UpsertRequests.MessageUpsertRequest, Model.UpsertRequests.MessageUpsertRequest>
    {
    }
}
