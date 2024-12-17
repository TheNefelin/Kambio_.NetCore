using SkiaSharp;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace ClassLibraryModels.Services
{
    public class ImageProcess
    {
        private const int _quality = 75;
        private const int _targetWidth = 800;
        private const int _targetHeight = 600;

        public static byte[] ConvertToWebP(string inputPath, int quality = _quality)
        {
            using var imageStream = File.OpenRead(inputPath);
            using var bitmap = SKBitmap.Decode(imageStream);
            using var image = SKImage.FromBitmap(bitmap);
            using var data = image.Encode(SKEncodedImageFormat.Webp, quality);

            return data.ToArray();
        }

        public async Task SaveFileAsync(Stream fileStream, string filePath)
        {
            // Guarda el archivo en el sistema de archivos
            using var fileOutputStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            await fileStream.CopyToAsync(fileOutputStream);
        }

        public void SaveAsWebP(string inputPath, string outputPath, int quality = _quality)
        {
            var webpData = ConvertToWebP(inputPath, quality);
            File.WriteAllBytes(outputPath, webpData);
        }
             
        public void ConvertAndSaveToWebP(Stream imageStream, string savePath, string fileName, int quality = _quality, int targetWidth = _targetWidth, int targetHeight = _targetHeight)
        {
            savePath = Path.Combine(savePath, Path.GetFileNameWithoutExtension(fileName) + ".webp");

            using var bitmap = SKBitmap.Decode(imageStream);

            float originalAspectRatio = (float)bitmap.Width / bitmap.Height;
            float targetAspectRatio = (float)targetWidth / targetHeight;
            int cropX, cropY, cropWidth, cropHeight;

            if (originalAspectRatio > targetAspectRatio)
            {
                cropWidth = (int)(bitmap.Height * targetAspectRatio);
                cropHeight = bitmap.Height;
                cropX = (bitmap.Width - cropWidth) / 2;
                cropY = 0;
            }
            else if (originalAspectRatio < targetAspectRatio)
            {
                cropWidth = bitmap.Width;
                cropHeight = (int)(bitmap.Width / targetAspectRatio);
                cropX = 0;
                cropY = (bitmap.Height - cropHeight) / 2;
            }
            else
            {
                cropWidth = targetWidth;
                cropHeight = targetHeight;
                cropX = 0;
                cropY = 0;
            }

            using var croppedBitmap = new SKBitmap(cropWidth, cropHeight);

            using (var canvas = new SKCanvas(croppedBitmap))
            {
                var srcRect = new SKRect(cropX, cropY, cropX + cropWidth, cropY + cropHeight);
                var destRect = new SKRect(0, 0, cropWidth, cropHeight);
                canvas.DrawBitmap(bitmap, srcRect, destRect);
            }

            using var resizedBitmap = croppedBitmap.Resize(new SKImageInfo(targetWidth, targetHeight), SKFilterQuality.High);

            //using var image = SKImage.FromBitmap(bitmap);
            using var image = SKImage.FromBitmap(resizedBitmap);
            using var dataWebP = image.Encode(SKEncodedImageFormat.Webp, quality);
            using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
                dataWebP.SaveTo(fileStream);
            }
        }

        public static byte[] ToWebpAndResize(string inputPath, int quality = _quality, int targetWidth = _targetWidth, int targetHeight = _targetHeight)
        {
            using var imageStream = File.OpenRead(inputPath);
            using var bitmap = SKBitmap.Decode(imageStream);

            float originalAspectRatio = (float)bitmap.Width / bitmap.Height;
            float targetAspectRatio = (float)targetWidth / targetHeight;
            int cropX, cropY, cropWidth, cropHeight;

            if (originalAspectRatio > targetAspectRatio)
            {
                cropWidth = (int)(bitmap.Height * targetAspectRatio);
                cropHeight = bitmap.Height;
                cropX = (bitmap.Width - cropWidth) / 2;
                cropY = 0;
            }
            else if (originalAspectRatio < targetAspectRatio)
            {
                cropWidth = bitmap.Width;
                cropHeight = (int)(bitmap.Width / targetAspectRatio);
                cropX = 0;
                cropY = (bitmap.Height - cropHeight) / 2;
            }
            else
            {
                cropWidth = targetWidth;
                cropHeight = targetHeight;
                cropX = 0;
                cropY = 0;
            }

            using var croppedBitmap = new SKBitmap(cropWidth, cropHeight);

            using (var canvas = new SKCanvas(croppedBitmap))
            {
                var srcRect = new SKRect(cropX, cropY, cropX + cropWidth, cropY + cropHeight);
                var destRect = new SKRect(0, 0, cropWidth, cropHeight);
                canvas.DrawBitmap(bitmap, srcRect, destRect);
            }

            using var resizedBitmap = croppedBitmap.Resize(new SKImageInfo(targetWidth, targetHeight), SKFilterQuality.High);
            using var image = SKImage.FromBitmap(resizedBitmap);
            using var dataWebP = image.Encode(SKEncodedImageFormat.Webp, quality);

            return dataWebP.ToArray();
        }

        public bool IsJpeg(Stream imageStream)
        {
            byte[] buffer = new byte[8];
            imageStream.Read(buffer, 0, buffer.Length);

            // JPEG header bytes: FF D8
            return buffer.Length >= 2 && 
                   buffer[0] == 0xFF && 
                   buffer[1] == 0xD8;
        }

        public bool IsPng(Stream imageStream)
        {
            byte[] buffer = new byte[8];
            imageStream.Read(buffer, 0, buffer.Length);

            // PNG header bytes: 89 50 4E 47 0D 0A 1A 0A
            return buffer.Length >= 8 && 
                   buffer[0] == 0x89 &&
                   buffer[1] == 0x50 &&
                   buffer[2] == 0x4E &&
                   buffer[3] == 0x47 &&
                   buffer[4] == 0x0D &&
                   buffer[5] == 0x0A &&
                   buffer[6] == 0x1A &&
                   buffer[7] == 0x0A;
        }

        public bool IsWebp(Stream imageStream)
        {
            byte[] buffer = new byte[12];
            imageStream.Read(buffer, 0, buffer.Length);

            // WebP header bytes: RIFF (0x52 0x49 0x46 0x46) + WEBP (0x57 0x45 0x42 0x50)
            return buffer.Length >= 12 && 
                   buffer[0] == 0x52 &&
                   buffer[1] == 0x49 &&
                   buffer[2] == 0x46 &&
                   buffer[3] == 0x46 &&
                   buffer[8] == 0x57 &&
                   buffer[9] == 0x45 &&
                   buffer[10] == 0x42 &&
                   buffer[11] == 0x50;
        }
    }
}
