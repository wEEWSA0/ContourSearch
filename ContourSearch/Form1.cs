using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContourSearch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var port = int.Parse(ConfigurationManager.AppSettings.Get("port"));
            var client = new UdpClient(port);

            ContourDetector detector;

            while (true)
            {
                var data = await client.ReceiveAsync();

                using (var ms = new MemoryStream(data.Buffer))
                {
                    SourcePictureBox.Image = new Bitmap(ms);
                    detector = new ContourDetector(new Bitmap(ms));
                }
                
                Text = "Bytes recived: " + data.Buffer.Length * sizeof(byte);

                RGB fonColor = new RGB();

                OnlyContour.Image = detector.TransformBoolArrayInImage(detector.FindContourInRGB(trackUncertaintyBar.Value, ref fonColor));

                labelFon.Text = "Фоном является цвет " + fonColor;
            }
        }

        private void OnlyContour_Click(object sender, EventArgs e)
        {

        }

        private void trackUncertaintyBar_Scroll(object sender, EventArgs e)
        {
            labelBar.Text = trackUncertaintyBar.Value.ToString();
        }

        private void labelFon_Click(object sender, EventArgs e)
        {

        }
    }
}
