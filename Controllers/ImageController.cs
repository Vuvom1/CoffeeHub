using CoffeeHub.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost]
        public async Task<IActionResult> SaveImage(IFormFile imageFile)
        {
            var imageUrl = await _imageService.SaveImageAsync(imageFile);
            return Ok(imageUrl);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateImage(IFormFile imageFile, string imageUrl)
        {
            var updatedImageUrl = await _imageService.UpdateImageAsync(imageFile, imageUrl);
            return Ok(updatedImageUrl);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteImage(string imageUrl)
        {
            await _imageService.DeleteImageAsync(imageUrl);
            return Ok();
        }
    }
}
