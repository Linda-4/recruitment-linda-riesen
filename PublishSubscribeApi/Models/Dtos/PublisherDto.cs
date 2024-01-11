namespace PublishSubscribeApi.Models.Dtos
{
    public class PublisherDto
    {
        public string Name { get; set; }
        public int ExecutionCount { get; set; }
        public List<SubscriberDto> Subscribers { get; set; }
    }
}
