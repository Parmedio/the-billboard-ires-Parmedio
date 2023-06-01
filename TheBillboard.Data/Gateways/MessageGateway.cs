namespace TheBillboard.Data.Gateways;

using Abstract;
using Microsoft.EntityFrameworkCore;
using Models;
using TheBillboard.Data.Data;

public class MessageGateway : IGateway<Message>
{
    private readonly TheBillboardContext _context;

    public MessageGateway(TheBillboardContext context) => _context = context;

    public IEnumerable<Message> GetAll() => _context.Messages.Include(m => m.Author);

    public Message? GetById(int id) => _context.Messages.Find(id);

    public Message Insert(Message entity)
    {
        var e = _context.Messages.Add(entity);
        _context.SaveChanges();

        return e.Entity;
    }

    public void Delete(int id)
    {
        var message = _context.Messages.Find(id);
        if (message != null)
        {
            _context.Messages.Remove(message);
            _context.SaveChanges();
        }
    }

    public Message Modify(Message entity)
    {
        var e = _context.Messages.Update(entity);
        _context.SaveChanges();

        return e.Entity;
    }
}