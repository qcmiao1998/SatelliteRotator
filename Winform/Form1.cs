using Shared;
using Timer = System.Timers.Timer;

namespace Winform
{
    public partial class Form1 : Form
    {
        MaidenheadConverter.GeoCoordinate? _geoCoordinate = null;
        Coordinates? targetpos = null;
        Coordinates? currentpos = null;
        Timer timerCal;
        Timer timerRot;
        Rotctld? rotctld;
        bool connected = false;

        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;

            comboBoxPlanet.Items.Add("Moon");
            comboBoxPlanet.Items.AddRange(Enum.GetNames(typeof(CelestialCoordinates.Planets)));
            comboBoxPlanet.SelectedIndex = 0;

            timerCal = new Timer(1000);
            timerCal.Elapsed += CalculateDirection;
            timerCal.AutoReset = true;
            timerCal.Start();

            timerRot = new Timer(1000);
            timerRot.Elapsed += SendRotatorCommand;
            timerRot.AutoReset = true;
        }

        private void CalculateDirection(object? sender, System.Timers.ElapsedEventArgs e)
        {
            var mode = tabControlTarget.SelectedTab?.Text ?? "Planet";

            if (mode == "Planet")
            {
                var select = comboBoxPlanet.SelectedItem?.ToString();
                if (_geoCoordinate is null || select is null)
                {
                    targetpos = null;
                    labelTarget.Text = "Invalid GRID or Target";
                    return;
                }
                if (select == "Moon")
                {
                    targetpos = CelestialCoordinates.CalculateHorizontalCoordinatesMoon(DateTime.UtcNow, _geoCoordinate.Longitude, _geoCoordinate.Latitude);
                }
                else
                {
                    var planet = (CelestialCoordinates.Planets)Enum.Parse(typeof(CelestialCoordinates.Planets), select);
                    targetpos = CelestialCoordinates.CalculateHorizontalCoordinatesPlanets(DateTime.UtcNow, _geoCoordinate.Longitude, _geoCoordinate.Latitude, planet);
                }
            }
            else
            {
                if (_geoCoordinate is null)
                {
                    targetpos = null;
                    labelTarget.Text = "Invalid GRID";
                    return;
                }
                targetpos = SatelliteCoordinates.CalculateSatelliteCoordinates(textBoxTLE.Text, DateTime.UtcNow, _geoCoordinate.Longitude, _geoCoordinate.Latitude);
                if (targetpos == null)
                {
                    labelTarget.Text = "Invalid TLE";
                }
            }
            if (targetpos != null)
            {
                labelTarget.Text = "Target :   " + targetpos.ToString();
            }
        }

        private void SendRotatorCommand(object? sender, System.Timers.ElapsedEventArgs e)
        {
            currentpos = rotctld?.GetPosition();
            if (currentpos != null)
            {
                labelCurrent.Text = "Current : " + currentpos.ToString(false);
            }
            else
            {
                labelCurrent.Text = "Failed to get current position";
            }

            Thread.Sleep(100);

            if (buttonTrack.Text == "Stop" && targetpos is not null)
            {
                rotctld?.SetPosition(targetpos.azimuth, targetpos.altitude);
            }

            if (!connected)
            {
                timerRot.Stop();
                rotctld?.Dispose();
                rotctld = null;
            }
        }

        private void textBoxGrid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _geoCoordinate = MaidenheadConverter.Convert(textBoxGrid.Text);
                labelPostion.Text = _geoCoordinate.ToString();
            }
            catch (Exception)
            {
                _geoCoordinate = null;
                labelPostion.Text = "Invalid GRID";
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (buttonConnect.Text == "Connect")
            {
                try
                {
                    rotctld = new Rotctld(textBoxAddress.Text);
                    connected = true;
                    timerRot.Start();
                    buttonConnect.Text = "Disconnect";
                }
                catch (Exception)
                {
                    rotctld = null;
                    MessageBox.Show("Failed to connect to rotator");
                }
            }
            else
            {
                connected = false;
                buttonTrack.Text = "Track";
                buttonConnect.Text = "Connect";
            }
        }

        private void buttonTrack_Click(object sender, EventArgs e)
        {
            if (buttonTrack.Text == "Track" && buttonConnect.Text == "Disconnect")
            {
                buttonTrack.Text = "Stop";
            }
            else
            {
                buttonTrack.Text = "Track";
            }
        }
    }
}
