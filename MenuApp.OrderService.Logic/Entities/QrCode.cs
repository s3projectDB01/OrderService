using System;
using System.Net.Mime;

namespace MenuApp.OrderService.Logic.Entities
{
    public class QrCode
    {
        public Guid Id { get; set; }
        public string QrText { get; set; }
        
    }
}