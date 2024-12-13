namespace ClassLibraryModels.DTOs
{
    public class ImageDTO
    {
        public string FileName { get; set; } = string.Empty; 
        public byte[] Data { get; set; } = Array.Empty<byte>(); 
        public string ContentType { get; set; } = "image/webp";
    }
}
