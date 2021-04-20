using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using QRCoder;

namespace MenuApp.OrderService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QrCodeController: ControllerBase
    {
        [HttpGet("{table}")]
        public IActionResult Get(int table)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("https://menu.tycho.dev/" + table, QRCodeGenerator.ECCLevel.H);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            MemoryStream stream = new MemoryStream();
            qrCodeImage.Save(stream, ImageFormat.Png);
            byte[] result = null;
            result = stream.ToArray();
            
            return File(result,"image/jpeg" );
        }
    }
}