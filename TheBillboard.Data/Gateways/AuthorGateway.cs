namespace TheBillboard.Data.Gateways;

using Abstract;
using Microsoft.EntityFrameworkCore;
using Models;
using TheBillboard.Data.Data;

public class AuthorGateway : IGateway<Author>
{
    private readonly TheBillboardContext _context;
    public AuthorGateway(TheBillboardContext context) => _context = context;

    public IEnumerable<Author> GetAll() => _context.Authors;
    public Author? GetById(int id) => _context.Authors.SingleOrDefault(author => author.Id == id);
    public Author Insert(Author entity) => throw new NotImplementedException();
    public Author Modify(Author entity) => throw new NotImplementedException();
    public void Delete(int id) => throw new NotImplementedException();
}