using System;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;

namespace CoffeeHub.Repositories.Implementations;

public class InvoiceRepository : BaseRepository<Invoice>, IInvoiceRepository
{
    private new readonly CoffeeHubContext _context;
    public InvoiceRepository(CoffeeHubContext context) : base(context)
    {
        _context = context;
    }
}