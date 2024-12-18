using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using ZXing;

namespace NewProject.Pages {
    /// <summary>
    /// Логика взаимодействия для MarkUpPage.xaml
    /// </summary>
    public partial class MarkUpPage :Page {

        public MarkUpPage() {
            InitializeComponent();

            try {
                System.Drawing.Image img = null;
                BitmapImage bimg = new BitmapImage();
                using(var ms = new MemoryStream()) {
                    BarcodeWriter writer;
                    writer = new ZXing.BarcodeWriter() { Format = BarcodeFormat.QR_CODE };
                    writer.Options.Height = 80;
                    writer.Options.Width = 280;
                    writer.Options.PureBarcode = true;
                    img = writer.Write("https://otzovik.com");
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    ms.Position = 0;
                    bimg.BeginInit();
                    bimg.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    bimg.CacheOption = BitmapCacheOption.OnLoad;
                    bimg.UriSource = new Uri("https://otzovik.com");
                    bimg.StreamSource = ms;
                    bimg.EndInit();
                    this.imgbarcode.Source = bimg;// return File(ms.ToArray(), "image/jpeg");  
                    //this.tbkbarcodecontent.Text = tbkbarcodecontent.Text;
                }
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
