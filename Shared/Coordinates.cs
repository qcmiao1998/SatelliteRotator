namespace Shared
{
    public class Coordinates
    {
        public double azimuth { get; set;}
        public double altitude { get; set; }
        public double distance { get; set; }

        public double zenith { get { return 90 - altitude; } } // not sure about this one

        public string ToString(bool dis = true)
        {
            if (dis)
            {
                return $"Azimuth: {azimuth:F3}° Altitude: {altitude:F3}° Distance: {distance:F3}";
            }
            else
            {
                return $"Azimuth: {azimuth:F3}° Altitude: {altitude:F3}°";
            }
        }
        public override string ToString()
        {
            return ToString(true);
        }
    }
}
