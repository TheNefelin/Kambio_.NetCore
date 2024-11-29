using SkiaSharp;
using static System.Net.Mime.MediaTypeNames;

namespace ClassLibraryClient.Utills
{
    public class ImageConverter
    {
        public static byte[] ConvertToWebP(string inputPath, int quality = 75)
        {
            using var imageStream = File.OpenRead(inputPath);
            using var bitmap = SKBitmap.Decode(imageStream);
            using var image = SKImage.FromBitmap(bitmap);
            using var data = image.Encode(SKEncodedImageFormat.Webp, quality);

            return data.ToArray();
        }

        public static void SaveAsWebP(string inputPath, string outputPath, int quality = 75)
        {
            var webpData = ConvertToWebP(inputPath, quality);

            File.WriteAllBytes(outputPath, webpData);
        }
    }
}
