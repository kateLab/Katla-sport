using System.Threading.Tasks;

namespace KatlaSport.Services.ImageManagement
{
    public interface IImageService
    {
        Task DeleteAsync(string imagePath);

        Task<ImageResult> AddAsync(ImageData imageData, string oldPath);
    }
}
