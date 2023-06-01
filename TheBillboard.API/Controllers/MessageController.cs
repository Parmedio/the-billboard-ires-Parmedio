using Microsoft.AspNetCore.Mvc;

namespace TheBillboard.API.Controllers;

using Data.Abstract;
using Data.Models;
using TheBillboard.Data.Gateways;

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
    public IActionResult Get()
    {
        try
        {
            var messages = _gateway.GetAll();
            return Ok(messages);
        }
        catch
        {
            return Problem();
        }
    }

    [HttpGet("{id:int}")]
    public Message GetById(int id) => _gateway.GetById(id)!;


    [HttpPost]
    public IActionResult Post([FromBody] Message message)
    {
        if (message.Title == string.Empty || message.Body == string.Empty || message.AuthorId == null)
        {
            return BadRequest();
}
        else
        {
            _gateway.Insert(message);
            return Ok();
        }
    } 

    [HttpPut]
    public IActionResult Put([FromBody] Message message)
    {
        try
        {
            _gateway.Modify(message);
            return Ok();
        }
        catch
        {
            return BadRequest();
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
            return Ok();
        }
    } 
}