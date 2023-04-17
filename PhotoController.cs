using Data.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Müvekkil_.Controllers
{
   
    [ApiController]
    [Route("[controller]")]
    public class PhotosController : ControllerBase
    {
        private readonly IMongoCollection<Photo> _photos;

        public PhotosController(IMongoClient client)
        {
            var database = client.GetDatabase("yourDatabaseName");
            _photos = database.GetCollection<Photo>("photos");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PhotoDto>> GetPhotoUrl(string id)
        {
            var photoObjectId = new ObjectId(id);
            var photo = await _photos.Find(p => p.Id == photoObjectId).FirstOrDefaultAsync();

            if (photo == null)
            {
                return NotFound();
            }

            var photoDto = new PhotoDto
            {
                Url = photo.Url
            };

            return photoDto;
        }
        
    }
}
