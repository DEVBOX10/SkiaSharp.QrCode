using SkiaSharp;
using SkiaSharp.QrCode.Image;
using System;
using System.IO;

namespace NanoServerGenerate
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine($"Usage: dotnet {nameof(NanoServerGenerate)}.dll your_message output_path");
                return;
            }
            var content = args[0];
            var path = args[1];

            // generate qr code
            var qrCode = new QrCode(content, new Vector2Slim(256, 256), SKEncodedImageFormat.Png);
            using (var output = new FileStream(path, FileMode.OpenOrCreate))
            {
                qrCode.GenerateImage(output);
            }

            Console.WriteLine($"Successfully output QRCode in {path}");
        }
    }
}
