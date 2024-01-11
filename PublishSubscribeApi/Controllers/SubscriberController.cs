using Microsoft.AspNetCore.Mvc;
using PublishSubscribeApi.Models.Dtos;
using PublishSubscribeApi.Services;

namespace PublishSubscribeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriberController : ControllerBase
    {
        private readonly IPublisherService _publisherService;
        private readonly ISubscriberService _subscriberService;

        public SubscriberController(IPublisherService publisherService, ISubscriberService subscriberService)
        {
            _publisherService = publisherService;
            _subscriberService = subscriberService;
        }

        [HttpGet("{name}")]
        public ActionResult<SubscriberDto> GetSubscriber(string name)
        {
            try
            {
                SubscriberDto subscriber = _subscriberService.GetSubscriber(name);

                if (subscriber == null)
                {
                    return NotFound();
                }
                
                return Ok(subscriber);
            }
            catch (ArgumentException ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult CreateSubscriber([FromBody] SubscriberDto subscriber)
        {
            try
            {
                _subscriberService.CreateSubscriber(subscriber.Name, subscriber.OutputValue);

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{name}")]
        public ActionResult DeletePublisher(string name)
        {
            try
            {
                if (_publisherService.IsSubscriberConnectedToAnyPublishers(name))
                {
                    return BadRequest();
                }

                _subscriberService.DeleteSubscriber(name);

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound();
            }
        }
    }
}
