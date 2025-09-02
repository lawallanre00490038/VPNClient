namespace VpnClient.Models
{
    public class VpnNode
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public int Latency_ms { get; set; }
        public string Public_key { get; set; }
        public string Endpoint_ip { get; set; }
    }
}

