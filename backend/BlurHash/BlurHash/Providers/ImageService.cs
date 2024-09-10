using BlurHash.Context;
using BlurHash.Models;
using BlurHash.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BlurHash.Providers
{
    public class ImageService
    {
        private readonly ApplicationDbContext _context;

        public ImageService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UploadedImageResponseDto> CreateAsync(UploadedImage image)
        {
            await _context.UploadedImages.AddAsync(image);
            await _context.SaveChangesAsync();
            return new UploadedImageResponseDto(image.Url, image.BlurHash); ;
        }

        public async Task<UploadedImagesResponseDto> GetAsync(UploadedImageQuery query)
        {
            var uploadedImages = _context.UploadedImages.Select(x => x);

            if (uploadedImages == null) throw new Exception("No records found");

            var total = await uploadedImages.CountAsync();
            var pageQuery = uploadedImages.Skip(query.Offset).Take(query.Limit).AsNoTracking();
            var page = await pageQuery.ToListAsync();
            return new UploadedImagesResponseDto(page, total);
        }
    }
}
