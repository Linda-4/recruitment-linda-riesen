using PublishSubscribeApi.Models.Dtos;

namespace PublishSubscribeApi.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly List<PublisherDto> _publishers;

        public PublisherService()
        {
            _publishers = new List<PublisherDto>();
        }

        public void AddSubscriberToPublisher(string publisherName, SubscriberDto subscriber)
        {
            PublisherDto publisher = GetPublisher(publisherName);

            if (publisher == null)
            {
                throw new ArgumentException($"The publisher with name '{publisherName}' is not valid!");
            }

            if (!publisher.Subscribers.Any(s => s.Name.Equals(subscriber.Name)))
            {
                publisher.Subscribers.Add(subscriber);
            }
        }

        public void CreatePublisher(string publisherName)
        {
            if (GetPublisher(publisherName) != null)
            {
                throw new ArgumentException($"A publisher with name '{publisherName}' is already registerd!");
            }

            _publishers.Add(new PublisherDto { 
                Name = publisherName,  
                Subscribers = new List<SubscriberDto>()
            });
        }

        public void DeletePublisher(string publisherName)
        {
            if (GetPublisher(publisherName) == null)
            {
                throw new ArgumentException($"A publisher with name '{publisherName}' is not registerd!");
            }

            _publishers.Remove(_publishers.First(p => p.Name.Equals(publisherName)));
        }

        public PublisherDto GetPublisher(string publisherName)
        {
            return _publishers.FirstOrDefault(p => p.Name.Equals(publisherName));
        }

        public bool IsSubscriberConnectedToAnyPublishers(string subscriberName)
        {
            return _publishers.Any(p => p.Subscribers.Any(s => s.Name.Equals(subscriberName)));
        }

        public List<string> PublishEvent(string publisherName)
        {
            PublisherDto publisher = GetPublisher(publisherName);

            if (publisher == null)
            {
                throw new ArgumentException($"The publisher with name '{publisherName}' is not valid!");
            }

            return publisher.Subscribers.Select(s => s.OutputValue).ToList();

        }

        public void RemoveSubscriberFromPublisher(string publisherName, string subscriberName)
        {
            PublisherDto publisher = GetPublisher(publisherName);

            if (publisher == null)
            {
                throw new ArgumentException($"The publisher with name '{publisherName}' is not valid!");
            }

            if (!publisher.Subscribers.Any(s => s.Name.Equals(subscriberName)))
            {
                throw new ArgumentException($"The publisher with name '{publisherName}' has no subscriber with name '{subscriberName}' registered!");
            }

            publisher.Subscribers.Remove(publisher.Subscribers.First(s => s.Name.Equals(subscriberName)));
        }
    }
}
