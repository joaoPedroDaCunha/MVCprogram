using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Programa.Data;

public class ConnectionContext(DbContextOptions<ConnectionContext> options) : DbContext(options)
{
    public DbSet<Dependants> Dependants{get;set;}
    public DbSet<Employee> Employees{get;set;}
}