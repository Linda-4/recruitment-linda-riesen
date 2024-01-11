using PublishSubscribeApi.Models.Dtos;

namespace PublishSubscribeApi.Services
{
    public interface ISubscriberService
    {
        void CreateSubscriber(string subscriberName, string outputValue);
        SubscriberDto GetSubscriber(string subscriberName);
        void DeleteSubscriber(string subscriberName);
    }
}
