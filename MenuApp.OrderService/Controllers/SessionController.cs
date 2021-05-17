using System;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using MenuApp.OrderService.Logic.Entities;
using MenuApp.OrderService.Logic.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;
using QRCoder;

namespace MenuApp.OrderService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController : Controller
    {
        private readonly ISessionRepository _sessionRepository;
        public SessionController(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Session session)
        {
            return Ok(await _sessionRepository.Create(session));
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _sessionRepository.Get(id));
        }

        [HttpGet("GetQR/{sessionId}")]
        // ReSharper disable once InconsistentNaming
        public async Task<IActionResult> GetQR(Guid sessionId)
        {
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode("https://menu.tycho.dev/" + sessionId, QRCodeGenerator.ECCLevel.H);
            var qrCode = new QRCode(qrCodeData);
            var qrCodeImage = qrCode.GetGraphic(20);

            MemoryStream stream = new MemoryStream();
            qrCodeImage.Save(stream, ImageFormat.Png);
            byte[] result = null;
            result = stream.ToArray();
            
            return File(result,"image/png" );
        }
    }
}