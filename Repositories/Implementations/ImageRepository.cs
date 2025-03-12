using System;
using CoffeeHub.Repositories.Interfaces;
using Firebase.Storage;
using FirebaseAdmin.Auth;

namespace CoffeeHub.Repositories.Implementations;

public class ImageRepository : IImageRepository
{

    public ImageRepository()
    {
    }

    
    public async Task<string> SaveImageAsync(IFormFile imageFile)
    {
       var stream = imageFile.OpenReadStream();
            var fileName = Path.GetRandomFileName();

            var uid = Guid.NewGuid().ToString();
            var customToken = await FirebaseAuth.DefaultInstance.CreateCustomTokenAsync(uid);

            var storage = new FirebaseStorage(
                "martialartconnect.appspot.com",
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(customToken),
                    ThrowOnCancel = true
                });

            var task = storage
                .Child("images")
                .Child(fileName)
                .PutAsync(stream);

            var downloadUrl = await task;
            return downloadUrl;
    }

    public async Task<string> UpdateImageAsync(IFormFile imageFile, string imageUrl)
    {
        var uri = new Uri(imageUrl);
        var fileName = Path.GetFileName(uri.LocalPath);

        // Delete the existing image
        var storage = new FirebaseStorage(
            "martialartconnect.appspot.com",
            new FirebaseStorageOptions
            {
                AuthTokenAsyncFactory = async () => await FirebaseAuth.DefaultInstance.CreateCustomTokenAsync(Guid.NewGuid().ToString()),
                ThrowOnCancel = true
            });

        await storage
            .Child("images")
            .Child(fileName)
            .DeleteAsync();

        var stream = imageFile.OpenReadStream();
        var newTask = storage
            .Child("images")
            .Child(fileName)
            .PutAsync(stream);

        var newDownloadUrl = await newTask;
        return newDownloadUrl;
    }

    public Task<string> DeleteImageAsync(string imageUrl)
    {
        throw new NotImplementedException();
    }

}
