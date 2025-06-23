using System;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;
using CoffeeHub.Services.Interfaces;

namespace CoffeeHub.Services.Implementations;

public class TableService : BaseService<Table>, ITableService
{
    private readonly ITableRepository _tableRepository;
    public TableService(ITableRepository tableRepository) : base(tableRepository)
    {
        _tableRepository = tableRepository;
    }
}
