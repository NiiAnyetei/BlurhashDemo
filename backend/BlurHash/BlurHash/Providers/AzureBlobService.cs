using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System.Reflection.Metadata;

namespace BlurHash.Providers
{
    public class AzureBlobService
    {
        private readonly IConfiguration Configuration;
        BlobServiceClient _blobClient;
        BlobContainerClient _containerClient;

        public AzureBlobService(IConfiguration configuration)
        {
            Configuration = configuration;
            _blobClient = new BlobServiceClient(Configuration["BlobConnectionString"]);
            _containerClient = _blobClient.GetBlobContainerClient("blurhash");
        }

        public async Task<List<Azure.Response<BlobContentInfo>>> UploadFiles(List<IFormFile> files)
        {

            var azureResponse = new List<Azure.Response<BlobContentInfo>>();
            foreach (var file in files)
            {
                string fileName = file.FileName;
                using (var memoryStream = new MemoryStream())
                {
                    file.CopyTo(memoryStream);
                    memoryStream.Position = 0;
                    var client = await _containerClient.UploadBlobAsync(fileName, memoryStream, default);
                    azureResponse.Add(client);
                }
            };

            return azureResponse;
        }

        public async Task<List<BlobItem>> GetUploadedBlobs()
        {
            var items = new List<BlobItem>();
            var uploadedFiles = _containerClient.GetBlobsAsync();
            await foreach (BlobItem file in uploadedFiles)
            {
                items.Add(file);
            }

            return items;
        }

        public string GetUri(string filename)
        {
            var blobUri = $"{_containerClient.Uri.AbsoluteUri}/{filename}";
            return blobUri;
        }
    }
}
