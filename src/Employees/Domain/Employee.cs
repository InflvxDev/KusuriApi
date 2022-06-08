using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace Kusuri.Employees.Domain;

public class Employee
{
    [Key, BsonId]
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public int Age { get; set; }
    public string Email { get; set; } = default!;
    public string Phone { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string JobID { get; set; } = default!;
    public string Salary { get; set; } = default!;

    public Employee()
    {
    }

}
