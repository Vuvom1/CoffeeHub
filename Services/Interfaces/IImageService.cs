using System;
using CoffeeHub.Models;

namespace CoffeeHub.Services.Interfaces;

public interface IImageService
{
    public Task<string> SaveImageAsync(IFormFile imageFile);
    public Task<string> UpdateImageAsync(IFormFile imageFile, string imageUrl);
    public Task<string> DeleteImageAsync(string imageUrl);
}
