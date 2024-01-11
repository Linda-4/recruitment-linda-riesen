using Microsoft.AspNetCore.Mvc;
using PublishSubscribeApi.Models.Dtos;
using PublishSubscribeApi.Services;

namespace PublishSubscribeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;
        private readonly ISubscriberService _subscriberService;

        public PublisherController(IPublisherService publisherService, ISubscriberService subscriberService)
        {
            _publisherService = publisherService;
            _subscriberService = subscriberService;
        }

        [HttpGet("{name}")]
        public ActionResult<PublisherDto> GetPublisher(string name)
        {
            try
            {
                PublisherDto publisher = _publisherService.GetPublisher(name);

                if (publisher == null)
                {
                    return NotFound();
                }

                return Ok(publisher);
            }
            catch (ArgumentException ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult CreatePublisher([FromBody] PublisherDto publisher)
        {
            try
            {
                _publisherService.CreatePublisher(publisher.Name);

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("event/{name}")]
        public ActionResult<List<string>> SendPublishingEvent(string name)
        {
            try
            {
                List<string> outputValues = _publisherService.PublishEvent(name);

                return Ok(outputValues);
            }
            catch (ArgumentException ex)
            {
                return NotFound();
            }
        }

        [HttpPost("{publisherName}/Subscriber")]
        public ActionResult AddSubscriberToPublisher(string publisherName, [FromBody] string subscriberName)
        {
            try
            {
                SubscriberDto subscriber = _subscriberService.GetSubscriber(subscriberName);

                _publisherService.AddSubscriberToPublisher(publisherName, subscriber);

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{publisherName}/Subscriber")]
        public ActionResult RemoveSubscriberFromPublisher(string publisherName, [FromBody] string subscriberName)
        {
            try
            {
                _publisherService.RemoveSubscriberFromPublisher(publisherName, subscriberName);

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
               _publisherService.DeletePublisher(name);

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound();
            }
        }
    }
}
