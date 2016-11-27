using System;
using System.Windows.Forms;
using Windows.Devices.Geolocation;
using System.Device.Location;


namespace WindowsFormsApplication1
{
    public partial class GoLocalWindowsClient : Form
    {

        public GoLocalWindowsClient()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // GetLocation();

        }

        private void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            MessageBox.Show(String.Format("Lat: {0}, Long: {1}", e.Position.Location.Latitude, e.Position.Location.Longitude));
        }

        private void login_Click(object sender, EventArgs e)
        {
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
            watcher.PositionChanged += watcher_PositionChanged;
            watcher.Start();
            userlabel.Hide();
            userinput.Hide();
            passlabel.Hide();
            passinput.Hide();
            post.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {



        }
    }
}
