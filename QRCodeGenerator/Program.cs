using System;
using System.Drawing;
using QRCoder;
using System.Drawing.Imaging;
namespace MyQRCodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: convert this into a winform and urlString as an output. 
            var urlString = "https://www.instagram.com/not_a_sirius_baker/"; 
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(urlString, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(5); // pixels per module
            ImageCodecInfo imageCodecInfo = GetEncoderInfo("image/jpeg");
            Encoder myEncoder = Encoder.Quality;
            // EncoderParameter object in the array.
            EncoderParameters myEncoderParameters = new EncoderParameters(1);

            // Save the bitmap as a JPEG file with quality level 25.
            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 25L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            qrCodeImage.Save(@"C:\Workspace\2022\Shapes025.jpg", imageCodecInfo, myEncoderParameters);
        }

        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
    }
}
