using Microsoft.AspNetCore.Mvc;

namespace TheBillboard.API.Controllers;

using Data.Abstract;
using Data.Models;

[ApiController]
[Route("api/[controller]")]
public class MessageController : ControllerBase
{
    private readonly IGateway<Message> _gateway;
    private readonly ILogger<MessageController> _logger;

    public MessageController(IGateway<Message> gateway, ILogger<MessageController> logger)
    {
        _gateway = gateway;
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Message> Get() => _gateway.GetAll();

    [HttpPost]
    public IActionResult Post([FromBody] Message message)
    {
        if (message.Title is null || message.Body is null)
        {
            return BadRequest();
}
        else
        {
            _gateway.Insert(message);
            return StatusCode(200);
        }
    } 

    [HttpDelete]
    public IActionResult Delete(int Id)
    {
        if (_gateway.GetById(Id) is null)
        {
            return BadRequest();
        }
        else
        {
            _gateway.Delete(Id);
            return StatusCode(200);
        }
    } 

    [HttpPut]
    public IActionResult Put([FromBody] Message message)
    {
        _gateway.Modify(message);
        return Ok();
    }
}