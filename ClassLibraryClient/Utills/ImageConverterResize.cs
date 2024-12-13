using SkiaSharp;

namespace ClassLibraryClient.Utills
{
    public class ImageConverterResize
    {
        public static byte[] ConvertToWebP(string inputPath, int quality = 75, int canvasWidth = 800, int canvasHeight = 600)
        {
            using var imageStream = File.OpenRead(inputPath);
            using var bitmap = SKBitmap.Decode(imageStream);

            var resizedBitmap = bitmap.Resize(
                new SKImageInfo(canvasWidth, canvasHeight),
                SKFilterQuality.High
            );

            if (resizedBitmap == null)
                throw new InvalidOperationException("Error al redimensionar la imagen.");

            //int cropX = (resizedBitmap.Width - canvasWidth) / 2;
            //int cropY = (resizedBitmap.Height - canvasHeight) / 2;

            //var croppedBitmap = new SKBitmap(canvasWidth, canvasHeight);
            //resizedBitmap.ExtractSubset(croppedBitmap, new SKRectI(cropX, cropY, cropX + canvasWidth, cropY + canvasHeight));

            //using var image = SKImage.FromBitmap(croppedBitmap);
            using var image = SKImage.FromBitmap(resizedBitmap);
            using var data = image.Encode(SKEncodedImageFormat.Webp, quality);

            return data.ToArray();
        }
    }
}
