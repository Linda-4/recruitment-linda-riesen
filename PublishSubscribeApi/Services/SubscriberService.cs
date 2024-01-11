using PublishSubscribeApi.Models.Dtos;

namespace PublishSubscribeApi.Services
{
    public class SubscriberService : ISubscriberService
    {
        private readonly List<SubscriberDto> _subscribers;

        public SubscriberService()
        {
            _subscribers = new List<SubscriberDto>();
        }

        public void CreateSubscriber(string subscriberName, string outputValue)
        {
            if (GetSubscriber(subscriberName) != null)
            {
                throw new ArgumentException($"A subscriber with name '{subscriberName}' is already registerd!");
            }

            _subscribers.Add(new SubscriberDto()
            {
                Name = subscriberName,
                OutputValue = outputValue
            });
        }

        public void DeleteSubscriber(string subscriberName)
        {
            if (GetSubscriber(subscriberName) == null)
            {
                throw new ArgumentException($"A publisher with name '{subscriberName}' is not registerd!");
            }

            _subscribers.Remove(_subscribers.First(s => s.Name.Equals(subscriberName)));
        }

        public SubscriberDto GetSubscriber(string subscriberName)
        {
            return _subscribers.FirstOrDefault(s => s.Name.Equals(subscriberName));
        }
    }
}
