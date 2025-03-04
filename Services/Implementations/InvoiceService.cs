using System;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;
using CoffeeHub.Services.Interfaces;

namespace CoffeeHub.Services.Implementations;

public class InvoiceService : BaseService<Invoice>, IInvoiceService
{
    private readonly IInvoiceRepository _invoiceRepository;
    public InvoiceService(IInvoiceRepository invoiceRepository ) : base(invoiceRepository)
    {
        _invoiceRepository = invoiceRepository;
    }
}
