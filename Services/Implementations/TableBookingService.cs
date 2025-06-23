using System;
using System.Text;
using System.Threading.Tasks;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;
using CoffeeHub.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace CoffeeHub.Services.Implementations;

public class TableBookingService : BaseService<TableBooking>, ITableBookingService
{
    private readonly ITableBookingRepository _tableBookingRepository;
    private readonly IEmailService _emailService;
    private readonly ILogger<TableBookingService> _logger;

    public TableBookingService(
        ITableBookingRepository tableBookingRepository,
        IEmailService emailService,
        ILogger<TableBookingService> logger) : base(tableBookingRepository)
    {
        _tableBookingRepository = tableBookingRepository;
        _emailService = emailService;
        _logger = logger;
    }

    public override async Task AddAsync(TableBooking entity)
    {
        // First save the booking to ensure it has an ID
        await base.AddAsync(entity);

        // Create HTML email with responsive design
        string emailSubject = "Your Table Reservation Confirmation - CoffeeHub";
        string emailHtml = GenerateBookingConfirmationEmail(entity);

        // Send the HTML email
        await _emailService.SendEmailAsync(entity.CustomerEmail, emailSubject, emailHtml);
    }

    private string GenerateBookingConfirmationEmail(TableBooking booking)
    {
        // Format the date and time for better readability
        string formattedDate = booking.BookingDate.ToString("dddd, MMMM d, yyyy");
        string formattedTime = booking.BookingDate.ToString("h:mm tt");

        StringBuilder html = new StringBuilder();
        html.Append(@"
<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Booking Confirmation</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            line-height: 1.6;
            color: #333;
            margin: 0;
            padding: 0;
        }
        .container {
            max-width: 600px;
            margin: 0 auto;
            padding: 20px;
        }
        .header {
            background-color: #6F4E37; /* Coffee brown */
            color: white;
            padding: 20px;
            text-align: center;
            border-radius: 5px 5px 0 0;
        }
        .content {
            background-color: #F9F5F0; /* Light cream */
            padding: 30px;
            border-radius: 0 0 5px 5px;
            border-left: 1px solid #E8E0D5;
            border-right: 1px solid #E8E0D5;
            border-bottom: 1px solid #E8E0D5;
        }
        .footer {
            text-align: center;
            margin-top: 20px;
            font-size: 12px;
            color: #777;
        }
        .booking-details {
            background-color: white;
            padding: 15px;
            border-radius: 4px;
            margin: 20px 0;
            border-left: 4px solid #6F4E37;
        }
        .detail-row {
            margin-bottom: 10px;
        }
        .detail-label {
            font-weight: bold;
            display: inline-block;
            width: 140px;
        }
        .detail-value {
            display: inline-block;
        }
        .button {
            display: inline-block;
            background-color: #6F4E37;
            color: white;
            text-decoration: none;
            padding: 10px 20px;
            border-radius: 4px;
            margin-top: 15px;
        }
        @media only screen and (max-width: 620px) {
            .container {
                width: 100% !important;
            }
            .detail-label, .detail-value {
                display: block;
                width: 100%;
            }
        }
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>Table Reservation Confirmed</h1>
        </div>
        <div class='content'>
            <p>Dear " + booking.CustomerName + @",</p>
            
            <p>Thank you for your reservation at CoffeeHub. We're excited to have you join us!</p>
            
            <div class='booking-details'>
                <div class='detail-row'>
                    <span class='detail-label'>Booking ID:</span>
                    <span class='detail-value'>" + booking.Id + @"</span>
                </div>
                <div class='detail-row'>
                    <span class='detail-label'>Date:</span>
                    <span class='detail-value'>" + formattedDate + @"</span>
                </div>
                <div class='detail-row'>
                    <span class='detail-label'>Time:</span>
                    <span class='detail-value'>" + formattedTime + @"</span>
                </div>
                <div class='detail-row'>
                    <span class='detail-label'>Number of Guests:</span>
                    <span class='detail-value'>" + booking.NumberOfGuests + @"</span>
                </div>");

        if (!string.IsNullOrEmpty(booking.Notes))
        {
            html.Append(@"
                <div class='detail-row'>
                    <span class='detail-label'>Special Notes:</span>
                    <span class='detail-value'>" + booking.Notes + @"</span>
                </div>");
        }

        if (booking.TableId.HasValue)
        {
            html.Append(@"
                <div class='detail-row'>
                    <span class='detail-label'>Table:</span>
                    <span class='detail-value'>Table #" + booking.TableId + @"</span>
                </div>");
        }

        html.Append(@"
            </div>
            
            <p>Your table will be held for 15 minutes past your reservation time. If you need to modify or cancel your reservation, please call us at (123) 456-7890 or reply to this email.</p>
            
            <p>We look forward to serving you!</p>
            
            <a href='https://coffeehub-b2angrfyasfuh7hk.southeastasia-01.azurewebsites.net/booking/manage/" + booking.Id + @"' class='button'>Manage Your Reservation</a>
        </div>
        <div class='footer'>
            <p>© " + DateTime.Now.Year + @" CoffeeHub. All rights reserved.</p>
            <p>123 Coffee Street, Coffee City | (123) 456-7890</p>
            <p>This is an automated message, please do not reply directly to this email.</p>
        </div>
    </div>
</body>
</html>");

        return html.ToString();
    }
}
