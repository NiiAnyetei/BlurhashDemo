namespace BlurHash.Models
{
    public class UploadedImage(string url, string blurHash)
    {
        public Guid Id { get; set; }
        public string Url { get; set; } = url;
        public string BlurHash { get; set; } = blurHash;
    }
}
