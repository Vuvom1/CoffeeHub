using System;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoffeeHub.Repositories.Implementations;

public class TableBookingRepository : BaseRepository<TableBooking>, ITableBookingRepository
{
    private new readonly CoffeeHubContext _context;

    public TableBookingRepository(CoffeeHubContext context) : base(context)
    {
        _context = context;
    }

    public async override Task<TableBooking> GetByIdAsync(Guid id)
    {
        var booking = await _context.TableBookings
            .Include(t => t.Table)
            .FirstOrDefaultAsync(t => t.Id == id);
            
        if (booking == null)
            throw new InvalidOperationException($"TableBooking with id {id} not found");
            
        return booking;
    }
}
