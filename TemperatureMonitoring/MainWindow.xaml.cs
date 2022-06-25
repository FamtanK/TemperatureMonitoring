using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Globalization;
using System.IO;
using System.Globalization;

namespace TemperatureMonitoring
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FishInfo info;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            var loadDialog = new Microsoft.Win32.OpenFileDialog();
            loadDialog.ShowDialog();

            if (loadDialog.FileName != "")
            {
                try
                {
                    Load(loadDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnMonitoring_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                info = new FishInfo();
                Parse();
                info.FindViolations();
                tblkRes.Text = info.GetViolations();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Parse()
        {
            info.beginTime = DateTime.Parse(tbDate.Text, new CultureInfo("ru-RU"));

            foreach (var temp in tbTempInfo.Text.Split())
            {
                info.temps.Add(int.Parse(temp));
            }
            info.type = tbFishName.Text;
            info.maxTemp = int.Parse((tbMaxTemp.Text.Split())[0]);
            info.minTemp = int.Parse((tbMinTemp.Text.Split())[0]);
            info.maxTime = int.Parse((tbMaxTemp.Text.Split())[1]);
            info.minTime = int.Parse((tbMinTemp.Text.Split())[1]);

        }

        private void Load(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                tbDate.Text = reader.ReadLine();
                tbTempInfo.Text = reader.ReadLine();
            }
        }
    }
}
