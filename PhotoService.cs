using Business.Interfaces;
using Data.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Business.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IMongoCollection<Photo> _photos; 

        public PhotoService(IMongoClient client)
        {
            var database = client.GetDatabase("yourDatabaseName");
            _photos = database.GetCollection<Photo>("photos");
        }

        public async Task<PhotoDto> GetPhotoUrl(string id)
        {
            var photoObjectId = new ObjectId(id);
            var photo = await _photos.Find(p => p.Id == photoObjectId).FirstOrDefaultAsync();

            if (photo == null)
            {
                return null;
            }

            var photoDto = new PhotoDto
            {
                Url = photo.Url
            };

            return photoDto;
        }
        private async Task<string> ConvertToBase64(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var imageBytes = await httpClient.GetByteArrayAsync(url);
                var base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

      

        public Task<string> AddPhotoAsync(string url)
        {
            throw new NotImplementedException();
        }

       
    }
}
