using SGPdotNET.CoordinateSystem;
using SGPdotNET.Observation;
using SGPdotNET.Util;

namespace Shared
{
    public static class SatelliteCoordinates
    {
        public static Coordinates? CalculateSatelliteCoordinates(string tle, DateTime time, double _longitude, double _latitude)
        {
            try
            {
                // Split the TLE into its three lines
                var tleLines = tle.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);


                // Create a satellite from the TLEs
                Satellite sat;
                if (tleLines.Length == 2)
                {
                    sat = new Satellite(tleLines[0], tleLines[1]);
                }
                else if (tleLines.Length == 3)
                {
                    sat = new Satellite(tleLines[0], tleLines[1], tleLines[2]);
                }
                else
                {
                    return null;
                }

                // Set up our ground station location
                var location = new GeodeticCoordinate(Angle.FromDegrees(_latitude), Angle.FromDegrees(_longitude), 0);

                // Create a ground station
                var groundStation = new GroundStation(location);

                // Observe the satellite
                var observation = groundStation.Observe(sat, time);

                return new Coordinates
                {
                    azimuth = observation.Azimuth.Degrees,
                    altitude = observation.Elevation.Degrees,
                    distance = observation.Range
                };
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
