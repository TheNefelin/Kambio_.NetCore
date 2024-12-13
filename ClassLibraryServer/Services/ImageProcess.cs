namespace ClassLibraryServer.Services
{
    public class ImageProcess
    {
        public async Task<bool> IsValidWebP(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return false;

            // Leer los primeros bytes del archivo
            using var stream = file.OpenReadStream();
            byte[] header = new byte[12];
            await stream.ReadAsync(header, 0, header.Length);

            // Validar la firma WebP
            string signature = System.Text.Encoding.ASCII.GetString(header, 0, 4); // "RIFF"
            string format = System.Text.Encoding.ASCII.GetString(header, 8, 4);   // "WEBP"

            return signature == "RIFF" && format == "WEBP";
        }
    }
}
