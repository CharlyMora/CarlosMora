using System;

namespace CarlosMora.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public string hola ="hola";

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
