

using Microsoft.AspNetCore.Http;

namespace Shared.Utils.Helper
{
    public static class ImageHelper
    {
        public static byte[]? ImageToByteArray(IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0) return null;

            using var imageStream = imageFile.OpenReadStream();
            using var image = System.Drawing.Image.FromStream(imageStream);

            if (image == null) return null;

            using var stream = new MemoryStream();
            image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            return stream.ToArray();
        }

        public static System.Drawing.Image ByteArrayToImage(byte[] byteArray)
        {
            using var stream = new MemoryStream(byteArray);

            return System.Drawing.Image.FromStream(stream);
        }
    }
}
