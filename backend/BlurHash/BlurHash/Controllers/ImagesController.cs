using Blurhash.ImageSharp;
using BlurHash.Models;
using BlurHash.Models.Dtos;
using BlurHash.Providers;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlurHash.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly AzureBlobService _blobService;
        private readonly ImageService _imageService;

        public ImagesController(AzureBlobService blobService, ImageService imageService)
        {
            _blobService = blobService;
            _imageService = imageService;
        }

        // GET: api/<ImagesController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] UploadedImageQuery query)
        {
            try
            {
                var images = await _imageService.GetAsync(query);
                return Ok(images);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        // POST api/<ImagesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] FileUpload upload)
        {
            try
            {
                if (upload.files == null) throw new ArgumentNullException("files");

                var result = await _blobService.UploadFiles(upload.files);

                for (var i = 0; i < result.Count; i++)
                {
                    var response = result[i].GetRawResponse();
                    if (response.IsError) throw new Exception(response.ReasonPhrase);

                    var uri = _blobService.GetUri(upload.files[i].FileName);
                    var pixelImage = Image.Load<Rgba32>(upload.files[i].OpenReadStream());
                    var hash = Blurhasher.Encode(pixelImage, 3, 3);
                    var image = new UploadedImage(uri, hash);
                    await _imageService.CreateAsync(image);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
    }
}
