using System;

namespace CoffeeHub.Repositories.Interfaces;

public interface IImageRepository
{
    public Task<string> SaveImageAsync(IFormFile imageFile);
    public Task<string> UpdateImageAsync(IFormFile imageFile, string imageUrl);
    public Task<string> DeleteImageAsync(string imageUrl);  
}
