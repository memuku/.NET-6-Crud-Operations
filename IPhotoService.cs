using Data.Models;

namespace Business.Interfaces
{
    public interface IPhotoService
    {
        Task<PhotoDto> GetPhotoUrl(string id);
        Task<string> AddPhotoAsync(string url);
       
    }
}
