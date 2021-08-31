using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetStreams.Commerce.Example.Configuration
{
    public class StreamConfiguration
    {
        public string BootstrapServers { get; set; }
        public string ConsumerGroup { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string SecurityProtocol { get; set; }
        public string SslCertificateLocation { get; set; }
        public string SslCaLocation { get; set; }
        public string SslKeyLocation { get; set; }
        public string SslKeyPassword { get; set; }

        public string AutoOffsetReset { get; set; } = "Latest";
    }
}
