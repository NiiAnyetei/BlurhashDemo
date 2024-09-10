export interface ApiData {
  uploadedImages: UploadedImage[];
  uploadedImagesCount: number;
}

export interface UploadedImage {
  id: string;
  url: string;
  blurHash: string;
}
