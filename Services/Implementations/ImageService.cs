using System;
using CoffeeHub.Repositories.Interfaces;
using CoffeeHub.Services.Interfaces;

namespace CoffeeHub.Services.Implementations;

public class ImageService : IImageService
{
    private readonly IImageRepository _imageRepository;

    public ImageService(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }
    public Task<string> SaveImageAsync(IFormFile imageFile)
    {
        return _imageRepository.SaveImageAsync(imageFile);
    }

    public Task<string> UpdateImageAsync(IFormFile imageFile, string imageUrl)
    {
        return _imageRepository.UpdateImageAsync(imageFile, imageUrl);
    }

    public Task<string> DeleteImageAsync(string imageUrl)
    {
        return _imageRepository.DeleteImageAsync(imageUrl);
    }
}
