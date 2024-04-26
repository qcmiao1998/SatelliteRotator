using System.Net.Sockets;

namespace Shared
{
    public class Rotctld : IDisposable
    {
        private TcpClient client = new TcpClient();
        private StreamReader? sr;
        private StreamWriter? sw;

        public Rotctld(string address)
        {
            string[] parts = address.Split(':', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (parts.Length != 2)
            {
                throw new ArgumentException("Address must be in the format 'address:port'");
            }
            Connect(parts[0], int.Parse(parts[1]));
        }
        public Rotctld(string address, int port)
        {
            Connect(address, port);
        }

        private void Connect(string address, int port)
        {
            client.Connect(address, port);
            sr = new StreamReader(client.GetStream());
            sw = new StreamWriter(client.GetStream());
        }

        public void SetPosition(double azimuth, double elevation)
        {
            var command = $"P {azimuth:F3} {elevation:F3}";
            sr?.DiscardBufferedData();
            sw?.WriteLine(command);
            sw?.Flush();
            Thread.Sleep(10);
            _ = sr?.ReadLine();
        }

        public Coordinates? GetPosition()
        {
            sr?.DiscardBufferedData();
            var command = "p";
            sw?.WriteLine(command);
            sw?.Flush();
            Thread.Sleep(10);
            var az = sr?.ReadLine();
            var el = sr?.ReadLine();

            if (az is null || el is null)
            {
                return null;
            }
            return new Coordinates
            {
                azimuth = double.Parse(az),
                altitude = double.Parse(el)
            };
        }

        public void Dispose()
        {
            client?.Dispose();
            sr?.Dispose();
            sw?.Dispose();
        }
    }
}
