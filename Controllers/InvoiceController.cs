using System;
using CoffeeHub.Models.Domains;
using CoffeeHub.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeHub.Controllers;

public class InvoiceController : ControllerBase
{
    private readonly IInvoiceService _invoiceService;

    public InvoiceController(IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var invoices = await _invoiceService.GetAllAsync();
        return Ok(invoices);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var invoice = await _invoiceService.GetByIdAsync(id);
        if (invoice == null)
        {
            return NotFound();
        }
        return Ok(invoice);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Invoice invoice)
    {
        await _invoiceService.AddAsync(invoice);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Invoice invoice)
    {
        var existingInvoice = await _invoiceService.GetByIdAsync(id);
        if (existingInvoice == null)
        {
            return NotFound();
        }
        await _invoiceService.UpdateAsync(invoice);
        return Ok();
    }

}
