using System;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;

namespace CoffeeHub.Repositories.Implementations;

public class TableRepository : BaseRepository<Table>, ITableRepository
{
    private new readonly CoffeeHubContext _context;

    public TableRepository(CoffeeHubContext context) : base(context)
    {
        _context = context;
    }
}   
