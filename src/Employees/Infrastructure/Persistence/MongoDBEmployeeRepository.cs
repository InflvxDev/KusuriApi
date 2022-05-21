using System.Linq.Expressions;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Kusuri.Employees.Domain;
using Kusuri.Shared.Domain.Respository.Mongo;

namespace Kusuri.Employees.Infrastructure.Persistence;

public class MongoDBEmployeeRepository : IEmployeeRepository
{
    private readonly IMongoCollection<Employee> _employees;

    public MongoDBEmployeeRepository (IOptions<MongoDBSettings> options)
    {
        var client = new MongoClient(options.Value.ConnectionString);
        var database = client.GetDatabase(options.Value.DatabaseName);
        _employees = database.GetCollection<Employee>(options.Value.CollectionName);
    }

    public async Task Save(Employee entity)
    {
        await _employees.InsertOneAsync(entity);
    }

    public async Task<Employee?> Find(string key, bool noTracking)
    {
        return await _employees.Find(x => x.Id == key).FirstOrDefaultAsync();
    }

    public async Task<Employee?> Find(string key)
    {
        return await _employees.Find(x => x.Id == key).FirstOrDefaultAsync();
    }

    public async Task<bool> Any(Expression<Func<Employee, bool>> predicate)
    {
        return await _employees.Find(predicate).AnyAsync();
    }

    public async Task<IEnumerable<Employee>> SearchAll()
    {
        return await _employees.Find(_ => true).ToListAsync();
    }

    public async Task<IEnumerable<Employee>> SearchAll(Expression<Func<Employee, bool>> predicate)
    {
        return await _employees.Find(predicate).ToListAsync();
    }

    public async Task Delete(Employee entity)
    {
        await _employees.DeleteOneAsync(x => x.Id == entity.Id);
    }
}
