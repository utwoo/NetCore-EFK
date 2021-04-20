using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using efk_demo.models;
using Newtonsoft.Json;

namespace efk_demo
{
    public class FluentSender
    {
        private readonly UdpClient _udpClient;

        public FluentSender()
        {
            _udpClient = new UdpClient();
        }
        
        public bool SendEvent(string message)
        {
            var eventInfo = new EventInfo() {Message = message, Timestamp = DateTime.Now};
            var objEventInfo = JsonConvert.SerializeObject(eventInfo);
            var logBytes = Encoding.UTF8.GetBytes(objEventInfo);
            var ipEndpoint = new IPEndPoint(IPAddress.Parse("192.168.20.151"), 9880);
            
            var result =_udpClient.Send(logBytes, logBytes.Length, ipEndpoint);
            Console.WriteLine($"Send event successful: ${objEventInfo}");
            return true;
        }
    }
}