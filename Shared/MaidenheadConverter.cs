using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Shared
{
    public static class MaidenheadConverter
    {
        public class GeoCoordinate
        {
            public GeoCoordinate(double latitude, double longitude)
            {
                Latitude = latitude;
                Longitude = longitude;
            }

            public double Latitude { get; set; }
            public double Longitude { get; set; }

            public override string ToString()
            {
                return $"Latitude: {Latitude}  Longitude: {Longitude}";
            }
        }
        public static GeoCoordinate Convert(string locator)
        {
            if (locator is null)
            {
                throw new ArgumentNullException(nameof(locator));
            }

            if (!IsValid(locator))
            {
                throw new ArgumentException(nameof(locator));
            }

            var c = new GeoCoordinate(-90, -180);

            var divisor = 1d;

            var cnt = 0;

            foreach (var pair in Split(locator.ToUpperInvariant()))
            {
                cnt++;

                var isLetter = true;

                if (cnt == 1)
                {
                    divisor *= 18;
                }
                else if (cnt % 2 == 0)
                {
                    divisor *= 10;
                    isLetter = false;
                }
                else
                {
                    divisor *= 24;
                }

                int longValue = pair[0] - (isLetter ? 'A' : '0');
                int latValue = pair[1] - (isLetter ? 'A' : '0');

                var longPart = (360d * longValue) / divisor;
                var latPart = (180d * latValue) / divisor;

                c.Longitude += longPart;
                c.Latitude += latPart;
            }

            return c;
        }

        public static bool IsValid(string locator)
        {
            try
            {
                var _ = Split(locator.ToUpperInvariant()).ToList();             
            }
            catch {
                return false;
            }

            return true;
        }

        private static IEnumerable<string> Split(string locator)
        {
            if (locator is null)
            {
                throw new ArgumentNullException(nameof(locator));
            }

            if (string.IsNullOrEmpty(locator) || locator.Length % 2 != 0)
            {
                throw new ArgumentException("Length must be >0 and even.", nameof(locator));
            }

            return Enumerable.Range(0, locator.Length / 2).Select(i => locator.Substring(i * 2, 2)).Select((p, i) =>
            {
                if (i == 0)
                {
                    if (!Regex.IsMatch(p, @"^[A-R]{2}$"))
                    {
                        throw new ArgumentOutOfRangeException(nameof(locator));
                    }
                }
                else if (i % 2 != 0)
                {
                    if (!Regex.IsMatch(p, @"^[0-9]{2}$"))
                    {
                        throw new ArgumentOutOfRangeException(nameof(locator));
                    }
                }
                else
                {
                    if (!Regex.IsMatch(p, @"^[A-X]{2}$"))
                    {
                        throw new ArgumentOutOfRangeException(nameof(locator));
                    }
                }

                return p;
            });
        }
    }
}
