namespace BlurHash.Models.Dtos;

public record UploadedImageResponseDto(string Url, string BlurHash);
public record UploadedImagesResponseDto(List<UploadedImage> UploadedImages, int UploadedImagesCount);
public record UploadedImageQuery(int Limit = 20, int Offset = 0);
