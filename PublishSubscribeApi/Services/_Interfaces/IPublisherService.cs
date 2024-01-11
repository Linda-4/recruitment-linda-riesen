using PublishSubscribeApi.Models.Dtos;

namespace PublishSubscribeApi.Services
{
    public interface IPublisherService
    {
        void CreatePublisher(string publisherName);
        PublisherDto GetPublisher(string publisherName);
        void DeletePublisher(string publisherName);
        void AddSubscriberToPublisher(string publisherName, SubscriberDto subscriber);
        void RemoveSubscriberFromPublisher(string publisherName, string subscriberName);
        List<string> PublishEvent(string publisherName);
        bool IsSubscriberConnectedToAnyPublishers(string subscriberName);
    }
}
